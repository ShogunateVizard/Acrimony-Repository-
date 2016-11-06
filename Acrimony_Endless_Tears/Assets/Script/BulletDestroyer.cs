using UnityEngine;
using System.Collections;

public class BulletDestroyer: MonoBehaviour
{
	public void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.tag == "Bullet")
		{
			Destroy(collision.gameObject);
		}
	}
}
