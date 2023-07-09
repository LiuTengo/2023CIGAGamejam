using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {        
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(GameStateController.instance.fsm.currentState == GameStateController.instance.fsm.states["GuessState"])
        {
            float y = Mathf.Clamp(mousepos.y, -5.5f, 1.5f);
            Vector3 p = new Vector3(mousepos.x, y, -0.05f);
            transform.position = p;
        }
        else
        {
            float y = Mathf.Clamp(mousepos.y,-5.5f,0f);
            Vector3 p = new Vector3(mousepos.x, y,-0.05f);
            transform.position = p;
        }
    }
}
