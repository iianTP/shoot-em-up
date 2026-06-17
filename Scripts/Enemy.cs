using Godot;
using System;

public abstract partial class Enemy : Character
{
	[Export] protected int score;
	[Signal] public delegate void DiedEventHandler(int s);

	protected override void Die()
	{
		Audio.Instance.DeathSfx();
		EmitSignal(SignalName.Died,score);
		CallDeferred("free");
	}


	public override void _on_area_2d_area_entered(Area2D area)
	{
		if (area.IsInGroup("PlayerProjectile"))
		{
			TakeDamage(1);
			area.CallDeferred("free");
		}
	}
}
