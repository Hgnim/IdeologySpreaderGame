using Godot;
using IdeologySpreaderGame.data.entityBase;
using System;
using System.Collections.Generic;

namespace IdeologySpreaderGame.data.scenes.main.teamForceBar {
	/// <summary>
	/// 兵力数据类
	/// </summary>
	internal class TeamForce {
		/// <summary>
		/// 队伍
		/// </summary>
		internal Ideology Team { get; set; }
		/// <summary>
		/// 数量
		/// </summary>
		internal uint Amount { get; set; }

		internal TeamForce(Ideology team, uint amount) {
			Team = team;
			Amount = amount;
		}
	}
	internal class TeamForceData {
		//internal TeamForce TeamForce { get; set; }
		/// <summary>
		/// 当前兵力数据<br/>
		/// 不要直接修改该字典，使用SetTeamForce方法修改数据
		/// </summary>
		internal Dictionary<Ideology, TeamForce> TeamForces { get; set; } = [];

		/// <summary>
		/// TeamForces被更改时触发（调用SetTeamForce方法时触发）
		/// </summary>
		internal Action TeamForces_Changed;

		/// <summary>
		/// 修改指定队伍的兵力数据，如果目标队伍不存在则自动创建
		/// </summary>
		/// <param name="team">队伍</param>
		/// <param name="amount">数量</param>
		internal void SetTeamForce(Ideology team, uint amount) {
			if(TeamForces.TryGetValue(team,out TeamForce tf)) {
				tf.Amount = amount;
			}
			else {
				TeamForces.Add(team, new(team, amount));
			}
			TeamForces_Changed?.Invoke();
		}
		/// <summary>
		/// 在原基础上更改指定队伍的兵力数据，如果目标队伍不存在则自动创建
		/// </summary>
		/// <param name="team">队伍</param>
		/// <param name="amount">数量</param>
		internal void ChangeTeamForce(Ideology team, int amount) {
			if (TeamForces.TryGetValue(team, out TeamForce tf)) {
				tf.Amount += (uint)amount;
			}
			else {
				TeamForces.Add(team, new(team, (uint)amount));
			}
			TeamForces_Changed?.Invoke();
		}
	}
}