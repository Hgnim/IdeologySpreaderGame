using Godot;
using IdeologySpreaderGame.data.entityBase;
using System;

namespace IdeologySpreaderGame.objects.entityBase;

public partial class EntityBase : RigidBody2D
{
	/// <summary>
	/// 意识形态初始值
	/// </summary>
	[Export]
	internal Ideology initvalIdeology = Ideology.none;
	[Export]
	internal uint initvalExp = 0;
	[Export]
	internal int initvalLoyalty = 0;

	internal EntityData EData { get; set; } = new();

	protected private Sprite2D ideology;
	protected private Label exp;
	protected private Label loyalty;

	/// <summary>
	/// 碰撞冷却，防止短时间内触发过多次
	/// </summary>
	/*private Timer areaEntered_cooldown = new() {
		OneShot = true,
		WaitTime = .05f,
	};*/
	public override void _Ready() {
		ideology = GetNode<Sprite2D>("ideology");
		exp = GetNode<Label>("exp");
		loyalty = GetNode<Label>("loyalty");

		EData.Ideology_Change += Ideology_Change;
		EData.Exp_Change += Exp_Change;
		EData.Loyalty_Change += Loyalty_Change;

		EData.Ideology = initvalIdeology;
		EData.Exp = initvalExp;
		EData.Loyalty = initvalLoyalty;

		//AddChild(areaEntered_cooldown);
	}

	void Ideology_Change(Ideology ideo) {
		switch (ideo) {
			case Ideology.none:
				ideology.Texture = null;
				break;
			case Ideology.Anarchism:
				ideology.Texture = GD.Load<Texture2D>("res://assets/img/ideology/Anarchism.png");
				break;
			case Ideology.Fascism:
				ideology.Texture = GD.Load<Texture2D>("res://assets/img/ideology/Fascism.png");
				break;
		}
	}
	void Exp_Change(uint exp) => this.exp.Text = exp.ToString();
	void Loyalty_Change(int loy) => loyalty.Text = loy.ToString();


	protected virtual void On_area2d_areaEntered(Area2D area) {
		//if (!areaEntered_cooldown.IsStopped()) return;

		EntityBase targetEB = area.GetNode<EntityBase>("..");

		if (EData.Ideology == Ideology.none) {
			EData.Ideology = targetEB.EData.Ideology;

			EData.Exp = targetEB.EData.Exp / 3;
			EData.Loyalty = targetEB.EData.Loyalty / 3;
		}
		else { 
			if(EData.Ideology == targetEB.EData.Ideology) {
				EData.Loyalty += (int)(targetEB.EData.Exp / 2);
			}
			else {
				EData.Loyalty -= (int)targetEB.EData.Exp;
				if (EData.Loyalty < 0) {
					targetEB.EData.Exp++;
					EData.Ideology = targetEB.EData.Ideology;
					EData.Loyalty = 0;
					EData.Exp = EData.Exp / 2 + targetEB.EData.Exp / 3;
				}
			}
		}

		//areaEntered_cooldown.Start();
	}
}
