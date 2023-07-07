using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IGameState
{
    public GameStateController controller;

    public PauseState(GameStateController controller)
    {
        this.controller = controller;
    }

    public void EnterState()
    {
        Time.timeScale = 0f;//暂停游戏
        controller.PausePanel.SetActive(true);
    }

    public void UpdateState()
    {
        //切换回游戏状态
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controller.fsm.SwitchState("PlayState");
        }
    }

    public void ExitState()
    {
        Time.timeScale = 1f; //继续游戏
        controller.PausePanel.SetActive(false);//关闭暂定面板
    }
}
