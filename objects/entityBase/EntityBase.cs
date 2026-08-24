using Godot;
using IdeologySpreaderGame.data.entityBase;
using IdeologySpreaderGame.scenes.main;
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
	/// <summary>
	/// 最大的移动速度
	/// </summary>
	[Export] public float maxSpeed = 300f;
	/// <summary>
	/// 移动推力
	/// </summary>
	[Export] public float moveForce = 1500f;

	internal EntityData EData { get; set; } = new();

	protected private Sprite2D ideology;
	protected private Label exp;
	protected private Label loyalty;

	private TeamForceBar tfb;

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

		tfb = GetNode<TeamForceBar>("../ui/teamForceBar");

		EData.Ideology_Change += Ideology_Change;
		EData.Exp_Change += Exp_Change;
		EData.Loyalty_Change += Loyalty_Change;

		EData.Ideology = initvalIdeology;
		EData.Exp = initvalExp;
		EData.Loyalty = initvalLoyalty;

		//AddChild(areaEntered_cooldown);
	}

	void Ideology_Change(Ideology? ideo,Ideology? old) {
		{
			switch (ideo) {
				case Ideology.none:
				case null:
					ideology.Texture = null;
					break;
				case Ideology.Anarchism:
				case Ideology.Fascism:
				case Ideology.Communism:
				case Ideology.Capitalism:
					ideology.Texture = GD.Load<Texture2D>("res://assets/img/ideology/"+ideo.ToString()+".png");
					break;
			}
		}
		if (ideo != null) {
			tfb.tfData.ChangeTeamForce((Ideology)ideo, +1);
		}
		if (old != null) {
			tfb.tfData.ChangeTeamForce((Ideology)old, -1);
		}
	}
	void Exp_Change(uint exp) => this.exp.Text = exp.ToString();
	void Loyalty_Change(int loy) => loyalty.Text = loy.ToString();


	protected virtual void On_area2d_areaEntered(Area2D area) {
		//if (!areaEntered_cooldown.IsStopped()) return;

		EntityBase targetEB = area.GetNode<EntityBase>("..");


		if (EData.Ideology == targetEB.EData.Ideology) {
			EData.Loyalty += (int)(targetEB.EData.Exp / 2);
		}
		else {
			if (targetEB.EData.Ideology != Ideology.none)
				EData.Loyalty -= (int)targetEB.EData.Exp;
			if (EData.Loyalty < 0) {
				targetEB.EData.Exp++;
				EData.Ideology = targetEB.EData.Ideology;
				if (EData.Ideology == Ideology.none) {
					EData.Exp = targetEB.EData.Exp / 3;
					EData.Loyalty = targetEB.EData.Loyalty / 3;
				}
				else {
					EData.Loyalty = 0;
					EData.Exp = EData.Exp / 2 + targetEB.EData.Exp / 3;
				}
			}
		}

		//areaEntered_cooldown.Start();
	}

	protected virtual void On_tracker_areaEntered(Area2D area) { }
	protected virtual void On_tracker_areaExited(Area2D area) { }
}
