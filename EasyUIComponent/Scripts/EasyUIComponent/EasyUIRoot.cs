using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class EasyUIRoot : Node
{
	private static EasyUIRoot _instance;

    public static EasyUIRoot Instance()
    {
        return _instance;
    }

    public  Node GetRootNode()
    {
        return GetTree().Root;
    }
     

    public override void _EnterTree()
    {
        _instance = this;
    }

    public override void _Ready()
    {
        UiAlertManager.RegisterUI();
    }	
}
