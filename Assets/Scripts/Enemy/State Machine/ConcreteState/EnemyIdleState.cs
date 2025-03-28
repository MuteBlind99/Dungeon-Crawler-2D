using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;

    private Coroutine _coroutine;
    private bool _coroutineIsStarted = false;

    public EnemyIdleState(Enemy _enemy, EnemyStateMachine _enemyStateMachine) : base(_enemy, _enemyStateMachine)
    {
    }

    private IEnumerator MoveCoroutine()
    {
        _coroutineIsStarted = true;
        yield return new WaitForSeconds(3f);
       
        _targetPos = GetRandomPointInCircle();
        Debug.Log("New pos: " + _targetPos);
        _coroutineIsStarted = false;
    }

    public override void EnterState()
    {
        base.EnterState();

        _targetPos = GetRandomPointInCircle();
    }


    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        _direction = (_targetPos - _enemy.transform.position).normalized;

        _enemy.MoveEnemy(_direction * _enemy.RandomMovementSpeed);

        if ((_enemy.transform.position - _targetPos).sqrMagnitude > 0.01f)
        {
            if (!_coroutineIsStarted)
            {
                StartCoroutine(MoveCoroutine());
                
            }
            
             
        }

        //Debug.Log(_enemy.transform.position + (Vector3)Random.insideUnitCircle * _enemy.RandomMovementRange);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    private Vector3 GetRandomPointInCircle()
    {
        return _enemy.transform.position + (Vector3)Random.insideUnitCircle * Random.Range(-_enemy.RandomMovementRange,_enemy.RandomMovementRange); ;
    }
}