using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartState : IGameState
{
    public GameStateController controller;

    public StartState(GameStateController controller)
    {
        this.controller = controller;
    }

    //进入状态时调用
    public void EnterState()
    {
        SceneManager.LoadScene("SampleStartScene");

        //Debug.Log("Enter StartState");
    }

    //处于当前状态时每帧调用
    public void UpdateState()
    {
       //Debug.Log("Update StartState");
    }

    //结束当前状态时调用
    public void ExitState()
    {
        controller.StartPanel.SetActive(false);
        //Debug.Log("Exit StartState");
    }
}
