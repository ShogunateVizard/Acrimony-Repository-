using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    public Animator MyAnimator { get; set; }
    protected float MovementSpeed;
    protected bool FacingRight;

    //Needed component for the weapon
    public GameObject Bullet;
    public Transform WeaponBarrel;
    private bool Attack { get; set; }

    // Use this for initialization
    public virtual void Start()
    {
        Debug.Log("CharStart");
        MyAnimator = gameObject.GetComponent<Animator>();
        FacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Change the facing direction of the player.
    public void ChangeDirection()
    {
        FacingRight = !FacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);

    }

    public void Shootbullet(int value)
    {

        if (FacingRight)
        {
            MyAnimator.SetBool("Attacking", true);
            Instantiate(Bullet, WeaponBarrel.transform.position, Quaternion.identity);
        }
        else
        {
            MyAnimator.SetBool("Attacking", false);
        }
    }


}
