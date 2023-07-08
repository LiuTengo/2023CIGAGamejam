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

    // 定义三个事件，用来定义不同行为的不同相应
    public event Action<Collider> OnRayEnter;
    public event Action<Collider> OnRayStay;
    public event Action<Collider> OnRayExit;
    // 用来保存上一个射线扫到的物体
    Collider previousCollider;

    private void Start()
    {
        SetCardList();
        
    }
    private void Update()
    {
        ClickCard();
    }


    //生成卡牌列
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

    //生成随机卡牌及碰撞体
    public void SetCard()
    {
        //生成范围在（0~卡牌数组长度）随机数
        int cardIndex = UnityEngine.Random.Range(0, cards.Count+1);
        CardScriptableObject cardSO = cards[cardIndex].GetComponent<CardScriptableObject>();
        Instantiate(cards[cardIndex]);

        //添加碰撞体
        var coll = cards[cardIndex].AddComponent<BoxCollider>();
        coll.size =  new Vector3(80,80,0);
        coll.center = new Vector3(cardSO.CardSuit * 20f, cardSO.CardValue * 20f,0);//TODO：计算精确位置
    }

    public void SelectCard()
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
                    if (hit.collider.tag == "Card")
                    {
                        hit.transform.DOMove(-1*Vector3.forward, 1f);
                        hit.transform.DOScale(largeScale, 1f);
                    }
                }
            }
    }

    //选择卡牌
    public void ClickCard()
    {
        if (Input.GetMouseButtonDown(0))
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
