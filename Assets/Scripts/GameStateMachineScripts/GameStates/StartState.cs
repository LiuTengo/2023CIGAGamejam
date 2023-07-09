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

    //����״̬ʱ����
    public void EnterState()
    {
        controller.StartPanel.SetActive(true);
        controller.playManager.gameObject.SetActive(false);
        //SceneManager.LoadScene("SampleStartScene");
        //Debug.Log("Enter StartState");
    }

    //���ڵ�ǰ״̬ʱÿ֡����
    public void UpdateState()
    {
       //Debug.Log("Update StartState");
    }

    //������ǰ״̬ʱ����
    public void ExitState()
    {

    }
}
