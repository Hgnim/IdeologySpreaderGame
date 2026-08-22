using Godot;
using IdeologySpreaderGame.objects.entityBase;
using System;
using System.Collections.Generic;

namespace IdeologySpreaderGame.objects.npc;
public partial class Npc : EntityBase {
	/// <summary>
	/// 进入追踪范围的目标列表
	/// </summary>
	List<EntityBase> trackTarget = [];
	int? trackTarget_currentIndex = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

	}
	public override void _PhysicsProcess(double delta) {
		if (trackTarget.Count > 0) {
			bool check() => 
				!(
				trackTarget_currentIndex == null
				|| trackTarget_currentIndex >= trackTarget.Count
				|| trackTarget[(int)trackTarget_currentIndex].EData.Ideology == EData.Ideology
				)
				;
			if (!check()) {
				trackTarget_currentIndex = new Random().Next(trackTarget.Count);
			}
			if (check()) {
				Vector2 targetPos = trackTarget[(int)trackTarget_currentIndex].GlobalPosition - GlobalPosition;

				ApplyCentralForce(targetPos.Normalized() * moveForce * (float)delta);
			}
			/*else {
			 //后续在此制作无目标时的游荡行为
			}*/
		}
	}

	protected override void On_area2d_areaEntered(Area2D area) => base.On_area2d_areaEntered(area);

	protected override void On_tracker_areaEntered(Area2D area) {
		trackTarget.Add(area.GetNode<EntityBase>(".."));
	}
	protected override void On_tracker_areaExited(Area2D area) {
		trackTarget.Remove(area.GetNode<EntityBase>(".."));
	}
}
