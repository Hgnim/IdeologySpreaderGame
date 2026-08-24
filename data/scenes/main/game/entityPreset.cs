using IdeologySpreaderGame.data.entityBase;

namespace IdeologySpreaderGame.data.scenes.main.game {
	internal class EntityInitvalSetting {
		internal required Ideology Ideology { get; set; }
		internal uint Exp { get; set; } = 0;
		internal int Loyalty { get; set; } = 0;
	}
	
	/// <summary>
	/// 单位预设
	/// </summary>
	internal static class EntityPreset {
		/// <summary>
		/// 无阵营的预设<br/>
		/// 数组中的每个预设，根据索引大小，索引越大，数值越强
		/// </summary>
		internal static readonly EntityInitvalSetting[] None = [
			new(){
				Ideology=Ideology.none,
				Exp=0,
				Loyalty=0,
			},
			new(){
				Ideology=Ideology.none,
				Exp=0,
				Loyalty=100,
			},
			new(){
				Ideology=Ideology.none,
				Exp=10,
				Loyalty=1000,
			},
			new(){
				Ideology=Ideology.none,
				Exp=40,
				Loyalty=4000,
			},
			new(){
				Ideology=Ideology.none,
				Exp=100,
				Loyalty=10000,
			}
			];
		internal static readonly EntityInitvalSetting[] Anarchism = [
			new(){
				Ideology=Ideology.Anarchism,
				Exp=1,
				Loyalty=10,
			},
			new(){
				Ideology=Ideology.Anarchism,
				Exp=10,
				Loyalty=100,
			},
			new(){
				Ideology=Ideology.Anarchism,
				Exp=30,
				Loyalty=300,
			},
			new(){
				Ideology=Ideology.Anarchism,
				Exp=50,
				Loyalty=500,
			},
			new(){
				Ideology=Ideology.Anarchism,
				Exp=80,
				Loyalty=800,
			},
			];
		internal static readonly EntityInitvalSetting[] Fascism = [
			new(){
				Ideology=Ideology.Fascism,
				Exp=1,
				Loyalty=10,
			},
			new(){
				Ideology=Ideology.Fascism,
				Exp=10,
				Loyalty=100,
			},
			new(){
				Ideology=Ideology.Fascism,
				Exp=30,
				Loyalty=300,
			},
			new(){
				Ideology=Ideology.Fascism,
				Exp=50,
				Loyalty=500,
			},
			new(){
				Ideology=Ideology.Fascism,
				Exp=80,
				Loyalty=800,
			},
			];
		internal static readonly EntityInitvalSetting[] Communism = [
			new(){
				Ideology=Ideology.Communism,
				Exp=1,
				Loyalty=10,
			},
			new(){
				Ideology=Ideology.Communism,
				Exp=10,
				Loyalty=100,
			},
			new(){
				Ideology=Ideology.Communism,
				Exp=30,
				Loyalty=300,
			},
			new(){
				Ideology=Ideology.Communism,
				Exp=50,
				Loyalty=500,
			},
			new(){
				Ideology=Ideology.Communism,
				Exp=80,
				Loyalty=800,
			},
			];
		internal static readonly EntityInitvalSetting[] Capitalism = [
			new(){
				Ideology=Ideology.Capitalism,
				Exp=1,
				Loyalty=10,
			},
			new(){
				Ideology=Ideology.Capitalism,
				Exp=10,
				Loyalty=100,
			},
			new(){
				Ideology=Ideology.Capitalism,
				Exp=30,
				Loyalty=300,
			},
			new(){
				Ideology=Ideology.Capitalism,
				Exp=50,
				Loyalty=500,
			},
			new(){
				Ideology=Ideology.Capitalism,
				Exp=80,
				Loyalty=800,
			},
			];
	}
}