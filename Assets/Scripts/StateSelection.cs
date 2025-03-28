using System;
using UnityEngine;

public class StateSelection : MonoBehaviour
{
    private Animator animator;
      enum FSM_State
    {
        Empty,
        Idle,
        Chase,
    }
    
    private FSM_State _currentState = FSM_State.Empty;

    private void Start()
    {
        SetState(FSM_State.Idle);
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(_currentState);
        CheckTransitions(_currentState);
        OnStateUpdate(_currentState);
    }

    private void CheckTransitions(FSM_State state)
    {
        switch (state)
        {
            case FSM_State.Idle:
                if (_currentState == FSM_State.Chase)
                {
                    _currentState = FSM_State.Idle;
                }
                break;
            case FSM_State.Chase:
                if (_currentState == FSM_State.Idle)
                {
                    _currentState = FSM_State.Chase;
                }
                break; 
            case FSM_State.Empty:
                
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void OnStateEnter(FSM_State state)
    { 
        switch (state)
        {
            case FSM_State.Idle:
                break;
            case FSM_State.Chase:
                break;
            case FSM_State.Empty:
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    
    private void OnStateExit(FSM_State state)
    {
        switch (state)
        {
            case FSM_State.Idle:
                
                break;
            case FSM_State.Chase:
                break;
            case FSM_State.Empty:
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    
    private void OnStateUpdate(FSM_State state)
    {
        switch (state)
        {
            case FSM_State.Idle:
                animator.SetBool("Idle", true);
                animator.SetBool("Walk",false);
                break;
            case FSM_State.Chase:
                animator.SetBool("Idle",false);
                animator.SetBool("Walk",true);
                break;
            case FSM_State.Empty:
                animator.SetBool("Idle",false);
                animator.SetBool("Walk",false);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    
    private void SetState(FSM_State newState)
    {
        if (newState == FSM_State.Empty) return;
        if (_currentState != FSM_State.Empty) OnStateExit(_currentState);
        
        _currentState = newState;
        
        OnStateEnter(_currentState);
    }
}
