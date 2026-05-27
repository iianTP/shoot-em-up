using Godot;
using System;

public partial class Asteroid : Enemy
{

	public override void _Process(double delta)
	{
		floatDelta = (float)delta;
		Move();
	}

	protected override void Blast(){}

	protected override void Move()
	{
		Translate(Vector2.Down * speed * floatDelta);
	}

	public void _on_visible_on_screen_notifier_2d_screen_exited()
	{
		CallDeferred("free");
	}

}
