using Godot;
using IdeologySpreaderGame.data.scenes.main.game;
using static IdeologySpreaderGame.data.scenes.main.game.GameSettingPreset;

namespace IdeologySpreaderGame.scenes.menu;
public partial class GameSetting : Panel
{
	Button[] btn=new Button[6+1];
	byte btn_selIndex = 1;
	OptionButton botDiff;
	public override void _Ready()
	{
		for(byte b = 0; b < btn.Length; b++) {
			btn[b] = GetNode<Button>($"preset/btn{b}");
		}
		botDiff = GetNode<OptionButton>("botDiff");

		OnBtnClick(btn_selIndex);//执行一遍以选中目标
	}

	void OnBtnClick(byte btnId) {
		for(byte b = 0; b < btn.Length; b++) {
			btn[b].Disabled = false;
		}
		btn[btnId].Disabled = true;
		btn_selIndex = btnId;
	}

	void On_btn1_pressed() {
		OnBtnClick(1);
	}
	void On_btn2_pressed() {
		OnBtnClick(2);
	}
	void On_btn3_pressed() {
		OnBtnClick(3);
	}
	void On_btn4_pressed() {
		OnBtnClick(4);
	}
	void On_btn5_pressed() {
		OnBtnClick(5);
	}
	void On_btn6_pressed() {
		OnBtnClick(6);
	}

	internal data.scenes.main.game.GameSetting GetGameSetting() {
		data.scenes.main.game.GameSetting output;
		switch (btn_selIndex) {
			default:
			case 1:
				output = GameSettingPreset.AllTeamBalanced;
				break;
			case 2:
				output = GameSettingPreset.BigAnarchism;
				break;
			case 3:
				output = GameSettingPreset.BigFascism;
				break;
			case 4:
				output = GameSettingPreset.BigCommunism;
				break;
			case 5:
				output = GameSettingPreset.BigCapitalism;
				break;
			case 6:
				output = GameSettingPreset.BigNone;
				break;
		}
		switch (botDiff.Selected) {
			case 0:
				output.BotSetting = BotDifficultyPreset.Easy;
				break;
			case 1:
				output.BotSetting = BotDifficultyPreset.Normal;
				break;
			case 2:
				output.BotSetting = BotDifficultyPreset.Hard;
				break;
			case 3:
				output.BotSetting = BotDifficultyPreset.VeryHard;
				break;
			case 4:
				output.BotSetting = BotDifficultyPreset.Hell;
				break;
		}
		return output;
	}
}
