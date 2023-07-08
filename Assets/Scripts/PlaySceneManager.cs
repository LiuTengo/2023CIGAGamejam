using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System;
using static UnityEngine.Rendering.VolumeComponent;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PlaySceneManager : MonoBehaviour
{
    public Vector3 largeScale;

    public GameObject playerCard,enemyCard;
    public List<GameObject> playerCards;
    public List<GameObject> enemyCards;
    public List<CardScriptableObject> cardInfos;

    private GameObject selectCard,enemySelectCard;
    private int cardIndex;
    private bool selectable;
    private void Start()
    {
        selectable = false;
        SetPlayerCardList();
        SetEnemyCardList();
    }
    private void Update()
    {
        if(selectable)
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
            playerCards[i].transform.DOMove(playerCards[i].transform.position + i *new Vector3(1f,0,0), 2f).OnComplete(
                () =>
                {
                    selectable = true;
                }
                );
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
        GenerateCollider(cardInfos[cardIndex].CardValue, card);

        card.GetComponent<BoxCollider>().enabled = true;
        Destroy(card.GetComponent<SelectCard>());

        selectCard = card;
    }
    //生成敌人的随机卡牌数据
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
        if (Input.GetMouseButtonDown(0) && GameStateController.instance.fsm.currentState == GameStateController.instance.fsm.states["GachaState"])
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
                        hit.transform.DOScale(Vector3.one, 0.5f);

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
        selectCard.transform.DOScale(Vector3.one,1f);
        selectCard.transform.DORotate(new Vector3(0,180,0),1f);

        enemySelectCard.transform.DOMove(new Vector3(-2.5f, 0, 0), 2f);
        enemySelectCard.transform.DOScale(Vector3.one, 1f);
        enemySelectCard.transform.DORotate(new Vector3(0, -180, 0), 1f);

        if (enemyValue > playValue)
        {
            GameStateController.instance.fsm.SwitchState("LoseState");
        }
        else if (enemyValue < playValue)
        {
            GameStateController.instance.fsm.SwitchState("WinState");
        }
        else
        {
            GameStateController.instance.fsm.SwitchState("GachaState");
        }
    }

    public void TakeAnotherCard()
    {
        GameStateController.instance.fsm.SwitchState("GachaState");
        selectCard.transform.DOMove(new Vector3(0, -9f, 0), 2f).OnComplete(
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

    //生成碰撞体
    public void GenerateCollider(int value,GameObject card)
    {
        switch (value)
        {
            case 1:
                BoxCollider coll11 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll11.size = new Vector3(2, 2, 0);
                coll11.center = new Vector3(0, 0, 0);
                break;
            case 2:
                BoxCollider coll21 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll21.size = new Vector3(2, 2, 0);
                coll21.center = new Vector3(-2.5f, 0, 0);
                BoxCollider coll22 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll22.size = new Vector3(2, 2, 0);
                coll22.center = new Vector3(2.5f, 0, 0);
                break;
            case 3:
                BoxCollider coll31 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll31.size = new Vector3(2, 2, 0);
                coll31.center = new Vector3(-2.5f,5f, 0);
                BoxCollider coll32 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll32.size = new Vector3(2, 2, 0);
                coll32.center = new Vector3(0, 0, 0);
                BoxCollider coll33 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll33.size = new Vector3(2, 2, 0);
                coll33.center = new Vector3(-2.5f, -5f, 0);
                break;
            case 4:
                BoxCollider coll41 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll41.size = new Vector3(2, 2, 0);
                coll41.center = new Vector3(-2.5f, 5f, 0);
                BoxCollider coll42 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll42.size = new Vector3(2, 2, 0);
                coll42.center = new Vector3(2.5f,5f, 0);
                BoxCollider coll43 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll43.size = new Vector3(2, 2, 0);
                coll43.center = new Vector3(-2.5f, -5f, 0);
                BoxCollider coll44 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll44.size = new Vector3(2, 2, 0);
                coll44.center = new Vector3(2.5f, -5f, 0);
                break;
            case 5:
                BoxCollider coll51 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll51.size = new Vector3(2, 2, 0);
                coll51.center = new Vector3(-2.5f, 5f, 0);
                BoxCollider coll52 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll52.size = new Vector3(2, 2, 0);
                coll52.center = new Vector3(2.5f, 5f, 0);
                BoxCollider coll53 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll53.size = new Vector3(2, 2, 0);
                coll53.center = new Vector3(-2.5f, -5f, 0);
                BoxCollider coll54 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll54.size = new Vector3(2, 2, 0);
                coll54.center = new Vector3(2.5f, -5f, 0);
                BoxCollider coll55 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll55.size = new Vector3(2, 2, 0);
                coll55.center = new Vector3(0, 0, 0);
                break;
            case 6:
                BoxCollider coll61 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll61.size = new Vector3(2, 2, 0);
                coll61.center = new Vector3(-2.5f, 5f, 0);
                BoxCollider coll62 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll62.size = new Vector3(2, 2, 0);
                coll62.center = new Vector3(2.5f, 5f, 0);
                BoxCollider coll63 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll63.size = new Vector3(2, 2, 0);
                coll63.center = new Vector3(-2.5f, -5f, 0);
                BoxCollider coll64 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll64.size = new Vector3(2, 2, 0);
                coll64.center = new Vector3(2.5f, -5f, 0);
                BoxCollider coll65 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll65.size = new Vector3(2, 2, 0);
                coll65.center = new Vector3(2.5f, 0, 0);
                BoxCollider coll66 = card.transform.Find("Back").AddComponent<BoxCollider>();
                coll66.size = new Vector3(2, 2, 0);
                coll66.center = new Vector3(-2.5f, 0, 0);
                break;
            default:
                break;
        }
    }

}
