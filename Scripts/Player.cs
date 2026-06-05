using Godot;
using System;

public partial class Player : Character
{
	[Export] private Sprite2D[] hearts;
	[Export] private PackedScene projectileScene;
	[Export] private AnimatedSprite2D as2d;

	public override void _Process(double delta)
	{
		
		Move();
		UpdateSprites();
		
		if (Input.IsActionJustPressed("shoot"))
			Blast();
		
	}


	protected override void Move()
	{
		Vector2 move = Input.GetVector("left","right","up","down");
		Velocity = move * speed;
		MoveAndSlide();
		FixPosition();
	}

	private void UpdateSprites()
	{
		if (Velocity.X < 0)
			as2d.Play("left");
		else if (Velocity.X > 0)
			as2d.Play("right");
		else
			as2d.Play("idle");
	}

	private void FixPosition()
	{
		float clampedX = Mathf.Clamp(Position.X, 0, 200);
		float clampedY = Mathf.Clamp(Position.Y, 0, 320);
		Position = new Vector2(clampedX, clampedY);
	}

	protected override void Blast()
	{
		Node2D projectile = (Node2D)projectileScene.Instantiate();
		projectile.GlobalPosition = GlobalPosition;
		GetTree().Root.AddChild(projectile);
	}

	protected override void Die()
	{
		Data.instance.SaveData();
		Data.instance.ResetData();
		GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToFile, "res://Scenes/game_over.tscn");
	}

	public override void _on_area_2d_area_entered(Area2D area)
	{
		if (area.IsInGroup("EnemyProjectile"))
		{
			TakeDamage(1);
			area.CallDeferred("free");
			hearts[lives+1].CallDeferred("free");
		}
		if (area.IsInGroup("Enemy"))
		{
			TakeDamage(1);
			area.GetParent().CallDeferred("free");
			hearts[lives+1].CallDeferred("free");
		}
	}
}
