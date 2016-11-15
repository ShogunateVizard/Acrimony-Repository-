using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class Player: Humenoid
{
	public bool _jumpButton;

	private BulletDestroyer _destroyerOfBullet;
	

	//Weapon vars
	private PlayerBullet _playerBullet;
	public bool ShootKey;

	//Jump vars
	
	
	public float JumpHeight;

	//Needed component for the weapon
	public GameObject Bullet;
	public Transform WeaponBarrel;

	[Tooltip("Enter the ground layer to check for.")]
	public 	LayerMask GroundMask;

	// Use this for initialization
	private void Start ()
	{
		ShootKey = Input.GetKeyDown (KeyCode.Z);

		//All the necessary information for the player to function properly
		_myBody2D = gameObject.GetComponent<Rigidbody2D> ();
		MyAnimator = gameObject.GetComponent<Animator> ();

		//Player speed and bool check
		_mySpeed = 5;
		_grounded = false;
	}


	// Update is called once per frame
	private void Update ()
	{
		Movement ();
	}


	//Have the player move.
	private void Movement ()
	{
		CheckIfGrounded();
		IgnoreCollision();
		Attack();
		Jump();

		//Get the coordinates of the player.
		_myDirection = Input.GetAxisRaw ("Horizontal");
		var mySpeed = _myDirection * _mySpeed;

		// Movement
		_myBody2D.velocity = new Vector2 (mySpeed, _myBody2D.velocity.y);
		MyAnimator.SetFloat ("Speed", Mathf.Abs (mySpeed));
		Rotate (_myDirection);
	}


	//Rotate the player on the horizontal axis
	private void Rotate (float currentAxis)
	{
		//Rotate to the right.
		if (currentAxis > 0)
		{
			transform.eulerAngles = new Vector2 (0, 0);
		}

		//Rotate the player to th left
		if (currentAxis < 0)
		{
			transform.eulerAngles = new Vector2 (0, 180);
		}
	}


	//Jump function
	private void Jump()
	{
		var jumpButton = Input.GetAxisRaw("Jump");
		if (_grounded && jumpButton > 0)
		{
			_grounded = false;
			MyAnimator.SetBool("isGrounded", _grounded);	
			_myBody2D.AddForce(new Vector2(0, JumpHeight));
		}
		else
		{
			_grounded = true;
		}
	}


	// Player attack function
	public void Attack ()
	{
		ShootKey = Input.GetKeyDown (KeyCode.Z);

		// Check if the player press the button.
		if (ShootKey)
		{
			MyAnimator.SetBool("Attacking", true);
			Instantiate(Bullet, WeaponBarrel.transform.position, Quaternion.identity);
		} else
		{
			MyAnimator.SetBool("Attacking", false);
		}
	}


	//Ignore the collision of the player with the bullet.
	private void IgnoreCollision ()
	{
		var bulletBody = Bullet.GetComponent<Collider2D> ();
		var myCollider = GetComponent<Collider2D> ();
		Physics2D.IgnoreCollision (myCollider, bulletBody, true);
	}


	//Check if the player is grounded
	private void CheckIfGrounded()
	{
		//Check if the ground collider is.... on the ground
		_grounded = Physics2D.OverlapCircle(GroundCheck.position, _checkGroundRadius, GroundMask);
		MyAnimator.SetBool ("isGrounded", _grounded);

		//Set the animation to fallow the y-axis speed of the character while in the air.
		MyAnimator.SetFloat("VerticalSpeed", _myBody2D.velocity.y);
	}
}