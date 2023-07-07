using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CheckMousePosition : MonoBehaviour, IPointerMoveHandler
{
    //TODO���ڿ��ƶ�Ӧλ������collider

    //����ڿ������ƶ�ʱ
    public void OnPointerMove(PointerEventData eventData)
    {
        //�����λ���Ϸ�������
        Ray rayCast = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit hit;
        //�жϷ��ص�������Ϣ
        if (Physics.Raycast(rayCast,out hit))
        {
            //����ײ�����𶯿���
            if(hit.collider != null)
            {
                Debug.Log(true);
                transform.DOShakePosition(2f, 5f);
            }
        }
    }
}
