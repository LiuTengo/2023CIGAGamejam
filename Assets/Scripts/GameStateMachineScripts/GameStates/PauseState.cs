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
        Time.timeScale = 0f;//��ͣ��Ϸ
        controller.PausePanel.SetActive(true);
    }

    public void UpdateState()
    {
        //�л�����Ϸ״̬
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controller.fsm.SwitchState("PlayState");
        }
    }

    public void ExitState()
    {
        Time.timeScale = 1f; //������Ϸ
        controller.PausePanel.SetActive(false);//�ر��ݶ����
    }
}
