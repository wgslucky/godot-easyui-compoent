using Godot;
using System;

public partial class UiAlertManager 
{

	public static void RegisterUI()
	{
		UIViewControlService.Instance().RegisterUIView("AlertTextUI","res://UIAlert/ui_alert_text.tscn");
		UIViewControlService.Instance().RegisterUIView("AlertTextOkUI","res://UIAlert/ui_alert_text_ok.tscn");
		UIViewControlService.Instance().RegisterUIView("AlertTextOkCanncelUI","res://UIAlert/ui_alert_text_confirm.tscn");
	}

	/// <summary>
	/// 弹出文字提示面板，只有文字提示，点击空白地方自动关闭
	/// </summary>
	/// <param name="text"></param>
	 public static UiAlertTextNode AlertText(string text)
	{
		Node node = EasyUIRoot.Instance().GetRootNode();
		UiAlertTextNode uiAlertText = UIViewControlService.Instance().OpenView<UiAlertTextNode>("AlertTextUI",node);
		if (uiAlertText == null)
		{
			GD.Print("alert text 组件为空");
			return null;
		}
		GD.Print("显示文本");
		uiAlertText.ShowText(text);
		return uiAlertText;
		
	}

	/// <summary>
	/// 弹出文字提示面板，有文字提示及确认按钮，点击空白地方自动关闭
	/// </summary>
	/// <param name="text"></param>
	public static UiAlertTextOkNode AlertTextOk(string text)
	{
		Node node = EasyUIRoot.Instance().GetRootNode();
		UiAlertTextOkNode uiAlertText = UIViewControlService.Instance().OpenView<UiAlertTextOkNode>("AlertTextOkUI",node);
		if (uiAlertText == null)
		{
			GD.Print("alert text 组件为空");
			return null;
		}
		uiAlertText.ShowText(text);
		return uiAlertText;
	}


	public static UiAlertTextConfirmNode AlertTextConfirm(string text,Action okBtnClick,Action canncelBtnClick)
	{
		Node node = EasyUIRoot.Instance().GetRootNode();
		UiAlertTextConfirmNode uiAlertTextConfirm = UIViewControlService.Instance().OpenView<UiAlertTextConfirmNode> ("AlertTextOkCanncelUI",node);
		uiAlertTextConfirm.BindButtonClickAction(okBtnClick,canncelBtnClick);
		uiAlertTextConfirm.ShowText(text);
		return uiAlertTextConfirm;
	}

	
}
