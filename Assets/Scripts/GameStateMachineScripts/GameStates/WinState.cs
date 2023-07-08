using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : IGameState
{
    public GameStateController controller;
    public WinState(GameStateController controller)
    {
        this.controller = controller;
    }
    public void EnterState()
    {
        controller.WinPanel.SetActive(true);
    }

    public void ExitState()
    {
        
    }

    public void UpdateState()
    {
        controller.WinPanel.SetActive(false);
    }
}
