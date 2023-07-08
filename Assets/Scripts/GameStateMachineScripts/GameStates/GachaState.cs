using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaState : IGameState
{
    public GameStateController controller;
    public GachaState(GameStateController controller)
    {
        this.controller = controller;
    }

    public void EnterState()
    {
        Debug.Log("Enter GachaState");
    }
    public void UpdateState()
    {
        
    }

    public void ExitState()
    {
        
    }

   
}
