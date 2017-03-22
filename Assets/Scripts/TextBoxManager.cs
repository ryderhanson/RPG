using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SDD.Events;
using SDD;

public class TextBoxManager : EventHandler {

    [SerializeField]
    private Text _mainMessageText = null;

    [SerializeField]
    private GameObject _textBox = null;

    [SerializeField]
    private float _letterAddDelay = 0.5f;

    [SerializeField]
    private AudioClip _blipClip = null;

    [SerializeField]
    private AudioSource _audioSource = null;

    public override void SubscribeEvents()
    {
        Events.AddListener<PopTextBoxEvent>(OnPopTextBox);
    }

    public override void UnsubscribeEvents()
    {
        Events.RemoveListener<PopTextBoxEvent>(OnPopTextBox);
    }

    private void OnPopTextBox(PopTextBoxEvent e)
    {
        if (!e.Handled)
        {
            StartCoroutine(PopulateContent(e.Content));
        }
    }

    private IEnumerator PopulateContent(string content)
    {
        _textBox.SetActive(true);
        _mainMessageText.text = "";

        for(int i = 1; i < content.Length + 1; ++i)
        {
            _mainMessageText.text = content.Substring(0, i);

            if (content[i] != ' ')
            {
                _audioSource.PlayOneShot(_blipClip);
            }

            yield return new WaitForSeconds(_letterAddDelay);
        }
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
