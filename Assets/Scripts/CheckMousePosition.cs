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
        // ��ȡԭʼ�����������
        
    }

    private void Update()
    {
        float mouseXSpeed = Mathf.Abs(Input.GetAxis("Mouse X"));
        float mouseYSpeed = Mathf.Abs(Input.GetAxis("Mouse Y"));

        //�����λ���Ϸ�������
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //�жϷ��ص�������Ϣ
        if (Physics.Raycast(rayCast, out hit))
        {
            //����ײ�����𶯿���
            if (hit.collider != null)
            {
                if (hit.collider.tag == "GuessCard" && Mathf.Sqrt(mouseXSpeed * mouseXSpeed + mouseYSpeed * mouseYSpeed) <minSpeed)
                {
                    Debug.Log(true);
                   hit.transform.parent.DOShakePosition(0.5f,0.6f);
                }
            }
        }
    }

    //����ڿ������ƶ�ʱ
}
