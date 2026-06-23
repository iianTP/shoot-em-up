using Godot;
using System;

public partial class GameOver : CanvasLayer
{
	public void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/UI/menu.tscn");
	}
}
