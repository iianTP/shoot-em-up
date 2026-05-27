using Godot;
using System;

public partial class Menu : CanvasLayer
{
	[Export] private PackedScene inputBox;
	[Export] private Button play;
	
	public void _on_play_pressed()
	{
		play.Disabled = true;
		if (inputBox.Instantiate() is LineEdit le)
		{
			le.TextSubmitted += StartGame;
			GetNode<VBoxContainer>("VBoxContainer").AddChild(le);
		}
		
	}

	public void _on_scores_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/leaderboard.tscn");
	}
	
	public void _on_quit_pressed()
	{
		GetTree().Quit();
	}

	public void StartGame(string username)
	{
		if (username.Length == 3)
		{
			Data.instance.Username = username;
			GetTree().ChangeSceneToFile("res://Scenes/world.tscn");
		}
	}
}
