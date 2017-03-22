using UnityEngine;
using System.Collections;
using SDD.Events;

public class Test : MonoBehaviour
{
    public string message;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        EventManager.Instance.Raise(new PopTextBoxEvent() {Content = message, Handled = false});
	    }
	}
}
