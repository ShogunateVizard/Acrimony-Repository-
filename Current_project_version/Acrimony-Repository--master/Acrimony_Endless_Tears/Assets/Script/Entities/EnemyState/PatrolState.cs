using UnityEngine;
using System.Collections;
using System;

public class PatrolState : IEnemyState {
    private Enemy enemy;
    private float PatrolTimer;
    private float PatrolDuration = 2f;



    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("Patroling");
        Patrol();

        enemy.Move();

        if (enemy.Target != null)
        {
            enemy.ChangeState(new RangedState());
        }
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

    private void Patrol()
    {
        

        PatrolTimer += Time.deltaTime;

        if (PatrolTimer >= PatrolDuration)
        {
            enemy.ChangeState(new IdleState());

        }
    }


}
