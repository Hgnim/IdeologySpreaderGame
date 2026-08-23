using System;

namespace IdeologySpreaderGame.data.entityBase {
	internal enum Ideology {
		none,
		Anarchism,
		Fascism,
	}
	internal class EntityData {
		private Ideology? ideology=null;
		internal delegate void deleg_Ideology_Change(Ideology? newIdeo, Ideology? oldIdeo);
		internal deleg_Ideology_Change Ideology_Change;
		/// <summary>
		/// 意识形态<br/>
		/// 为null则表示当前未赋值
		/// </summary>
		internal Ideology? Ideology {
			get => ideology;
			set {
				entityBase.Ideology? old = Ideology;
				ideology = value;
				Ideology_Change?.Invoke(Ideology, old);
			}
		}

		private uint exp = 0;
		internal Action<uint> Exp_Change;
		/// <summary>
		/// 经验
		/// </summary>
		internal uint Exp {
			get => exp;
			set {
				exp = value;
				Exp_Change?.Invoke(Exp);
			}
		}

		private int loyalty = 0;
		internal Action<int> Loyalty_Change;
		/// <summary>
		/// 忠诚度
		/// </summary>
		internal int Loyalty {
			get => loyalty;
			set {
				loyalty = value;
				Loyalty_Change?.Invoke(Loyalty);
			}
		}
	}
}