using Godot;
using IdeologySpreaderGame.data.scenes.main.teamForceBar;
using System;
using System.Collections.Generic;

namespace IdeologySpreaderGame.scenes.main;

public partial class TeamForceBar : Control {
	/// <summary>
	/// 间隙
	/// </summary>
	[Export] internal float Gap = 0f;
	/// <summary>
	/// 边框宽度
	/// </summary>
	[Export] internal float BorderWidth = 0f;
	/// <summary>
	/// 边框颜色
	/// </summary>
	[Export] internal Color BorderColor = Colors.White;

	private List<TeamForceBarData.TeamForce> teamForces = new();

	internal TeamForceData tfData = new();

	/// <summary>
	/// 单位总数。属性值将随着绘制更新
	/// </summary>
	internal uint Total { get; set; } = 0;

	void TeamForces_Changed() {
		List<TeamForceBarData.TeamForce> tfs = [];
		foreach (var tf in tfData.TeamForces) {
			tfs.Add(new() {
				Color = TeamForceBarData.tfColorDict[tf.Value.Team],
				Amount = tf.Value.Amount,
			});
		}
		SetForces(tfs);
	}

	public override void _Ready() {
		tfData.TeamForces_Changed += TeamForces_Changed;
	}

	/// <summary>
	/// 设置兵力数据并立即重绘
	/// </summary>
	/// <param name="tfs"></param>
	internal void SetForces(List<TeamForceBarData.TeamForce> tfs) {
		teamForces = tfs ?? [];
		QueueRedraw();
	}

	/// <summary>
	/// 设置兵力数据并立即重绘
	/// </summary>
	/// <param name="tfs"></param>
	public void SetForces(params (Color color, float amount)[] tfs) {
		teamForces.Clear();
		foreach (var tf in tfs)
			teamForces.Add(new TeamForceBarData.TeamForce(tf.color, tf.amount));
		QueueRedraw();
	}

	//绘制
	public override void _Draw() {
		if (teamForces.Count == 0) return;

		//总兵力
		float total = 0f;
		foreach (var tf in teamForces)
			total += tf.Amount;

		if (total <= 0) return;
		Total = (uint)total;

		Rect2 rect = new(Vector2.Zero, Size);
		float currentX = 0f;
		float drawHeight = rect.Size.Y;
		float drawWidth = rect.Size.X - (teamForces.Count - 1) * Gap;

		foreach (var tf in teamForces) {
			float ratio = tf.Amount / total;
			float w = drawWidth * ratio;

			//绘制矩形色块
			DrawRect(new Rect2(currentX, 0, w, drawHeight), tf.Color);

			currentX += w + Gap;
		}

		//绘制边框
		if (BorderWidth > 0) {
			DrawRect(rect, BorderColor, false, BorderWidth);
		}
	}

	public override void _Notification(int what) {
		if (what == NotificationResized)//尺寸变化时自动重绘
			QueueRedraw();
	}
}
