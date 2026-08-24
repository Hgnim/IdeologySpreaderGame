using Godot;
using IdeologySpreaderGame.data.scenes.main.game;
using IdeologySpreaderGame.objects.npc;
using IdeologySpreaderGame.scripts;
using System;

namespace IdeologySpreaderGame.scenes.main;
public partial class Main : Node2D {
	PackedScene npcRes = GD.Load<PackedScene>("res://objects/npc/npc.tscn");
	DataCore dataCore;
	Timer noneEntitySpawnTimer;
	TeamForceBar teamForceBar;
	public override void _Ready() {
		dataCore = GetNode<DataCore>("/root/DataCore");
		noneEntitySpawnTimer = GetNode<Timer>("noneEntitySpawnTimer");
		teamForceBar = GetNode<TeamForceBar>("ui/teamForceBar");

		InitGame(dataCore.GameSetting);
	}

	void InitGame(GameSetting gs) {
		noneEntitySpawnTimer.WaitTime = (double)60 / (double)gs.NoneSpawnSpeed;
		for(byte team = 0; team < 5; team++) {
			EntityInitvalSetting[] eisPreset=[];
			uint[] amount=[];
			Vector2 pos = Vector2.Zero;
			switch (team) {
				case 0:
					eisPreset = EntityPreset.None;
					amount = gs.NoneAmount;
					pos = gs.NoneSpawnPos;
					break;
				case 1:
					eisPreset = EntityPreset.Anarchism;
					amount = gs.AnarchismAmount;
					pos = gs.AnarchismSpawnPos;
					break;
				case 2:
					eisPreset = EntityPreset.Fascism;
					amount = gs.FascismAmount;
					pos = gs.FascismSpawnPos;
					break;
				case 3:
					eisPreset = EntityPreset.Communism;
					amount = gs.CommunismAmount;
					pos = gs.CommunismSpawnPos;
					break;
				case 4:
					eisPreset = EntityPreset.Capitalism;
					amount = gs.CapitalismAmount;
					pos = gs.CapitalismSpawnPos;
					break;
			}
			for (byte i = 0; i < amount.Length; i++) {
				if (amount[i] > 0) {
					for (byte j = 0; j < amount[i]; j++) {
						Npc npc = (Npc)npcRes.Instantiate();
						npc.GlobalPosition = pos;
						npc.initvalIdeology = eisPreset[i].Ideology;
						npc.initvalExp = eisPreset[i].Exp;
						npc.initvalLoyalty = eisPreset[i].Loyalty;

						GetTree().CurrentScene.AddChild(npc);
					}
				}
			}
		}
		noneEntitySpawnTimer.Start();
	}

	void On_noneEntitySpawnTimer_timeout() {
		if (teamForceBar.Total <= dataCore.GameSetting.EntityMax) {
			Npc npc = (Npc)npcRes.Instantiate();
			{
				Random ran = new();
				npc.GlobalPosition = new Vector2(ran.Next(50, 4950 + 1), ran.Next(200, 4950 + 1));
			}
			npc.initvalIdeology = data.entityBase.Ideology.none;
			npc.initvalExp = 0;
			npc.initvalLoyalty = 0;
			GetTree().CurrentScene.AddChild(npc);
		}
	}
}
