using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

// 记录所有的Sprite，并编号便于调用和生成。
public class HeadAndTextSpritesManager : MonoBehaviour
{
    public static HeadAndTextSpritesManager instance;
    
    public Image targetSpriteEnemy;
    public Image targetSpritePlayer;

    public SpriteAtlas atlas;

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        atlas = Resources.Load<SpriteAtlas>("Main_Sprite_Atlas");
    }

    // 这个方法将Atlas中的某张图赋值到某个Image的sprite上。
    // 这个方法有一个特别牛逼的报错，可以稳定crash，unity直接崩掉。
    public void GetSpriteToArea(string spriteNameInAtlas, Image target)
    {
        if (atlas.GetSprite(spriteNameInAtlas) != null && target != null)
        {
            Sprite temp = atlas.GetSprite(spriteNameInAtlas);
            target.sprite = temp;
        }
        else
        {
            Debug.Log("寄了哥们");
        }
    }
    
    
}
