using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            if (controller.countDownSlider.value >= 0.8)
            {
                HeadAndTextSpritesManager.instance.GetSpriteToArea("e2", HeadAndTextSpritesManager.instance.targetSpriteEnemy, 1);//2--player
            }
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
                    else if(Input.GetMouseButton(0))
                    {
                        if (hit.collider.tag == "Card" && GameStateController.instance.fsm.currentState == GameStateController.instance.fsm.states["GuessState"])
                        {
                            GameStateController.instance.fsm.SwitchState("CheatState");
                        }
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
