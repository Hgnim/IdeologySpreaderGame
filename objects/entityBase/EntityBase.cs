using Godot;
using IdeologySpreaderGame.data.entityBase;
using System;

public partial class EntityBase : RigidBody2D
{
	/// <summary>
	/// 默认使用的意识形态
	/// </summary>
	[Export]
	internal Ideology defIdeology = Ideology.none;

	internal EntityData EData { get; set; } = new();

	internal Sprite2D ideology;
	internal Label exp;
	internal Label loyalty;
	public override void _Ready() {
		ideology = GetNode<Sprite2D>("ideology");
		exp = GetNode<Label>("exp");
		loyalty = GetNode<Label>("loyalty");

		EData.Ideology_Change += Ideology_Change;
		EData.Exp_Change += Exp_Change;
		EData.Loyalty_Change += Loyalty_Change;

		EData.Ideology = defIdeology;
	}

	void Ideology_Change(Ideology ideo) {
		switch (ideo) {
			case Ideology.none:
				ideology.Texture = null;
				break;
			case Ideology.Anarchism:
				ideology.Texture = GD.Load<Texture2D>("res://assets/img/ideology/anarchism.png");
				break;
			case Ideology.Fascism:
				ideology.Texture = GD.Load<Texture2D>("res://assets/img/ideology/fascism.png");
				break;
		}
	}
	void Exp_Change(uint exp) => this.exp.Text = exp.ToString();
	void Loyalty_Change(int loy) => loyalty.Text = loy.ToString();

	protected virtual void On_area2d_areaEntered(Area2D area) { }
}
