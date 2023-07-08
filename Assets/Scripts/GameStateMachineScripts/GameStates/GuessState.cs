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
        //��ʱ����ʼ��
        time = controller.maxTime;
        controller.sliderImg.color = Color.green;

        //���Ƴ�ʼ��
        controller.playManager.SetCard();
    }
    public void UpdateState()
    {
        TimeCountDown();
    }

    public void ExitState()
    {

        
    }



    public void TimeCountDown()
    {
        if (time > 0)
            time -= Time.deltaTime;

        //���̽�����
        controller.countDownSlider.value = time / controller.maxTime;
        //������ɫ
        controller.sliderImg.DOColor(Color.red, controller.maxTime).OnComplete(
            () =>
            {
                //TODO:�ж��Ƿ�����
                controller.fsm.SwitchState("CompeteState");
            }
            );
    }
}
