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

    //切换状态
    public void SwitchState(string type)
    {
        if (!states.ContainsKey(type))
        {
            return; //不存在type类型
        }
        if (currentState != null)
        {
            currentState.ExitState();
        }
        currentState = states[type];
        currentState.EnterState();
    }

    //添加状态
    public void AddNewState(string type, IGameState state)
    {
        if (states.ContainsKey(type))
        {
            return; //已存在该状态
        }
        states.Add(type, state);
    }

    //执行状态
    public void OnUpdate()
    {
        currentState.UpdateState();
    }
}
