using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using DG.Tweening;

// 记录所有的Sprite，并编号便于调用和生成。
public class HeadAndTextSpritesManager : MonoBehaviour
{
    public static HeadAndTextSpritesManager instance;
    
    public Image targetSpriteEnemy;
    public Image targetSpritePlayer;

    private void Awake()
    {
        instance = this;
    }


    // 这个方法将Resources中的某张图赋值到某个Image的sprite上
    public void GetSpriteToArea(string spriteNameInAtlas, Image target, int existMode)
    {
        Sprite temp = Resources.Load<Sprite> (spriteNameInAtlas);
        Debug.Log("play");
        
        if (existMode == 1)
        {
            target = targetSpriteEnemy;     // Enemy的发言Sprite
        }
        else if (existMode == 2)
        {
            target = targetSpritePlayer;    // Player的发言Sprite
        }
        if (temp != null)
        {
            // Dotween 补间动画
            Tweener twe = target.DOFade(0, 1);
            twe.OnComplete(() =>
            {            
                target.sprite = temp;
                target.DOFade(1, 1);
            });
        }
        
    }
    
    
}
