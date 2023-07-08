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

        //计时器初始化
        time = controller.maxTime;
        controller.sliderImg.color = Color.green;
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

        //缩短进度条
        controller.countDownSlider.value = time / controller.maxTime;
        //更改颜色
        controller.sliderImg.DOColor(Color.red, controller.maxTime).OnComplete(
            () =>
            {
                //TODO:判断是否作弊
                controller.fsm.SwitchState("CompeteState");
            }
            );
    }
}
