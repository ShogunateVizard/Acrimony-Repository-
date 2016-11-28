using UnityEngine;
using System.Collections;

public class Humenoid: MonoBehaviour
{
	//Humanoid characteristics
	protected float _mySpeed;
	protected int AttackPower;
	protected int Health;
	public float _myDirection;
	public bool _jumping;
	public bool _grounded;
	public float _checkGroundRadius;

	//Needed Components
	public Transform GroundCheck;
	public Animator MyAnimator;
	public Rigidbody2D _myBody2D;


	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
