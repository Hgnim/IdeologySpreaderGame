using Godot;

namespace IdeologySpreaderGame.data.scenes.main.game {
	internal class GameSetting {
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
	}
}