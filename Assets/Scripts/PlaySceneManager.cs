using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System;

public class PlaySceneManager : MonoBehaviour
{
    public Vector3 largeScale;

    public GameObject card;
    public List<GameObject> cards;

    // ���������¼����������岻ͬ��Ϊ�Ĳ�ͬ��Ӧ
    public event Action<Collider> OnRayEnter;
    public event Action<Collider> OnRayStay;
    public event Action<Collider> OnRayExit;
    // ����������һ������ɨ��������
    Collider previousCollider;

    private void Start()
    {
        SetCardList();
        
    }
    private void Update()
    {
        ClickCard();
    }


    //���ɿ�����
    public void SetCardList()
    {
        for(int i = 0; i< 5; i++)
        {
            cards.Add(Instantiate(card,new Vector3(-7,-4f,0),Quaternion.identity));
            cards[i].transform.DOMove(cards[i].transform.position + i * (new Vector3(7, -4f, 0) - new Vector3(0.4f, -4f, 0)) / 5, 2f).OnComplete(
                () =>
                {

                }
                );
        }
    }

    //����������Ƽ���ײ��
    public void SetCard()
    {
        //���ɷ�Χ�ڣ�0~�������鳤�ȣ������
        int cardIndex = UnityEngine.Random.Range(0, cards.Count+1);
        CardScriptableObject cardSO = cards[cardIndex].GetComponent<CardScriptableObject>();
        Instantiate(cards[cardIndex]);

        //�����ײ��
        var coll = cards[cardIndex].AddComponent<BoxCollider>();
        coll.size =  new Vector3(80,80,0);
        coll.center = new Vector3(cardSO.CardSuit * 20f, cardSO.CardValue * 20f,0);//TODO�����㾫ȷλ��
    }

    public void SelectCard()
    {
            //�����λ���Ϸ�������
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //�жϷ��ص�������Ϣ
            if (Physics.Raycast(rayCast, out hit))
            {
                //����ײ�����𶯿���
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Card")
                    {
                        hit.transform.DOMove(-1*Vector3.forward, 1f);
                        hit.transform.DOScale(largeScale, 1f);
                    }
                }
            }
    }

    //ѡ����
    public void ClickCard()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //�����λ���Ϸ�������
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //�жϷ��ص�������Ϣ
            if (Physics.Raycast(rayCast, out hit))
            { 
                //����ײ�����𶯿���
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Card")
                    {
                        //SetCard();
                        hit.transform.DOMove(Vector3.zero,1f);
                        hit.transform.DOScale(largeScale, 1f);
                    }
                }
            }
        }
    }
}
