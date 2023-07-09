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

    //����״̬ʱ����
    public void EnterState()
    {
        controller.playManager.gameObject.SetActive(false);

        controller.TeachPanel.SetActive(true);
        controller.TeachPanelButton.SetActive(true);
        controller.StartPanel.SetActive(false);

    }

    //���ڵ�ǰ״̬ʱÿ֡����
    public void UpdateState()
    {
        
    }

    //������ǰ״̬ʱ����
    public void ExitState()
    {
        controller.TeachPanel.SetActive(false);
        controller.TeachPanelButton.SetActive(false);
    }
}
