using Godot;
using IdeologySpreaderGame.data.entityBase;
using IdeologySpreaderGame.scenes.main;
using System;

namespace IdeologySpreaderGame.objects.entityBase;

public partial class EntityBase : RigidBody2D
{
	/// <summary>
	/// 意识形态初始值
	/// </summary>
	[Export]
	internal Ideology initvalIdeology = Ideology.none;
	[Export]
	internal uint initvalExp = 0;
	[Export]
	internal int initvalLoyalty = 0;
	/// <summary>
	/// 最大的移动速度
	/// </summary>
	[Export] public float maxSpeed = 300f;
	/// <summary>
	/// 移动推力
	/// </summary>
	[Export] public float moveForce = 1500f;

	internal EntityData EData { get; set; } = new();

	protected private Sprite2D ideology;
	protected private Label exp;
	protected private Label loyalty;

	private TeamForceBar tfb;

	/// <summary>
	/// 碰撞冷却，防止短时间内触发过多次
	/// </summary>
	/*private Timer areaEntered_cooldown = new() {
		OneShot = true,
		WaitTime = .05f,
	};*/
	public override void _Ready() {
		ideology = GetNode<Sprite2D>("ideology");
		exp = GetNode<Label>("exp");
		loyalty = GetNode<Label>("loyalty");

		tfb = GetNode<TeamForceBar>("../ui/teamForceBar");

		EData.Ideology_Change += Ideology_Change;
		EData.Exp_Change += Exp_Change;
		EData.Loyalty_Change += Loyalty_Change;

		EData.Ideology = initvalIdeology;
		EData.Exp = initvalExp;
		EData.Loyalty = initvalLoyalty;

		//AddChild(areaEntered_cooldown);
	}

	void Ideology_Change(Ideology? ideo,Ideology? old) {
		{
			switch (ideo) {
				case Ideology.none:
				case null:
					ideology.Texture = null;
					break;
				case Ideology.Anarchism:
				case Ideology.Fascism:
				case Ideology.Communism:
				case Ideology.Capitalism:
					ideology.Texture = GD.Load<Texture2D>("res://assets/img/ideology/"+ideo.ToString()+".png");
					break;
			}
		}
		if (ideo != null) {
			tfb.tfData.ChangeTeamForce((Ideology)ideo, +1);
		}
		if (old != null) {
			tfb.tfData.ChangeTeamForce((Ideology)old, -1);
		}
	}
	void Exp_Change(uint exp) => this.exp.Text = exp.ToString();
	void Loyalty_Change(int loy) => loyalty.Text = loy.ToString();


	/// <summary>
	/// 对当前实体执行死亡
	/// </summary>
	protected virtual void GoDie() {
		EData.Ideology = null;//销毁前把意识形态改为null，让其自动更新兵力条
		QueueFree();
	}
	protected virtual void On_area2d_areaEntered(Area2D area) {
		//if (!areaEntered_cooldown.IsStopped()) return;

		EntityBase targetEB = area.GetNode<EntityBase>("..");


		/*各派系能力：
		无阵营：
			触碰到同阵营时：
				无变化
			触碰到异阵营时：
				无变化
		安那其：
			触碰到同阵营时：
				对方忠诚值将添加，添加量为当前安那其阵营的单位数量。如果当前阵营单位数量不小于50，对方将添加一点经验值。
			触碰到异阵营时：
				对方的忠诚值将减少，减少量为自己经验值的一半
			将对方忠诚值清零后/将无阵营忠诚值清零后：
				将对方转化为自己阵营，对方经验值将保留并附加自己经验值的一半（自身经验值不会扣除），对方将获得自己一半的忠诚值（自身忠诚值不会扣除）。自己增加一点经验值
		法西斯：
			触碰到同阵营时：
				对方忠诚值将添加，添加量为自己经验值的两倍
			触碰到异阵营时：
				对方的忠诚值将减少，减少量为自己的经验值的三倍
			将对方忠诚值清零后：
				如果对方经验高于自己，则对方将会被直接杀死；反之，将对方转化为自己阵营，对方将获得自己一半的经验值（自身经验值不会扣除，对方转化前的经验值不保留），对方将获得与自己相同的忠诚值（自身忠诚值不会扣除）。自己增加一点经验值
			将无阵营忠诚值清零后：
				将对方转化为自己阵营，对方将获得自己一半的经验值（自身经验值不会扣除，对方转化前的经验值不保留），对方将获得与自己相同的忠诚值（自身忠诚值不会扣除）。自己增加一点经验值
			自己被对方清零忠诚值后：
				宁死不屈，不会被对方转化
		共产：
			触碰到同阵营时：
				对方忠诚值将添加，添加量为自己的经验值。如果自身经验值不小于50，对方将添加一点经验值。
			触碰到异阵营时：
				对方的忠诚值将减少，减少量为自己的经验值
			将对方忠诚值清零后/将无阵营忠诚值清零后：
				将对方转化为自己阵营，对方将获得与自己相同的经验值和忠诚值（自身经验值和忠诚值不会扣除，对方转化前的经验值不保留）。自己增加一点经验值
		资本：
			触碰到同阵营时：
				对方忠诚值将添加，添加量为自己的经验值的一半
			触碰到异阵营时：
				对方的忠诚值将减少，减少量为自己的经验值的两倍，并消耗自己一点忠诚值以吸取对方一点经验值
			将对方忠诚值清零后/将无阵营忠诚值清零后：
				将对方转化为自己阵营，对方将获取自身一半的经验值与忠诚值（将自身一半的经验值和忠诚值给对方，对方转化前的经验值不保留）
		*/
		if (EData.Ideology == targetEB.EData.Ideology) {//同阵营逻辑
			switch (targetEB.EData.Ideology) {//自身值变化
				case Ideology.Anarchism:
					EData.Loyalty += (int)tfb.tfData.TeamForces[Ideology.Anarchism].Amount;
					if (tfb.tfData.TeamForces[Ideology.Anarchism].Amount >= 50)
						EData.Exp++;
					break;
				case Ideology.Fascism:
					EData.Loyalty += (int)(targetEB.EData.Exp * 2);
					break;
				case Ideology.Communism:
					EData.Loyalty += (int)targetEB.EData.Exp;
					if (targetEB.EData.Exp >= 50)
						EData.Exp++;
					break;
				case Ideology.Capitalism:
					EData.Loyalty += (int)(targetEB.EData.Exp / 2);
					break;
			}
		}
		else {//异阵营逻辑
			if (targetEB.EData.Ideology != Ideology.none) {//对方不为无阵营时
				switch (targetEB.EData.Ideology) {//自身值变化
					case Ideology.Anarchism:
						EData.Loyalty -= (int)(targetEB.EData.Exp / 2);
						break;
					case Ideology.Fascism:
						EData.Loyalty -= (int)(targetEB.EData.Exp * 3);
						break;
					case Ideology.Communism:
						EData.Loyalty -= (int)targetEB.EData.Exp;
						break;
					case Ideology.Capitalism:
						EData.Loyalty -= (int)(targetEB.EData.Exp * 2);
						if (EData.Exp > 0) {
							targetEB.EData.Exp++;
							targetEB.EData.Loyalty--;
							EData.Exp--;
						}
						break;
				}
				

				if (EData.Loyalty <= 0) {//当自身忠诚值被清零后
					switch (EData.Ideology) {
						case Ideology.Fascism:
							switch (targetEB.EData.Ideology) {
								case Ideology.Anarchism:
								case Ideology.Fascism:
								case Ideology.Communism:
									targetEB.EData.Exp++;
									break;
							}
							GoDie();
							break;
						case Ideology.none:
						case Ideology.Anarchism:
						case Ideology.Communism:
						case Ideology.Capitalism:
							switch (targetEB.EData.Ideology) {
								case Ideology.Anarchism:
									targetEB.EData.Exp++;
									EData.Ideology = targetEB.EData.Ideology;
									EData.Exp += targetEB.EData.Exp / 2;
									EData.Loyalty = targetEB.EData.Loyalty / 2;
									break;
								case Ideology.Fascism:
									targetEB.EData.Exp++;
									if (EData.Ideology == Ideology.none || EData.Exp <= targetEB.EData.Exp) {
										EData.Ideology = targetEB.EData.Ideology;
										EData.Exp = targetEB.EData.Exp / 2;
										EData.Loyalty = targetEB.EData.Loyalty;
									}
									else {
										GoDie();
									}
									break;
								case Ideology.Communism:
									targetEB.EData.Exp++;
									EData.Ideology = targetEB.EData.Ideology;
									EData.Exp = targetEB.EData.Exp;
									EData.Loyalty = targetEB.EData.Loyalty;
									break;
								case Ideology.Capitalism:
									EData.Ideology = targetEB.EData.Ideology;
									EData.Exp += targetEB.EData.Exp / 2;
									EData.Loyalty = targetEB.EData.Loyalty / 2;
									targetEB.EData.Exp /= 2;
									targetEB.EData.Loyalty /= 2;
									break;
							}
							break;
					}
				}
			}
		}

		//areaEntered_cooldown.Start();
	}

	protected virtual void On_tracker_areaEntered(Area2D area) { }
	protected virtual void On_tracker_areaExited(Area2D area) { }
}
