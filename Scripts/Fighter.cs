using Godot;
using System;

public partial class Fighter : Enemy
{
	[Export] private Timer blastTimer;
	[Export] private PackedScene orb;

	public override void _Ready()
	{
		blastTimer.Start();
	}


	public override void _Process(double delta)
	{
		floatDelta = (float)delta;
		Move();
	}


	protected override void Blast(){}

	protected override void Move()
	{
		Translate(Vector2.Down * speed * floatDelta);
		Translate(0.1f * (float)Math.Sin(5 * Position.Y * floatDelta) * Vector2.Right);
	}

	public void _on_visible_on_screen_notifier_2d_screen_exited()
	{
		CallDeferred("free");
	}

	public void _on_blast_timer_timeout()
	{
		Node2D o = (Node2D)orb.Instantiate();
		o.GlobalPosition = GlobalPosition;
		GetTree().Root.AddChild(o);
	}
	
}
