using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatState : IGameState
{
    public GameStateController controller;
    public CheatState(GameStateController controller)
    {
        this.controller = controller;
    }

    public void EnterState()
    {
        controller.CheatPanel.SetActive(true);
    }
    public void UpdateState()
    {
        
    }
    public void ExitState()
    {
        controller.CheatPanel.SetActive(false);
    }
}
