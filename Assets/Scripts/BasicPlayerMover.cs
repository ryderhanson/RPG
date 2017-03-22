using UnityEngine;
using Jammer;

public class BasicPlayerMover : MonoBehaviour {
    [SerializeField]
    private float _speed = 30f;

    [SerializeField]
    private Animator _animator = null;

    private Rigidbody2D _rigid = null;

    private enum DIRECTION
    {
        NONE = 0,
        LEFT = 1,
        RIGHT = 2,
        UP = 3,
        DOWN = 4
    }
	// Use this for initialization
	void Start () {
        _rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float locSpeed = _speed * Time.deltaTime;
        Vector3 newVelocity = Vector3.zero;

        DIRECTION curDirection = DIRECTION.NONE;


        if (Input.GetKey(KeyCode.S))
        {
            newVelocity += new Vector3(0, -locSpeed, 0);

            curDirection = DIRECTION.DOWN;
        }


        if (Input.GetKey(KeyCode.W))
        {
            curDirection = DIRECTION.UP;

            newVelocity += new Vector3(0, locSpeed, 0);
        }


        if (Input.GetKey(KeyCode.A))
        {
            curDirection = DIRECTION.LEFT;

            newVelocity += new Vector3(-locSpeed, 0, 0);
        }


        if (Input.GetKey(KeyCode.D))
        {
            curDirection = DIRECTION.RIGHT;

            newVelocity += new Vector3(locSpeed, 0, 0);
        }

        _animator.SetInteger("Direction", (int)curDirection);

        _rigid.velocity = newVelocity;
    }
}
