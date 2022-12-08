using System.Collections.Generic;
using UnityEngine;

public class DebugPanelInfoElement
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

public class DebugPanelInfo
{
    private List<DebugPanelInfoElement> _elements = new List<DebugPanelInfoElement>();

    public void Update(string id, string text)
    {
        var element = GetOrCreateElement(id);
        element.Init(id, text);
    }

    private DebugPanelInfoElement GetOrCreateElement(string id)
    {
        foreach (var element in _elements)
        {
            if (element.Id == id)
            {
                return element;
            }
        }

        DebugPanelInfoElement newElement = new DebugPanelInfoElement();
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

public class DebugPanel
{
    private DebugPanelBehaviour _behaviour;
    private DebugPanelInfo _info = new DebugPanelInfo();

    public void Init(DebugPanelBehaviour debugPanelBehaviour)
    {
        _behaviour = debugPanelBehaviour;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _behaviour.Toggle();
        }
    }

    public void UpdateInfo(string id, string text)
    {
        _info.Update(id, text);
        UpdateBehaviour();
    }

    private void UpdateBehaviour()
    {
        _behaviour.SetText(_info.GetStringWithElements());
    }
}
