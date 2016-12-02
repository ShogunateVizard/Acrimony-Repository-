using UnityEngine;
using System.Collections;

public class Enemy : Character 
{ 

    private IEnemyState currentState;

    public GameObject Target { get; set; }
	
    // Use this for initialization
	void Start ()
    {
        base.Start();
        ChangeState(new IdleState());
	}

   
	
	// Update is called once per frame
	void Update ()
    {
        currentState.Execute();
        LookAtTarget(); 
	}
    
    //When Player Enters sight

    private void LookAtTarget()
    {

        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

             
            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }


        }

    }

    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();

        }
        currentState = newState;

        currentState.Enter(this);
    }

    public void Move()
    {
        myAnimator.SetFloat("speed", 1);
        transform.Translate(GetDiretion() * (movementSpeed * Time.deltaTime));
    }

    public Vector2 GetDiretion()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState
    }
}
