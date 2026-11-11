using Godot;
using System;

public partial class UIDemo : Node
{
	private Button alertTextBtn;
	private Button alertTextOkBtn;

	private Button alertConfirmBtn;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.alertTextBtn = this.GetNode<Button>("MarginContainer/AlertHBoxContainer/AlertTextBtn");
		this.alertTextBtn.Pressed +=AlertTextBtnClick;

		this.alertTextOkBtn = this.GetNode<Button>("MarginContainer/AlertHBoxContainer/AlertTextOkBtn");
		this.alertTextOkBtn.Pressed += AlertTextOkBtnClick;
		
		this.alertConfirmBtn = this.GetNode<Button>("MarginContainer/AlertHBoxContainer/AlertTextConfirmBtn");
		this.alertConfirmBtn.Pressed += OnAlertConfirmBtnClick;


	}

	private void OnAlertConfirmBtnClick()
	{
		UiAlertManager.AlertTextConfirm("请选择是否确认?", () =>
		{
			GD.Print("您选择了确认!!");
		}, () =>
		{
			GD.Print("您选择了取消!");
		});
	}

	public void AlertTextBtnClick()
	{
		GD.Print("alert text ui click");
		UiAlertManager.AlertText("这个是测试的！！");
	}
	public void AlertTextOkBtnClick()
	{
		UiAlertManager.AlertTextOk("带按钮的提示测试！！");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
