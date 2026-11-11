using Godot;
using System;

public partial class UiAlertTextOkNode : BaseAlertUiView
{
	private LinkButton okBtn;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.InitAlertUiView();

		this.okBtn = this.GetNode<LinkButton>("PopupPanel/Panel/MarginContainer/LinkButton");
		this.okBtn.Pressed += OnPopuPanelHide;
	}
}
