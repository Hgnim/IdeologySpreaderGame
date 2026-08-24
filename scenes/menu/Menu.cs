using Godot;
using IdeologySpreaderGame.data.scenes.main.game;
using IdeologySpreaderGame.scripts;
using System;

namespace IdeologySpreaderGame.scenes.menu;
public partial class Menu : Control
{

	DataCore dataCore;
	public override void _Ready() {
		dataCore = GetNode<DataCore>("/root/DataCore");
	}

	void On_startGame_pressed() {
		dataCore.GameSetting = GameSettingPreset.AllTeamBalanced;
		GetTree().ChangeSceneToFile("res://scenes/main/main.tscn");
	}
}
