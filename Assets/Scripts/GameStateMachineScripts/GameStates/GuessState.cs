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

        //计时器初始化
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
            //增长进度条
            controller.countDownSlider.value = 1-(time / controller.originMaxTime);
            if (controller.countDownSlider.value >= 0.8)
            {
                HeadAndTextSpritesManager.instance.GetSpriteToArea("e2", HeadAndTextSpritesManager.instance.targetSpriteEnemy, 1);//2--player
            }
        }
        else
        {
            //从鼠标位置上发出射线
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //判断返回的射线信息
            if (Physics.Raycast(rayCast, out hit))
            {
                //鼠标停留在卡牌上则算作弊
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
            //鼠标未停留在卡牌上开始比较
            else
            {                
                GameStateController.instance.fsm.SwitchState("GachaState");
                controller.playManager.CompareCardValue();

            }
        }

    }
}
