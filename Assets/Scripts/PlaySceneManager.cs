using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System;
using static UnityEngine.Rendering.VolumeComponent;

public class PlaySceneManager : MonoBehaviour
{
    public Vector3 largeScale;

    public GameObject playerCard,enemyCard;
    public List<GameObject> playerCards;
    public List<GameObject> enemyCards;
    public List<CardScriptableObject> cardInfos;

    private GameObject selectCard,enemySelectCard;
    private int cardIndex;
    private void Start()
    {
        SetPlayerCardList();
        SetEnemyCardList();
    }
    private void Update()
    {
        ClickCard();
    }


    //生成卡牌列
    public void SetPlayerCardList()
    {
        for(int i = 0; i< 3; i++)
        {
            playerCards.Add(Instantiate(playerCard,new Vector3(-7f,-5f,0),Quaternion.identity)); 

        }
        for(int i = 0; i< playerCards.Count; i++)
        {
            playerCards[i].transform.DOMove(playerCards[i].transform.position + i *new Vector3(1f,0,0), 2f);
        }
    }

    public void SetEnemyCardList()
    {
        for (int i = 0; i < 3; i++)
        {
            enemyCards.Add(Instantiate(enemyCard, new Vector3(7f, 5f, 0), Quaternion.identity));

        }
        for (int i = 0; i < enemyCards.Count; i++)
        {
            enemyCards[i].transform.DOMove(enemyCards[i].transform.position - i * new Vector3(1f, 0, 0), 2f);
        }
    }

    //生成玩家的随机卡牌数据及碰撞体
    public void SetPlayerCard(GameObject card)
    {
        //生成范围在（0~卡牌数组长度）随机数
        cardIndex = UnityEngine.Random.Range(0, cardInfos.Count);
        //为卡牌赋值
        card.GetComponent<Card>().cardSO = cardInfos[cardIndex];
        //设置卡面
        card.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = cardInfos[cardIndex].CardFront;
        //添加碰撞体
        var coll = card.transform.Find("Back").AddComponent<BoxCollider>();
        coll.size =  new Vector3(5,5,0);
        coll.center = new Vector3(0, 0,0);//TODO：计算精确位置

        card.GetComponent<BoxCollider>().enabled = true;
        Destroy(card.GetComponent<SelectCard>());

        selectCard = card;
    }
    //生成敌人的随机卡牌数据及碰撞体
    public void SetEnemyCard(GameObject card)
    {
        //生成范围在（0~卡牌数组长度）随机数
        int enemycardIndex = UnityEngine.Random.Range(0, cardInfos.Count);
        if(enemycardIndex == cardIndex)
        {
            enemycardIndex = UnityEngine.Random.Range(0, cardInfos.Count);
        }
        //为卡牌赋值
        card.GetComponent<Card>().cardSO = cardInfos[enemycardIndex];
        //设置卡面
        card.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = cardInfos[enemycardIndex].CardFront;

        enemySelectCard = card;
    }

    //点击选择的卡牌
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
                
                if (hit.collider != null)
                {

                    if (hit.collider.tag == "Card")
                    {
                        hit.transform.DOMove(Vector3.zero,1f);
                        hit.transform.DOScale(Vector3.one * 0.9f, 0.5f);

                        foreach (var item in playerCards)
                        {
                            item.GetComponent<BoxCollider>().enabled = false;
                        }
                        SetPlayerCard(hit.transform.gameObject);

                        GameStateController.instance.fsm.SwitchState("GuessState");
                    }
                }
            }
        }
    }

    //按钮方法---比较卡牌点数大小
    public void CompareCardValue()
    {
        int enemyIndex = UnityEngine.Random.Range(0,enemyCards.Count);

        SetEnemyCard(enemyCards[enemyIndex]);

        int enemyValue = enemySelectCard.GetComponent<Card>().cardSO.CardValue;
        int playValue = selectCard.GetComponent<Card>().cardSO.CardValue;

        selectCard.transform.DOMove(new Vector3(2.5f,0,0),2f);
        selectCard.transform.DORotate(new Vector3(0,180,0),1f);

        enemySelectCard.transform.DOMove(new Vector3(-2.5f, 0, 0), 2f);
        enemySelectCard.transform.DORotate(new Vector3(0, -180, 0), 1f);

        if (enemyValue > playValue)
            Debug.Log("Lose");
        else if (enemyValue < playValue)
            Debug.Log("Success");
    }

    public void TakeAnotherCard()
    {
        selectCard.transform.DOMove(new Vector3(0, -10f, 0), 3f).OnComplete(
            () =>
            {
                for(int i = 0; i < playerCards.Count; i++)
                {
                    Destroy(playerCards[i].gameObject);
                }
                playerCards.Clear();
                SetPlayerCardList();
            }
            );
    }
}
