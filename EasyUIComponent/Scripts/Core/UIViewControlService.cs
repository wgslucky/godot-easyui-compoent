

using System;
using System.Collections.Generic;
using Godot;

/// <summary>
/// UI视图窗口注册管理服务,它的主要作为就是注册要使用UI子场景预制体，在使用的时候会使用注册进来的UI组件名字查找对应的场景视图预制体
/// </summary>
public class UIViewControlService
{
    private static Dictionary<string, string> registerDic = new Dictionary<string, string>();

    private static Dictionary<int, BaseUIView> openUIViewDic = new Dictionary<int, BaseUIView>();

    private int uiInstanceId = 1;

    private static UIViewControlService _instance = new UIViewControlService();

    public static UIViewControlService Instance()
    {
        return _instance;
    }




    private int NextInstanceId()
    {
        return uiInstanceId += 1;
    }

    public void RegisterUIView(string uiViewName, string uiViewPath)
    {
        registerDic[uiViewName] = uiViewPath;
    }

    public T  OpenView<T>(string uiViewName, Node parentNode) where T: BaseUIView
    {
        if (registerDic.ContainsKey(uiViewName))
        {
            try
            {
                GD.Print($"要打开{uiViewName},挂载的父节点：{parentNode.Name}");
                string uiViewPath = registerDic[uiViewName];
                GD.Print($"UI组件路径:{uiViewPath}");
                PackedScene uiPrefab = GD.Load<PackedScene>(uiViewPath);
                if (uiPrefab == null)
                {
                    GD.PrintErr($"UI预制加载失败！检查注册路径：{uiViewPath}");
                    return null;
                }
                T instanceView = uiPrefab.Instantiate<T>();
                instanceView.uiInstanceId = NextInstanceId();
                instanceView.AfterOpenView();

                parentNode.AddChild(instanceView);
                openUIViewDic[instanceView.uiInstanceId] = instanceView;
                return instanceView;
            }
            catch (Exception e)
            {
                GD.Print($"初始化ui组件异常,{e}");
            }
        }
        else
        {
            GD.Print($"当前UIView未注册，名字：{uiViewName}");
        }
        return null;
    }

    /// <summary>
    /// 关闭视图
    /// </summary>
    /// <param name="uiInstanceId"></param>
    public void CloseView(int uiInstanceId)
    {
            BaseUIView baseUIView = openUIViewDic[uiInstanceId];
            baseUIView.QueueFree();
            baseUIView.AfterCloseView();
            GD.Print($"关闭UI {baseUIView.Name}");
    }
}