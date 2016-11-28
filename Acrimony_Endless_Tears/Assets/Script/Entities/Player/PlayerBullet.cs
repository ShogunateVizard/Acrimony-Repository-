
using System;
using System.Runtime.Remoting.Channels;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine;

public class PlayerBullet: MonoBehaviour
{

	private float Speed;
	private Rigidbody2D _mybody;

	//Explosion prefab
	public GameObject Explosion;

	// Run once

	private void Awake ()
	{

	}

	private void Update ()
	{
		_mybody = GetComponent<Rigidbody2D> ();
		Speed = 5f;
		MoveBullet();
	}

	//Have the bullet move in space
	public void MoveBullet ()
	{
		_mybody.AddForce(new Vector2(1, 0) * Speed, ForceMode2D.Impulse);
	}


	//Check collision with other objects
	private void OnTriggerEnter2D (Collider2D other)
	{
		//Destroy this game object
		Destroy (gameObject);

		//Instantiate the explosion
		GameObject explosionCopy = Instantiate (Explosion, transform.position, Quaternion.identity)
			as GameObject;

		//Destroy the explosion prefab after the animation has ended.
		if (explosionCopy.activeInHierarchy)
		{
			var timer = .5f;
			Destroy (explosionCopy, timer);
		}
	}
}