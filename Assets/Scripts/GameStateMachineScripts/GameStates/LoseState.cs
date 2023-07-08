using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : IGameState
{
    public GameStateController controller;
    public LoseState(GameStateController controller)
    {
        this.controller = controller;
    }
    public void EnterState()
    {
        controller.LosePanel.SetActive(true);
    }
    public void UpdateState()
    {
        
    }
    public void ExitState()
    {
        controller.LosePanel.SetActive(false);
    }


}
