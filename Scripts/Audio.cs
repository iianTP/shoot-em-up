using Godot;
using System;

public partial class Audio : Node2D
{
	public static Audio Instance { get; private set; }

	[Export] private Timer pitchTimer;

	[Export] private AudioStreamPlayer2D music;
	[Export] private AudioStreamPlayer2D shot;
	[Export] private AudioStreamPlayer2D hit;
	[Export] private AudioStreamPlayer2D death;

	[Export] private AudioStreamPlayer2D hover;
	[Export] private AudioStreamPlayer2D click;

	public override void _Ready()
	{
		Instance = this;
		music.Finished += PlayMusic;
		pitchTimer.Timeout += music.Stop;
		pitchTimer.Timeout += pitchTimer.Stop;
	}

	public override void _Process(double delta)
	{
		if (!pitchTimer.IsStopped())
			music.PitchScale = (float)(pitchTimer.TimeLeft / pitchTimer.WaitTime);
	}

	public void HoverSfx()
	{
		hover.Play();
	}

	public void ClickSfx()
	{
		click.Play();
	}

	public void PlayMusic()
	{
		music.PitchScale = 1;
		music.Play();
	}

	public void StopMusic()
	{
		pitchTimer.Start();
	}

	public void ShotSfx()
	{
		shot.Play();
	}

	public void HitSfx()
	{
		hit.Play();
	}

	public void DeathSfx()
	{
		death.Play();
	}

}
