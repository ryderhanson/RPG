using UnityEngine;
using System.Collections;
using SDD.Events;

public class PopTextBoxEvent : BaseEvent
{
    public string Content { get; set; }

    public override string ToString()
    {
        return string.Format("Textbox Pop: {0}", Content);
    }
}
