using UnityEngine;

public class EnemyState: MonoBehaviour
{
    protected Enemy _enemy;
    protected EnemyStateMachine _enemyStateMachine;

    public EnemyState(Enemy _enemy, EnemyStateMachine _enemyStateMachine)
    {
        this._enemy = _enemy;
        this._enemyStateMachine = _enemyStateMachine;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void FrameUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
    }
}