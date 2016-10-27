using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour
 {

	
	public float Speed = 1;

	private Rigidbody2D _myRigidBody;
	private Animator _animator;
	private bool _rightArrow;
	private bool _leftArrow;

	// Use this for initialization
	void Start ()
	{
		_myRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		 Speed = 5f;
	}


	// Update is called once per frame
	void Update ()
	{
		Move();
	}


	public void Move ()
	{
		//Input holder
		_rightArrow = Input.GetKey(KeyCode.RightArrow);
		_leftArrow = Input.GetKey(KeyCode.LeftArrow);

		//Movement input.
		if (_rightArrow)
		{
			_myRigidBody.velocity = new Vector2(Speed, _myRigidBody.velocity.y);
			_animator.SetFloat("Speed", Speed);
		}

		else if (_leftArrow)
		{
			_myRigidBody.velocity = new Vector2(-Speed, _myRigidBody.velocity.y);
			_animator.SetFloat("Speed", -Speed);
		}

		else
		{
			_myRigidBody.velocity = Vector2.zero;
		}
	}
}
