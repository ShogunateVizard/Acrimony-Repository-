using UnityEngine;
using System.Collections;

public class Enemy : Character 
{ 

    private IEnemyState currentState;
	
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

}
