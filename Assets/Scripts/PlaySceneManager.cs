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


    //���ɿ�����
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

    //������ҵ�����������ݼ���ײ��
    public void SetPlayerCard(GameObject card)
    {
        //���ɷ�Χ�ڣ�0~�������鳤�ȣ������
        cardIndex = UnityEngine.Random.Range(0, cardInfos.Count);
        //Ϊ���Ƹ�ֵ
        card.GetComponent<Card>().cardSO = cardInfos[cardIndex];
        //���ÿ���
        card.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = cardInfos[cardIndex].CardFront;
        //�����ײ��
        var coll = card.transform.Find("Back").AddComponent<BoxCollider>();
        coll.size =  new Vector3(5,5,0);
        coll.center = new Vector3(0, 0,0);//TODO�����㾫ȷλ��

        card.GetComponent<BoxCollider>().enabled = true;
        Destroy(card.GetComponent<SelectCard>());

        selectCard = card;
    }
    //���ɵ��˵�����������ݼ���ײ��
    public void SetEnemyCard(GameObject card)
    {
        //���ɷ�Χ�ڣ�0~�������鳤�ȣ������
        int enemycardIndex = UnityEngine.Random.Range(0, cardInfos.Count);
        if(enemycardIndex == cardIndex)
        {
            enemycardIndex = UnityEngine.Random.Range(0, cardInfos.Count);
        }
        //Ϊ���Ƹ�ֵ
        card.GetComponent<Card>().cardSO = cardInfos[enemycardIndex];
        //���ÿ���
        card.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = cardInfos[enemycardIndex].CardFront;

        enemySelectCard = card;
    }

    //���ѡ��Ŀ���
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

    //��ť����---�ȽϿ��Ƶ�����С
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
