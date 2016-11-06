using System.Runtime.Remoting.Channels;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerBullet : MonoBehaviour
{

	//private Player player;
    private float Speed;
    private Rigidbody2D _mybody;

    // Run once
    void Start()
    {
        _mybody = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
		MoveBullet();
    }


	//Have the bullet move in space
    private void MoveBullet()
    {
		Speed = 5;
		float dirX = Input.GetAxisRaw("Horizontal");
		float dirY = Input.GetAxis("Vertical");

		_mybody.velocity = new Vector2(dirX * Speed, dirY);	
		print("Bullet Appeared");	
    }

	
}