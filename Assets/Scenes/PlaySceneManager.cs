using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneManager : MonoBehaviour
{
    public List<CardScriptableObject> cards;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //生成
    public void ResetCard()
    {
        int cardIndex = Random.Range(0, cards.Count+1);//生成范围在（0~卡牌数组长度）随机数
    }
}
