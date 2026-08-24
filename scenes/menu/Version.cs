using Godot;
using System;

namespace IdeologySpreaderGame.scenes.menu;
[Tool]
public partial class Version : Label
{
	public override void _Ready()
	{
		Text = $"版本：{ProjectSettings.GetSetting("application/config/version").AsString()}";
	}
}
