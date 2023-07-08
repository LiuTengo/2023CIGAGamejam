using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI; //引入命名空间

// 背景的呼吸效果。
public class Breathe : MonoBehaviour
{
    Tweener twe; //声明一个Tweener对象
    public Image background;
    void Start()
    {
        twe = background.DOColor(new Color(0.7f, 0.7f, 0.7f), 3).SetLoops(-1,LoopType.Yoyo);
        twe.Pause();
        twe.SetAutoKill(false);
        twe.Play();
    }

}
