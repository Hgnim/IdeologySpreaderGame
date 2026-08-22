using Godot;
using IdeologySpreaderGame.objects.entityBase;

namespace IdeologySpreaderGame.objects.npc;
public partial class Npc : EntityBase {
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	protected override void On_area2d_areaEntered(Area2D area) => base.On_area2d_areaEntered(area);
}
