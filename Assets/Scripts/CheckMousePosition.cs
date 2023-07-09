using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CheckMousePosition : MonoBehaviour
{
    public float minSpeed;

    void Start()
    {
        
    }

    private void Update()
    {
        float mouseXSpeed = Mathf.Abs(Input.GetAxis("Mouse X"));
        float mouseYSpeed = Mathf.Abs(Input.GetAxis("Mouse Y"));

        if (Input.GetMouseButton(0))
        {
        //从鼠标位置上发出射线
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //判断返回的射线信息
        if (Physics.Raycast(rayCast, out hit))
        {
            //有碰撞体则震动卡牌
            if (hit.collider != null)
            {
                if(Mathf.Sqrt(mouseXSpeed * mouseXSpeed + mouseYSpeed * mouseYSpeed) < minSpeed)
                {

                        if (hit.collider.tag == "GuessCard")
                        {
                            hit.transform.parent.DOScale(transform.localScale *0.92f,0.1f).SetLoops(4,LoopType.Yoyo);

                        }
                }
                
            }
        }
        }

    }
}
