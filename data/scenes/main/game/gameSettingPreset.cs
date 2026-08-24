namespace IdeologySpreaderGame.data.scenes.main.game {
	/// <summary>
	/// 游戏设置预设
	/// </summary>
	internal static class GameSettingPreset {
		/// <summary>
		/// 所有队伍平衡
		/// </summary>
		internal static readonly GameSetting AllTeamBalanced = new() {
			EntityMax = 1000,
			NoneSpawnSpeed = 6,
			NoneAmount = [100, 10, 5, 2, 1],
			AnarchismAmount = [0, 0, 1],
			FascismAmount = [0, 0, 1],
			CommunismAmount = [0, 0, 1],
			CapitalismAmount = [0, 0, 0, 1],
			NoneSpawnPos = new(2500, 2500),
			AnarchismSpawnPos = new(50, 4950),
			FascismSpawnPos = new(4950, 50),
			CommunismSpawnPos = new(50, 50),
			CapitalismSpawnPos = new(4950, 4950),
		};
	}
}