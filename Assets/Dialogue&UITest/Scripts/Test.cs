using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Image target;

    public void getbutton()
    {
        HeadAndTextSpritesManager.instance.GetSpriteToArea("fime", target);
    }
}
