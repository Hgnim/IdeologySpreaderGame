using Godot;

namespace IdeologySpreaderGame.scenes.main;

[Tool]
public partial class Background : ColorRect
{
	[Export]
	public Color gridColor = new(0.35f, 0.35f, 0.35f, 0.6f);

	[Export]
	public float gridSize = 32.0f;

	[Export]
	public float lineWidth = 1.0f;

	public override void _Ready() {
		Resized += () => QueueRedraw();//大小变化时重绘

		QueueRedraw();
	}

	public override void _Draw() {
		//使用ColorRect的Color属性绘制背景色
		DrawRect(new Rect2(Vector2.Zero, Size), Color);

		Vector2 size = Size;

		//绘制竖线
		for (float x = 0; x <= size.X; x += gridSize) {
			DrawLine(
				new Vector2(x, 0),
				new Vector2(x, size.Y),
				gridColor,
				lineWidth
			);
		}

		//绘制横线
		for (float y = 0; y <= size.Y; y += gridSize) {
			DrawLine(
				new Vector2(0, y),
				new Vector2(size.X, y),
				gridColor,
				lineWidth
			);
		}
	}
}
