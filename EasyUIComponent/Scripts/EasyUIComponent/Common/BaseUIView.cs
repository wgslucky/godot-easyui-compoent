using Godot;
using System;

/// <summary>
/// Alert消息的基类
/// </summary>
public partial class BaseUIView : Node
{
	// 实例id
	public int uiInstanceId;

	/// <summary>
	/// 在窗口打开之后做的一些操作
	/// </summary>
	public virtual void AfterOpenView()
	{
		
	}
	/// <summary>
	/// 在窗口关闭时做的一些操作
	/// </summary>
	public virtual  void AfterCloseView()
	{
		
	}

	public virtual void CLoseSelf()
	{
		UIViewControlService.Instance().CloseView(this.uiInstanceId);
	}

}
