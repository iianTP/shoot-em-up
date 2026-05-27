using Godot;
using System;

public partial class Projectile : Area2D
{
	[Export] private Vector2 direction;
	[Export] private int speed;

	public override void _Process(double delta)
	{
		Translate(direction * speed * (float)delta);
	}

	public void _on_visible_on_screen_notifier_2d_screen_exited()
	{
		CallDeferred("free");
	}

}
