using Godot;
using System;

public partial class Main : Node2D
{

	[Export] private PackedScene asteroid;
	[Export] private PackedScene fighter;
	[Export] private PackedScene globe;
	[Export] private RichTextLabel scoreUI;
	[Export] private Timer spawnTimer;

	private Random rng = new Random();

	private float timePassed = 0;

	private int probAsteroid = 100;
	private int probFighter = 50;
	private int probGlobe = 0;
	
	public override void _Ready()
	{
		SpawnEnemy();
		spawnTimer.Timeout += SpawnEnemy;
		spawnTimer.Start();
	}

	public override void _Process(double delta)
	{	
		timePassed += (float)delta;
		spawnTimer.WaitTime = 5 * (float)Math.Exp(-0.03f * timePassed) + 0.5f;
		if (probGlobe < 25) probGlobe = (int)timePassed;
		if (probFighter < 70) probFighter = 50 + (int)timePassed;
	}

	private void AddScore(int s)
	{
		Data.instance.Score += s;
		Data.instance.KillCount++;
		UpdateScore();
	}
	private void UpdateScore()
	{
		scoreUI.Text = "score: " + Data.instance.Score.ToString("D6");
	}

	private void SpawnEnemy()
	{

		int prob = rng.Next(0,100);
		Node e;
		if (prob < probGlobe)        e = globe.Instantiate();
		else if (prob < probFighter) e = fighter.Instantiate();
		else 				         e = asteroid.Instantiate();
		
		if (e is Enemy enemy)
		{
			enemy.Died += AddScore;
			int x = rng.Next(40,161);
			enemy.Position = new Vector2(x,-60);
			AddChild(enemy);
		}
	}
	
}
