using JetBrains.Annotations;
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
        controller.playManager.gameObject.SetActive(true);
        controller.PlayPanel.SetActive(true);

    }
    public void UpdateState()
    {
        
    }

    public void ExitState()
    {
        
    }
}
