using UnityEngine;
using System.Collections;

public class Humenoid: MonoBehaviour
{
	//Humanoid characteristics
	protected float MySpeed;
	protected int AttackPower;
	protected int Health;
	public float MyDirection;
	public bool Jumping;
	public bool Grounded;
	public float CheckGroundRadius;

	//Needed Components
	public Transform GroundCheck;
	public Animator MyAnimator;
	public Rigidbody2D MyBody2D;


	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
