using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Image target;
    public TextManager textManager;

    public void getbutton()
    {
        HeadAndTextSpritesManager.instance.GetSpriteToArea("head", null, 1);
        Debug.Log(textManager.TextSearch("Player",1));
    }
}
