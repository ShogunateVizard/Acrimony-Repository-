using UnityEngine;
using System.Collections;

public class Enemy : Character 
{ 

    private IEnemyState currentState;
    Character myCharacter;
	
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
	}
    //Checking selfState 
    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();

        }
        currentState = newState;

        currentState.Enter(this);
    }
    //Movement Speed 
    public void Move()
    {
        myAnimator.SetFloat("speed", 1);
        transform.Translate(GetDiretion() * (movementSpeed * Time.deltaTime));
    }
    //Facing Right goes right
    public Vector2 GetDiretion()
    {
        return facingRight ? Vector2.right : Vector2.left;
        
    }
    //Calling OnTriggerEnter 
    public void OnTriggerEnter2D(Collider2D other)
    {
		base.OnTriggerEnter2D (other);
        currentState.OnTriggerEnter(other);
    }

	//Set Damage and check if enemy is dead

	public IEnumerator TakeDamage ()
	{
		Health -= 10; 

		if (!IsDead) 
		{
			myAnimator.SetTrigger ("damage");
		} else 
		
		{
			myAnimator.SetTrigger ("die");
			yield return null; 
		}

	}
	//When Health reaches zero
	public static bool IsDead {
		get {
			return Health <= 0; 
		}
	}

}
