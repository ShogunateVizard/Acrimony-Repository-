using UnityEngine;
using System.Collections;
using System;

public class IdleState : IEnemyState {

    private Enemy _enemy;

    private float _idelTimer;

    private float _idleDuration = 5f;

    public void Enter(Enemy enemy)
    {
        this._enemy = enemy;
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

    private void Idle()
    {
        _enemy.MyAnimator.SetFloat("Speed", 0);

        _idelTimer += Time.deltaTime;

        if (_idelTimer >= _idleDuration)
        {
            _enemy.ChangeState(new PatrolState());

        }
    }


}
