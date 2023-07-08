using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectCard : MonoBehaviour
{
    private Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }
    //Ô¤Ñ¡¿¨ÅÆÐ§¹û
    private void OnMouseEnter()
    {
        transform.DOScale(transform.localScale * 1.2f, 0.5f);
    }
    private void OnMouseExit()
    {
        transform.DOScale(scale, 0.5f);
    }
}
