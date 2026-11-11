
using Godot;

public abstract partial class BaseAlertUiView:BaseUIView
{
    
    protected Label label;
    protected PopupPanel popupPanel;


    protected void InitAlertUiView()
    {
        this.label = GetNode<Label>("PopupPanel/Panel/Label");
        if(label == null)
        {
            GD.Print("未找到Label组件!!");
            return;
        }
        this.popupPanel = GetNode<PopupPanel>("PopupPanel");
        if(this.popupPanel == null)
        {
            GD.Print("未找到PopupPanel组件!!");
            return;
        }
        this.popupPanel.PopupHide += OnPopuPanelHide;
    }

    public void ShowText(string text)
    {
        if(label == null)
        {
            return;
        }
        if(this.popupPanel == null)
        {
            return;
        }
        this.popupPanel.PopupCentered();
        this.label.Text = text;
    }
    protected void OnPopuPanelHide()
    {
        this.CLoseSelf();
    }


}