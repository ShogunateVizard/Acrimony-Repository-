using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    protected Animator myAnimator { get; set; }
    private BulletDestroyer _destroyerOfBullet;
    private Rigidbody2D _myBody2D;
    protected float movementSpeed;
    protected bool facingRight;

    //Needed component for the weapon
    public GameObject Bullet;
    public Transform WeaponBarrel;
    private bool Attack { get; set; }

    // Use this for initialization
   public virtual void Start () {
        Debug.Log("CharStart");
        myAnimator = gameObject.GetComponent<Animator>();
        facingRight = true;
    }

	// Update is called once per frame
	void Update () {

	}

    // Change the facing direction of the player.
    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);

    }

    public void Shootbullet(int value)
    {

        if (facingRight)
        {
            myAnimator.SetBool("Attacking", true);
            Instantiate(Bullet, WeaponBarrel.transform.position, Quaternion.identity);
        }
        else
        {
            myAnimator.SetBool("Attacking", false);
        }
    }


}
