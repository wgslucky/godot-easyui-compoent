using Godot;
using System;

public partial class UiAlertTextConfirmNode : BaseAlertUiView
{

	private LinkButton okBtn;
	private LinkButton canncelBtn;
	private bool hadBindButtonAction;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.InitAlertUiView();
		this.okBtn = this.GetNode<LinkButton>("PopupPanel/Panel/MarginContainer/HBoxContainer/OkBtn");
		this.okBtn.Pressed += OnPopuPanelHide;
		this.canncelBtn = this.GetNode<LinkButton>("PopupPanel/Panel/MarginContainer/HBoxContainer/CannelBtn");
		this.canncelBtn.Pressed += OnPopuPanelHide;
	}

	public void BindButtonClickAction(Action okBtnClick,Action canncelBtnClick)
	{
		if(hadBindButtonAction)
		{
			// 防止重复绑定
			return;
		}
		this.hadBindButtonAction = true;
		this.okBtn.Pressed += okBtnClick;
		this.canncelBtn.Pressed += canncelBtnClick;
	}


	
}
