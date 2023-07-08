using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessState : IGameState
{
    private float time;
    private Color color = Color.green;
    private bool compare = false;

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
        controller.sliderImg.color = color;
    }
    public void UpdateState()
    {
        TimeCountDown();
    }

    public void ExitState()
    {
        controller.maxTime = time;
        color = controller.sliderImg.color;

        controller.GuessPanel.SetActive(false) ;
    }

    public void TimeCountDown()
    {
        if (time > 0)
            time -= Time.deltaTime;

        //缩短进度条
        controller.countDownSlider.value = time / controller.originMaxTime;
        //更改颜色
        //FIXME:不用改颜色
        controller.sliderImg.DOColor(Color.red, controller.maxTime).OnComplete(
            () =>
            {
                compare = true;
            }
            );

        if (compare)
        {
            //TODO:判断是否作弊
            //从鼠标位置上发出射线
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //判断返回的射线信息
            if (Physics.Raycast(rayCast, out hit))
            {
                //鼠标停留在卡牌上则算作弊
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Card")
                    {
                        Debug.Log("Cheat");
                    }
                }
            }
            //鼠标未停留在卡牌上开始比较
            else
            {
                controller.playManager.CompareCardValue();
            }
        }
    }
}
