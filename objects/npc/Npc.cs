using Godot;
using IdeologySpreaderGame.objects.entityBase;
using IdeologySpreaderGame.scripts;
using System;
using System.Collections.Generic;

namespace IdeologySpreaderGame.objects.npc;
public partial class Npc : EntityBase {
	/// <summary>
	/// 进入追踪范围的目标列表
	/// </summary>
	List<EntityBase> trackTarget = [];
	int? trackTarget_currentIndex = null;
	DataCore dataCore;
	public override void _Ready() {
		base._Ready();

		dataCore = GetNode<DataCore>("/root/DataCore");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

	}

	double lostTargetWaitTime_timer = 0;
	public override void _PhysicsProcess(double delta) {
		if (lostTargetWaitTime_timer <= 0) {
			if (trackTarget.Count > 0) {
				bool check() =>
					!(
					trackTarget_currentIndex == null
					|| trackTarget_currentIndex >= trackTarget.Count
					|| trackTarget[(int)trackTarget_currentIndex].EData.Ideology == EData.Ideology
					)
					;
				if (!check()) {
					List<int> tg = [];
					for (int i = 0; i < trackTarget.Count; i++) {
						if (trackTarget[i].EData.Ideology != EData.Ideology)
							tg.Add(i);
					}
					trackTarget_currentIndex = tg.Count > 0
						? tg[new Random().Next(tg.Count)]
						: null;
				}
				if (check()) {
					Vector2 targetPos = trackTarget[(int)trackTarget_currentIndex].GlobalPosition - GlobalPosition;

					ApplyCentralForce(targetPos.Normalized() * moveForce * dataCore.GameSetting.BotSetting.Acceleration);
				}
				else lostTargetWaitTime_timer = dataCore.GameSetting.BotSetting.LostTargetWaitTime;
				/*else {
				 //后续在此制作无目标时的游荡行为
				}*/

				if (LinearVelocity.Length() > maxSpeed*dataCore.GameSetting.BotSetting.MaxSpeed) {//限制最大速度
					LinearVelocity = LinearVelocity.Normalized() * maxSpeed;
				}
			}
		}
		else lostTargetWaitTime_timer -= delta;
	}

	protected override void On_area2d_areaEntered(Area2D area) => base.On_area2d_areaEntered(area);

	protected override void On_tracker_areaEntered(Area2D area) {
		trackTarget.Add(area.GetNode<EntityBase>(".."));
	}
	protected override void On_tracker_areaExited(Area2D area) {
		trackTarget.Remove(area.GetNode<EntityBase>(".."));
	}
}
