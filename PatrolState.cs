using UnityEngine;
using System.Collections;
using System;

public class PatrolState : IEnemyState {
    private Enemy enemy;
    private float PatrolTimer;

    //anmount of time for this state 
    private float PatrolDuration = 5f;



    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }
    //Starts the Patrol calling "Move" funtcion 
    public void Execute()
    {
        Debug.Log("Patrolling");
        Patrol();

        enemy.Move();
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Edge")
        {
            enemy.ChangeDirection();
        }
    }
    //Change from patrol to idle after a set time 
    private void Patrol()
    {
        

        PatrolTimer += Time.deltaTime;

        if (PatrolTimer >= PatrolDuration)
        {
            enemy.ChangeState(new IdleState());

        }
    }


}
