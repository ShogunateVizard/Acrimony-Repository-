using UnityEngine;
using System.Collections;
using System;

public class IdleState : IEnemyState {
    //classing Enemy as enemy
    private Enemy enemy;

    private float idelTimer = 2f;
    
    //Idle set for a amount of time 

    private float idleDuration = 1f;
   
    //Checking for Idle
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("I'am Idle");

        Idle();
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }
    //Change State when timer runs out turns idle
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
