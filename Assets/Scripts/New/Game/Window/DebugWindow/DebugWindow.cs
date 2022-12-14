using System.Collections.Generic;
using UnityEngine;

public class DebugWindowInfoElement
{
    private string _id;
    private string _text;

    public string Id => _id;
    public string Text => _text;

    public void Init(string id, string text)
    {
        _id = id;
        _text = text;
    }
}

public class DebugWindowInfo
{
    private List<DebugWindowInfoElement> _elements = new List<DebugWindowInfoElement>();

    public void Update(string id, string text)
    {
        var element = GetOrCreateElement(id);
        element.Init(id, text);
    }

    private DebugWindowInfoElement GetOrCreateElement(string id)
    {
        foreach (var element in _elements)
        {
            if (element.Id == id)
            {
                return element;
            }
        }

        var newElement = new DebugWindowInfoElement();
        _elements.Add(newElement);
        return newElement;
    }

    public string GetStringWithElements()
    {
        string str = "";

        foreach (var element in _elements)
        {
            str += $"{element.Text}\n";
        }

        return str;
    }
}

public class DebugWindow : Window
{
    private KeyCode _openKey;
    private DebugWindowInfo _info = new DebugWindowInfo();

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (IsKeyPressed() && Behaviour == null)
        {
            OpenByAction();
        }
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        UpdateText();
    }

    public override bool IsClose()
    {
        return IsKeyPressed();
    }

    public void SetOpenKey(KeyCode keyCode)
    {
        _openKey = keyCode;
    }

    public void SetInfo(string id, string text)
    {
        _info.Update(id, text);
        UpdateText();
    }

    private void UpdateText()
    {
        var behaviour = GetBehaviour();
        if (behaviour != null)
        {
            behaviour.SetText(_info.GetStringWithElements());
        }
    }

    private DebugWindowBehaviour GetBehaviour()
    {
        if (Behaviour != null)
        {
            return Behaviour.GetComponent<DebugWindowBehaviour>();
        }
        return null;
    }

    private bool IsKeyPressed()
    {
        return Input.GetKeyDown(_openKey);
    }
}
