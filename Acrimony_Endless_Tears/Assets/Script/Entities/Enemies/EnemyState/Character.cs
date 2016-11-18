using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public Animator myAnimator { get; set; }
    private BulletDestroyer _destroyerOfBullet;
    private Rigidbody2D _myBody2D;
    public float movementSpeed;
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
    //SuperClass Movement
    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.y * -1, 1, 1);

    }
    //SuperClass Attack 
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


