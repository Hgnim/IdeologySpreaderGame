using Godot;

namespace IdeologySpreaderGame.data.scenes.main.game {
	internal struct GameSetting {
		public GameSetting() { }
		/// <summary>
		/// 单位最大阈值，超过此阈值后将不再执行单位自动生成
		/// </summary>
		internal required uint EntityMax { get; set; }
		/// <summary>
		/// 无阵营单位数量<br/>
		/// 数组索引与EntityPreset预设对应
		/// </summary>
		internal uint[] NoneAmount { get; set; } = [0];
		/// <summary>
		/// 安那其单位数量
		/// </summary>
		internal uint[] AnarchismAmount { get; set; } = [0];
		/// <summary>
		/// 法西斯单位数量
		/// </summary>
		internal uint[] FascismAmount { get; set; } = [0];
		/// <summary>
		/// 共产单位数量
		/// </summary>
		internal uint[] CommunismAmount { get; set; } = [0];
		/// <summary>
		/// 资本单位数量
		/// </summary>
		internal uint[] CapitalismAmount { get; set; } = [0];

		/// <summary>
		/// 无阵营单位的自动生成速度，单位：个/分钟
		/// </summary>
		internal ushort NoneSpawnSpeed { get; set; } = 0;

		/// <summary>
		/// 无阵营单位生成位置坐标
		/// </summary>
		internal required Vector2 NoneSpawnPos { get; set; }
		/// <summary>
		/// 无政府单位生成位置坐标
		/// </summary>
		internal required Vector2 AnarchismSpawnPos { get; set; }
		/// <summary>
		/// 法西斯单位生成位置坐标
		/// </summary>
		internal required Vector2 FascismSpawnPos { get; set; }
		/// <summary>
		/// 共产单位生成位置坐标
		/// </summary>
		internal required Vector2 CommunismSpawnPos { get; set; }
		/// <summary>
		/// 资本单位生成位置坐标
		/// </summary>
		internal required Vector2 CapitalismSpawnPos { get; set; }

		/// <summary>
		/// 机器人难度
		/// </summary>
		internal required BotSetting BotSetting { get; set; }
	}
	internal struct BotSetting {
		private float acceleration;
		/// <summary>
		/// 机器人加速度倍率<br/>
		/// 不可为零或负，1则是正常加速度（与玩家加速度相匹配）
		/// </summary>
		internal required float Acceleration {
			get => acceleration;
			set {
				if (value < 0) acceleration = 0.001f;
				else {
					acceleration = value;
				}
			}
		}

		private float maxSpeed;
		/// <summary>
		/// 机器人最大速度倍率<br/>
		/// 不可为零或负，1则是正常最大速度（与玩家最大速度相匹配）
		/// </summary>
		internal required float MaxSpeed {
			get => maxSpeed;
			set {
				if (value < 0) maxSpeed = 0.001f;
				else maxSpeed = value;
			}
		}

		/// <summary>
		/// 机器人丢失目标后寻找下一个目标前的等待时间，单位：秒<br/>
		/// 设置为负数则禁用等待时间
		/// </summary>
		internal required double LostTargetWaitTime { get; set; }
	}
	
}