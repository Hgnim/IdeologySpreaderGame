using Godot;
using IdeologySpreaderGame.data.scenes.main.game;
using IdeologySpreaderGame.scripts;
using System;

namespace IdeologySpreaderGame.scenes.menu;
public partial class Menu : Control
{

	DataCore dataCore;
	GameSetting gameSetting;
	public override void _Ready() {
		dataCore = GetNode<DataCore>("/root/DataCore");
		gameSetting = GetNode<GameSetting>("gameSetting");
	}

	void On_startGame_pressed() {
		dataCore.GameSetting = gameSetting.GetGameSetting();
		GetTree().ChangeSceneToFile("res://scenes/main/main.tscn");
	}
}
