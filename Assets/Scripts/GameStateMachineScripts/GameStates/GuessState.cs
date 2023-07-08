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

        //��ʱ����ʼ��
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

        //���̽�����
        controller.countDownSlider.value = time / controller.originMaxTime;
        //������ɫ
        //FIXME:���ø���ɫ
        controller.sliderImg.DOColor(Color.red, controller.maxTime).OnComplete(
            () =>
            {
                compare = true;
            }
            );

        if (compare)
        {
            //TODO:�ж��Ƿ�����
            //�����λ���Ϸ�������
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //�жϷ��ص�������Ϣ
            if (Physics.Raycast(rayCast, out hit))
            {
                //���ͣ���ڿ�������������
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Card")
                    {
                        Debug.Log("Cheat");
                    }
                }
            }
            //���δͣ���ڿ����Ͽ�ʼ�Ƚ�
            else
            {
                controller.playManager.CompareCardValue();
            }
        }
    }
}
