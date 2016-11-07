using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class Player: HumanoidSuperClass
{
	public bool _jumpButton;

	private BulletDestroyer _destroyerOfBullet;
	private Rigidbody2D _myBody2D;
	public bool _shootKey;

	//Jump vars
	public Transform GroundCheck;
	private bool _jumping;
	private bool _grounded;
	public float _checkGroundRadius;
	public float JumpHeight;

	//Needed component for the weapon
	public GameObject Bullet;
	public Transform WeaponBarrel;

	[Tooltip("Enter the ground layer to check for.")]
	public 	LayerMask GroundMask;

	// Use this for initialization
	private void Start ()
	{
		_shootKey = Input.GetKeyDown (KeyCode.Z);

		//All the necessary information for the player to function properly
		_myBody2D = gameObject.GetComponent<Rigidbody2D> ();
		MyAnimator = gameObject.GetComponent<Animator> ();

		//Player speed and bool check
		_mySpeed = 5;
		_grounded = true;
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
	}


	// Player attack function
	public void Attack ()
	{
		_shootKey = Input.GetKeyDown (KeyCode.Z);

		// Check if the player press the button.
		if (_shootKey)
		{
			IgnoreCollision();
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
		var bulletBody = GetComponent<Collider2D> ();
		var myCollider = GetComponent<Collider2D> ();
		Physics2D.IgnoreCollision (bulletBody, myCollider);
	}


	//Check if the player is grounded
	private void CheckIfGrounded()
	{
		_grounded = Physics2D.OverlapCircle(GroundCheck.position, _checkGroundRadius, GroundMask);
		MyAnimator.SetBool ("isGrounded", _grounded);

		//Set the animation to fallow the y speed of the character while in the air.
		MyAnimator.SetFloat("VerticalSpeed", _myBody2D.velocity.y);
	}
}