using Godot;
using System;

public partial class GlobeBlast : Node2D
{ 
	private readonly PackedScene orbScene = GD.Load<PackedScene>("res://Scenes/Enemies/orb.tscn");
	private Timer blasterTimer => GetNode<Timer>("BlasterTimer");
	
	[Export] public int blastAmount;
	[Export] public int maxBlasts;
	[Export] public float blastTime;
	private int blastCount = 0;

	public override void _Ready()
	{
		BlastCooldown();
	}


	public override void _Process(double delta)
	{
		Rotate((float)delta * 0.5f);
		if (Rotation > 2 * Math.PI) Rotation = 0;
	}

	private void BlastCooldown()
	{
		blasterTimer.WaitTime = 2;
		blasterTimer.Start();
	}
	public void StartBlast()
	{
		blasterTimer.WaitTime = blastTime;
		blasterTimer.Start();
	}

	private void Blast()
	{
		float section = 360/blastAmount;
		for (int i = 0; i < blastAmount; i++)
		{
			Node2D orb = (Node2D)orbScene.Instantiate();
			float angle = i * section * (float)Math.PI/180 + Rotation;
			orb.Rotation = angle;
			orb.GlobalPosition = GlobalPosition;
			GetTree().Root.AddChild(orb);
		}
		
	}

	public void _on_blaster_timer_timeout()
	{
		if (blastCount == 0)
		{
			blasterTimer.Stop();
			StartBlast();
		}

		blastCount++;

		Blast();

		if (blastCount >= maxBlasts)
		{
			blastCount = 0;
			blasterTimer.Stop();
			BlastCooldown();
		}

	}



	


}
