using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    // 存放现有面板的栈
    private Stack<UIBase> UIStack = new Stack<UIBase>();

    // 保存当前的面板
    private Dictionary<string, UIBase> currentUIDict = new Dictionary<string, UIBase>();

    // 名字 ---- 面板的prefab
    private Dictionary<string, GameObject> UIObjectDict = new Dictionary<string, GameObject>();

    public string ResourceDir = "UI";

    void Awake()
    {
        _instance = this;
        //LoadAllUIObject();

        AddUIBase("UIStart");
        AddUIBase("UIOption");
        AddUIBase("Playing");
        AddUIBase("UILose");
    }

    // 入栈 把界面显示出来
    public void PushUIPanel(string UIName)
    {
        if (UIStack.Count > 0)
        {
            UIBase old_topUI = UIStack.Peek();
            old_topUI.DoOnPausing();
        }

        UIBase new_topUI = GetUIBase(UIName);
        new_topUI.DoOnEntering();
        UIStack.Push(new_topUI);
    }

    private UIBase GetUIBase(string UIName)
    {
        foreach (var name in currentUIDict.Keys)
        {
            if (name == UIName)
            {
                UIBase u = currentUIDict[UIName];
                return u;
            }
        }

        //如果没有　就先得到面板的ｐｒｅｆａｂ
        GameObject UIPrefab = UIObjectDict[UIName];
        GameObject UIObject = GameObject.Instantiate<GameObject>(UIPrefab);
        UIObject.name = UIName;
        UIBase uibase = UIObject.GetComponent<UIBase>();
        currentUIDict.Add(UIName, uibase);
        return uibase;
    }

    //出栈 把界面隐藏
    public void PopUIPanel()
    {
        if (UIStack.Count == 0)
            return;

        UIBase old_topUI = UIStack.Pop();
        old_topUI.DoOnExiting();

        if (UIStack.Count > 0)
        {
            UIBase new_topUI = UIStack.Peek();
            new_topUI.DoOnResuming();
        }

    }

    //private void LoadAllUIObject()
    //{
    //    string path = Application.dataPath + "/Game/Resources/" + ResourceDir;
    //    DirectoryInfo folder = new DirectoryInfo(path);
    //    foreach (FileInfo file in folder.GetFiles("*.prefab"))
    //    {
    //        int index = file.Name.LastIndexOf('.');
    //        string UIName = file.Name.Substring(0, index);
    //        string UIPath = ResourceDir + "/" + UIName;
    //        GameObject UIObject = Resources.Load<GameObject>(UIPath);
    //        UIObjectDict.Add(UIName, UIObject);
    //    }
    //}


    public void AddUIBase(string UIName)
    {
        string UIPath = ResourceDir + "/" + UIName;
        GameObject UIObject = Resources.Load<GameObject>(UIPath);
        if (UIObject)
            UIObjectDict.Add(UIName, UIObject);
    }
}
