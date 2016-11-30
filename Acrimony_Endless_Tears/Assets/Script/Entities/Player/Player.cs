using UnityEngine;

public class Player: Humenoid
{
	public bool JumpButton;

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
		MyBody2D = gameObject.GetComponent<Rigidbody2D> ();
		MyAnimator = gameObject.GetComponent<Animator> ();

		//Player speed and bool check
		MySpeed = 5;
		Grounded = false;
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
		MyDirection = Input.GetAxisRaw ("Horizontal");
		var mySpeed = MyDirection * MySpeed;

		// Movement
		MyBody2D.velocity = new Vector2 (mySpeed, MyBody2D.velocity.y);
		MyAnimator.SetFloat ("Speed", Mathf.Abs (mySpeed));
		Rotate (MyDirection);
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
		// Check if I am grounded and if the player have pressed the jump button
		if (Grounded && jumpButton > 0)
		{
			Grounded = false;
			MyAnimator.SetBool("isGrounded", Grounded);	
			MyBody2D.AddForce(new Vector2(0, JumpHeight));
		}
		else
		{
			Grounded = true;
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
		Grounded = Physics2D.OverlapCircle(GroundCheck.position, CheckGroundRadius, GroundMask);
		MyAnimator.SetBool ("isGrounded", Grounded);

		//Set the animation to fallow the y-axis speed of the character while in the air.
		MyAnimator.SetFloat("VerticalSpeed", MyBody2D.velocity.y);
	}
}