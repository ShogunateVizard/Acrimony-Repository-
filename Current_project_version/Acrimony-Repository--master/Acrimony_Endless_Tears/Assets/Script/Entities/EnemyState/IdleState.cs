using UnityEngine;
using System.Collections;
using System;

public class IdleState : IEnemyState {

    private Enemy enemy;

    private float idelTimer;

    private float idleDuration = 3f;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("I'am Idle");

        Idle();
        if (enemy.Target != null)
            {
            enemy.ChangeState(new PatrolState());
            }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    private void Idle()
    {
        enemy.myAnimator.SetFloat("speed", 0);

        idelTimer += Time.deltaTime;

        if (idelTimer >= idleDuration)
        {
            enemy.ChangeState(new PatrolState());

        }
    }


}
