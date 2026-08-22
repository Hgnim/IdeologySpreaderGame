using Godot;
using IdeologySpreaderGame.objects.entityBase;

namespace IdeologySpreaderGame.objects.player;

public partial class Player : EntityBase {
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	
	public override void _Process(double delta)
	{
		Vector2 keyInput = Input.GetVector("moveLeft", "moveRight", "moveUp", "moveDown");

		if (keyInput != Vector2.Zero) {//按键按下时施加推力移动
			ApplyCentralForce(keyInput * moveForce);
		}

		if (LinearVelocity.Length() > maxSpeed) {//限制最大速度，防止无限加速
			LinearVelocity = LinearVelocity.Normalized() * maxSpeed;
		}
	}

	protected override void On_area2d_areaEntered(Area2D area) {
		//GD.Print(area.GetNode<EntityBase>("..").EData.Ideology);
		base.On_area2d_areaEntered(area);
	}
}
