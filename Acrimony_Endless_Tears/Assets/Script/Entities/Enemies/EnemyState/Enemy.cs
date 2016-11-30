using UnityEngine;
using System.Collections;

public class Enemy : Character 
{ 

    private IEnemyState _currentState;
	
    // Use this for initialization
	public override void Start ()
    {
        base.Start();
        ChangeState(new IdleState());
	}
	
	// Update is called once per frame
	void Update ()
    {
        _currentState.Execute();
	}

    public void ChangeState(IEnemyState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();

        }
        _currentState = newState;

        _currentState.Enter(this);
    }

    public void Move()
    {
        MyAnimator.SetFloat("Speed", 1);
        transform.Translate(GetDiretion() * (MovementSpeed * Time.deltaTime));
    }

    public Vector2 GetDiretion()
    {
        return FacingRight ? Vector2.right : Vector2.left;
    }

}
