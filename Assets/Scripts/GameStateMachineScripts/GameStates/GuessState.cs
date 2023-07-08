using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessState : IGameState
{
    private float time;

    public GameStateController controller;
    public GuessState(GameStateController controller)
    {
        this.controller = controller;
    }
    public void EnterState()
    {
        controller.GuessPanel.SetActive(true);

        //��ʱ����ʼ��
        if (1 - (time / controller.originMaxTime) > 1)
            time = controller.originMaxTime;
        else
            time = controller.maxTime;
    }
    public void UpdateState()
    {
        TimeCountDown();
    }

    public void ExitState()
    {
        controller.maxTime = time;

        controller.GuessPanel.SetActive(false) ;
    }

    public void TimeCountDown()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            //����������
            controller.countDownSlider.value = 1-(time / controller.originMaxTime);
        }
        else
        {
            //�����λ���Ϸ�������
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //�жϷ��ص�������Ϣ
            if (Physics.Raycast(rayCast, out hit))
            {
                //���ͣ���ڿ�������������
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Card" && GameStateController.instance.fsm.currentState == GameStateController.instance.fsm.states["GuessState"])
                    {
                        GameStateController.instance.fsm.SwitchState("CheatState");
                    }
                    else
                    {                        
                        GameStateController.instance.fsm.SwitchState("GachaState");
                        controller.playManager.CompareCardValue();

                    }
                }
            }
            //���δͣ���ڿ����Ͽ�ʼ�Ƚ�
            else
            {                
                GameStateController.instance.fsm.SwitchState("GachaState");
                controller.playManager.CompareCardValue();

            }
        }

    }
}
