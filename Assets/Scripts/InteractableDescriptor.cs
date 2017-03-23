using UnityEngine;
using System.Collections;
using SDD.Events;

public class InteractableDescriptor : MonoBehaviour, IInteractable
{
    [SerializeField] private string _description = "An unimplemented message. Oops!";

    public void OnInteractedWith(BasicPlayerMover player)
    {
        EventManager.Instance.Raise(new PopTextBoxEvent() { Content = _description, Handled = false });
    }
}
