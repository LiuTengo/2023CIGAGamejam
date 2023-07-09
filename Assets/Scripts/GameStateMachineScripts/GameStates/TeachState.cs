using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeachState : IGameState
{
    public GameStateController controller;

    public TeachState(GameStateController controller)
    {
        this.controller = controller;
    }

    //进入状态时调用
    public void EnterState()
    {
        controller.playManager.gameObject.SetActive(false);

        controller.TeachPanel.SetActive(true);
        controller.TeachPanelButton.SetActive(true);
        controller.StartPanel.SetActive(false);

    }

    //处于当前状态时每帧调用
    public void UpdateState()
    {
        
    }

    //结束当前状态时调用
    public void ExitState()
    {
        controller.TeachPanel.SetActive(false);
        controller.TeachPanelButton.SetActive(false);
    }
}
