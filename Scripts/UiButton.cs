using Godot;
using System;

public partial class UiButton : Button
{
	public void _on_pressed()
	{
		Audio.Instance.ClickSfx();
	}
	public void _on_mouse_entered()
	{
		Audio.Instance.HoverSfx();
	}
}
