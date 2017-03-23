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

    private bool _isCurrentlyPopulating = false;

    private string _contentToSet = "";

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
            e.Handled = true;
            if (!_isCurrentlyPopulating)
            {
                StopAllCoroutines();

                StartCoroutine(PopulateContent(e.Content));                
            }
        }
    }

    private IEnumerator PopulateContent(string content)
    {
        _textBox.SetActive(true);
        _mainMessageText.text = "";

        _contentToSet = content;

        _isCurrentlyPopulating = true;

        for (int i = 0; i < content.Length; ++i)
        {
            _mainMessageText.text = content.Substring(0, i + 1);

            if (content[i] != ' ')
            {
                _audioSource.PlayOneShot(_blipClip);
            }

            yield return new WaitForSeconds(_letterAddDelay);
        }

        _isCurrentlyPopulating = false;
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_isCurrentlyPopulating)
            {
                StopAllCoroutines();

                _isCurrentlyPopulating = false;

                _mainMessageText.text = _contentToSet;
            }
            else if (_textBox.activeSelf)
            {
                _textBox.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_textBox.activeSelf && !_isCurrentlyPopulating)
            {
                _textBox.SetActive(false);
            }
        }
	}
}
