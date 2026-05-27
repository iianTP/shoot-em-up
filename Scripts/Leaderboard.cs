using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Leaderboard : CanvasLayer
{
	[Export] private RichTextLabel rtl;
	
	public override void _Ready()
	{

		List<Dictionary<string,string>> scores = Data.instance.GetData();

		var sortedScores = scores.OrderByDescending(s => s["score"].ToInt()).ToList();

		GD.Print(sortedScores,scores.Count);

		for (int i = 1; i < scores.Count+1; i++)
		{
			rtl.Text += $"{i} - {sortedScores[i-1]["name"]}\n"+
			$"SCORE: {sortedScores[i-1]["score"]}\n"+
			$"KILLS: {sortedScores[i-1]["kill_count"]}\n\n";
			GD.Print(rtl.Text);
		}

	}

	public void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/menu.tscn");
	}

}
