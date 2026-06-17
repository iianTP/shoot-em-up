using Godot;
using System;

public partial class Audio : Node2D
{
	public static Audio Instance { get; private set; }

	[Export] private AudioStreamPlayer2D music;
	[Export] private AudioStreamPlayer2D shot;
	[Export] private AudioStreamPlayer2D death;

	public override void _Ready()
	{
		Instance = this;
		music.Finished += PlayMusic;
	}


	public void PlayMusic()
	{
		music.Play();
	}

	public void StopMusic()
	{
		music.Stop();
	}

	public void ShotSfx()
	{
		shot.Play();
	}

	public void DeathSfx()
	{
		death.Play();
	}

}
