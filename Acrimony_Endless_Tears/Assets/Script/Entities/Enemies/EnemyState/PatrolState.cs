using UnityEngine;
using System.Collections;
using System;

public class PatrolState : IEnemyState {
    private Enemy _enemy;
    private float _patrolTimer;
    private float _patrolDuration = 2f;



    public void Enter(Enemy enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("Patrolling");
        Patrol();

        _enemy.Move();
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    private void Patrol()
    {
        

        _patrolTimer += Time.deltaTime;

        if (_patrolTimer >= _patrolDuration)
        {
            _enemy.ChangeState(new IdleState());

        }
    }


}
