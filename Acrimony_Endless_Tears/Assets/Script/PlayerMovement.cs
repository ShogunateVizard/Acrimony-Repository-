using System;
using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class PlayerMovement: MonoBehaviour
{
	private Rigidbody2D _myBody2D;
	private Animator _myAnimator;
	public float _mySpeed;
	private float _myDirection;
	private bool _rightArrow;
	private bool _leftArrow;
	private bool _jumpButton;
	private bool _shootKey;


	// Use this for initialization
	void Start ()
	{
		//All the necessary information for the player to function properly
		ComponentLibrary (); 
		_mySpeed = 5;
	}


	// Update is called once per frame
	void Update ()
	{		
		Movement ();
	}


	//Components
	public void ComponentLibrary ()
	{
		_myBody2D = gameObject.GetComponent<Rigidbody2D> ();
		_myAnimator = gameObject.GetComponent<Animator> ();
	}


	//Player controllers
	public void MaintainController ()
	{
		_rightArrow = Input.GetKey(KeyCode.RightArrow);
		_leftArrow = Input.GetKey(KeyCode.LeftArrow);
		_jumpButton = Input.GetKeyDown (KeyCode.Space);
		_shootKey = Input.GetKeyDown (KeyCode.Z);
	}


	//Have the player move.
	public void Movement ()
	{ 
		MaintainController ();
		JumpFunction();
		Attack();

		//Get the coordinates of the player.
		_myDirection = Input.GetAxisRaw ("Horizontal");
		float mySpeed = _myDirection * _mySpeed;

		// Movement
		_myBody2D.velocity = new Vector2 (mySpeed, _myBody2D.velocity.y);
		_myAnimator.SetFloat ("Speed", Mathf.Abs(mySpeed));
		Rotate(_myDirection);
	}

	private void Rotate(float currentAxis)
	{
		//Rotate to the right.
		if (currentAxis > 0)
		{
			transform.eulerAngles = new Vector2(0, 0);
		}	
		
		//Rotate the player to th left
		if (currentAxis < 0 )
		{
			transform.eulerAngles = new Vector2(0, 180);
		}
		
	}


	// Jumping function
	public void JumpFunction()
	{
		// Jumping Directions
		float myJumoDir = Input.GetAxisRaw ("Vertical") * Time.deltaTime;
		float jumpDir = myJumoDir * _mySpeed;
		if (_jumpButton == true)
		{
			_myBody2D.velocity = new Vector2 (_myBody2D.velocity.x, jumpDir);
			// Play jumping animation here.
		}
	}


	// Player attack function
	public void Attack()
	{
		if (_shootKey)
		{

		}
	}
}
