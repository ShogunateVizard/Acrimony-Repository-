using UnityEngine;
using System.Collections;

public class BulletDestroyer: MonoBehaviour
{
	//Timer for the live of the bullet
	private float _bulletTimer;

	private void Awake()
	{
		_bulletTimer = 2;
		Destroy(gameObject, _bulletTimer);	
	}
}
