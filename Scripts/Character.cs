using Godot;
using System;

public abstract partial class Character : CharacterBody2D
{
	[Export] protected int speed;
	[Export] protected int lives;
	protected float floatDelta;
	protected abstract void Move();
	protected abstract void Blast();
	protected abstract void Die();

	public abstract void _on_area_2d_area_entered(Area2D area);

	protected void TakeDamage(int damage)
	{
		lives -= damage;
		if (lives <= -1) Die();
	}



}
