using Godot;
using System;
using System.Linq;

public partial class Globe : Enemy
{
	private Timer movementTimer => GetNode<Timer>("MoveTimer");

	private GlobeBlast globeBlast;

	private readonly Random rng = new Random();
	
	private Vector2[] positions = [Vector2.Zero,Vector2.Zero,Vector2.Zero];
	private int positIndex = 1;
	private int[] minCoords = [20,65];
	private int[] maxCoords = [180,180];

	private bool onScreen = false;


	public override void _Process(double delta)
	{
		floatDelta = (float)delta;
		if (onScreen)
		{
			Move();
			if (movementTimer.IsStopped())
				movementTimer.Start();
		} else
		{
			Translate(Vector2.Down * 100 * (float)delta);
		}
	}

	protected override void Move()
	{
		Position = Position.MoveToward(positions[positIndex], speed * floatDelta);
	}

	protected override void Blast()
	{
		
	}

	public void _on_visible_on_screen_notifier_2d_screen_entered()
	{
		int x, y;
		onScreen = true;
		positions[0] = GlobalPosition;
		for (int i = 1; i < 3; i++)
		{
			x = rng.Next(minCoords[0], maxCoords[0]);
			y = rng.Next(minCoords[1], maxCoords[1]);
			positions[i] = new Vector2(x,y);
		}

		GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D").QueueFree();
	}

	public void _on_move_timer_timeout()
	{
		positIndex++;
		if (positIndex >= 3)
			positIndex = 0;
		movementTimer.Stop();
	}

}
