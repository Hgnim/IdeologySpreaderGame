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
			BotSetting=BotDifficultyPreset.Normal,
		};
		internal static readonly GameSetting BigAnarchism = new() {
			EntityMax = 1000,
			NoneSpawnSpeed = 12,
			NoneAmount = [20, 4, 3, 2, 1],
			AnarchismAmount = [100],
			FascismAmount = [0, 0, 0, 0, 1],
			CommunismAmount = [0, 0, 0, 0, 1],
			CapitalismAmount = [0, 0, 0, 0, 1],
			NoneSpawnPos = new(2500, 2500),
			AnarchismSpawnPos = new(50, 4950),
			FascismSpawnPos = new(4950, 50),
			CommunismSpawnPos = new(50, 50),
			CapitalismSpawnPos = new(4950, 4950),
			BotSetting = BotDifficultyPreset.Normal,
		};
		internal static readonly GameSetting BigFascism = new() {
			EntityMax = 1000,
			NoneSpawnSpeed = 12,
			NoneAmount = [20, 4, 3, 2, 1],
			AnarchismAmount = [0, 0, 0, 0, 1],
			FascismAmount = [50, 20, 10, 5, 2],
			CommunismAmount = [0, 0, 0, 0, 1],
			CapitalismAmount = [0, 0, 0, 0, 1],
			NoneSpawnPos = new(2500, 2500),
			AnarchismSpawnPos = new(50, 4950),
			FascismSpawnPos = new(4950, 50),
			CommunismSpawnPos = new(50, 50),
			CapitalismSpawnPos = new(4950, 4950),
			BotSetting = BotDifficultyPreset.Normal,
		};
		internal static readonly GameSetting BigCommunism = new() {
			EntityMax = 1000,
			NoneSpawnSpeed = 12,
			NoneAmount = [20, 4, 3, 2, 1],
			AnarchismAmount = [0, 0, 0, 0, 1],
			FascismAmount = [0, 0, 0, 0, 1],
			CommunismAmount = [50, 20, 10, 5, 2],
			CapitalismAmount = [0, 0, 0, 1],
			NoneSpawnPos = new(2500, 2500),
			AnarchismSpawnPos = new(50, 4950),
			FascismSpawnPos = new(4950, 50),
			CommunismSpawnPos = new(50, 50),
			CapitalismSpawnPos = new(4950, 4950),
			BotSetting = BotDifficultyPreset.Normal,
		};
		internal static readonly GameSetting BigCapitalism = new() {
			EntityMax = 1000,
			NoneSpawnSpeed = 12,
			NoneAmount = [20, 4, 3, 2, 1],
			AnarchismAmount = [0, 0, 0, 0, 1],
			FascismAmount = [0, 0, 0, 0, 1],
			CommunismAmount = [0, 0, 0, 0, 1],
			CapitalismAmount = [5, 20, 50, 5, 1],
			NoneSpawnPos = new(2500, 2500),
			AnarchismSpawnPos = new(50, 4950),
			FascismSpawnPos = new(4950, 50),
			CommunismSpawnPos = new(50, 50),
			CapitalismSpawnPos = new(4950, 4950),
			BotSetting = BotDifficultyPreset.Normal,
		};

		/// <summary>
		/// 机器人难度预设
		/// </summary>
		internal static class BotDifficultyPreset {
			internal static readonly BotSetting Easy = new() {
				Acceleration = .005f,
				MaxSpeed = .65f,
				LostTargetWaitTime = 10,
			};
			internal static readonly BotSetting Normal = new() {
				Acceleration = .05f,
				MaxSpeed = .85f,
				LostTargetWaitTime = 5,
			};
			internal static readonly BotSetting Hard = new() {
				Acceleration = .5f,
				MaxSpeed = 1,
				LostTargetWaitTime = 3,
			};
			internal static readonly BotSetting VeryHard = new() {
				Acceleration = 1f,
				MaxSpeed = 1.2f,
				LostTargetWaitTime = 1,
			};
			internal static readonly BotSetting Hell = new() {
				Acceleration = 2,
				MaxSpeed = 1.6f,
				LostTargetWaitTime = -1,
			};
		}
	}
}