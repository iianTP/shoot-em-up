using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Data : Node
{
	public static Data instance;

	private ConfigFile cf = new ConfigFile();

	private string _username = "AAA";
	private int _score = 0;
	private int _killCount = 0;

	public int Score
	{
		get => _score;
		set { _score = value; }
	}

	public int KillCount
	{
		get => _killCount;
		set { _killCount = value; }
	}

	public string Username
	{
		get => _username;
		set { _username = value; }
	}

	public override void _Ready()
	{
		instance = this;
	}


	public void SaveData()
	{
		Error err = cf.Load("user://scores.cfg");
		
		if (err != Error.Ok) { return; }

		cf.SetValue(_username,"score",_score);
		cf.SetValue(_username,"kill_count",_killCount);
		cf.Save("user://scores.cfg");
	}

	public List<Dictionary<string,string>> GetData()
	{
		Error err = cf.Load("user://scores.cfg");
		
		if (err != Error.Ok) { return null; }

		List<Dictionary<string, string>> dataDict = [];

		foreach (string player in cf.GetSections())
		{
			var scoresDict = new Dictionary<string, string>()
			{
				{"name", player},
				{"score", cf.GetValue(player,"score").ToString()},
				{"kill_count", cf.GetValue(player,"kill_count").ToString()}
			};
			dataDict = dataDict.Append(scoresDict).ToList();
		}

		return dataDict;
	}

	public void ResetData()
	{
		_username = "AAA";
		_score = 0;
		_killCount = 0;
	}
}
