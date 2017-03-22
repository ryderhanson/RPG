using UnityEngine;
using System.Collections;

public class FollowGameObject : MonoBehaviour {

    [SerializeField]
    private GameObject _followedObject = null;

    [SerializeField]
    private bool _followsX = true;

    [SerializeField]
    private bool _followsY = true;

    [SerializeField]
    private bool _followsZ = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	    if(_followedObject)
        {
            Vector3 thisPos = transform.position;
            Vector3 followPos = _followedObject.transform.position;

            thisPos.x = _followsX ? followPos.x : thisPos.x;
            thisPos.y = _followsY ? followPos.y : thisPos.y;
            thisPos.z = _followsZ ? followPos.z : thisPos.z;

            transform.position = thisPos;
        }
    }
}
