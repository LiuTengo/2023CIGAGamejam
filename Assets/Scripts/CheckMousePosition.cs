using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CheckMousePosition : MonoBehaviour, IPointerMoveHandler
{
    //TODO：在卡牌对应位置生成collider

    //鼠标在卡牌上移动时
    public void OnPointerMove(PointerEventData eventData)
    {
        //从鼠标位置上发出射线
        Ray rayCast = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit hit;
        //判断返回的射线信息
        if (Physics.Raycast(rayCast,out hit))
        {
            //有碰撞体则震动卡牌
            if(hit.collider != null)
            {
                Debug.Log(true);
                transform.DOShakePosition(2f, 5f);
            }
        }
    }
}
