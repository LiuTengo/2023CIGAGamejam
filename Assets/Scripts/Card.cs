using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardScriptableObject cardSO;
    private Vector3 scale;


    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
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
