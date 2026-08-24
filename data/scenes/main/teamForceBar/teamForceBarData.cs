using Godot;
using Godot.Collections;
using IdeologySpreaderGame.data.entityBase;

namespace IdeologySpreaderGame.scenes.main.teamForceBar {
	/// <summary>
	/// 兵力条数据类
	/// </summary>
	internal static class TeamForceBarData {
		/// <summary>
		/// 兵力数据，包含颜色与数量
		/// </summary>
		internal struct TeamForce {
			/// <summary>
			/// 使用的颜色
			/// </summary>
			internal Color Color { get; set; }
			/// <summary>
			/// 数量
			/// </summary>
			internal float Amount { get; set; }

			internal TeamForce(Color color, float amount) {
				Color = color;
				Amount = amount;
			}
		}
		internal static readonly Dictionary<Ideology, Color> tfColorDict = new() {
			{Ideology.none,Colors.Gray},
			{Ideology.Anarchism,Colors.Black },
			{Ideology.Fascism,new Color("#6B5406")},
			{Ideology.Communism,new Color("#ED1C24") },
			{Ideology.Capitalism,new Color("#FFC90E") },
		};
	}
}