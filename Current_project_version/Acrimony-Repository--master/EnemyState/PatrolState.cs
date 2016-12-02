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
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
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
