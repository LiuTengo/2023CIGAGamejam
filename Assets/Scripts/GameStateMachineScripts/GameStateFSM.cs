using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateFSM
{
    public Dictionary<string, IGameState> states;

    public IGameState currentState;

    public GameStateFSM()
    {
        this.states = new Dictionary<string, IGameState>();
    }

    //�л�״̬
    public void SwitchState(string type)
    {
        if (!states.ContainsKey(type))
        {
            return; //������type����
        }
        if (currentState != null)
        {
            currentState.ExitState();
        }
        currentState = states[type];
        currentState.EnterState();
    }

    //���״̬
    public void AddNewState(string type, IGameState state)
    {
        if (states.ContainsKey(type))
        {
            return; //�Ѵ��ڸ�״̬
        }
        states.Add(type, state);
    }

    //ִ��״̬
    public void OnUpdate()
    {
        currentState.UpdateState();
    }
}
