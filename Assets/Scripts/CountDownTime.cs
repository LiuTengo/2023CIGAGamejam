using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTime : MonoBehaviour
{
    [SerializeField] private float maxTime;//��ʼʱ��
    [SerializeField] private Image sliderImg;//����������ͼƬ

    private Slider countDownSlider;//������
    private float time;

    private void Start()
    {
        countDownSlider = GetComponent<Slider>();
    }
    private void OnEnable()
    {
        time = maxTime;
        sliderImg.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(time>0)
            time -= Time.deltaTime;

        countDownSlider.value = time / maxTime;
        sliderImg.DOColor(Color.red,maxTime).OnComplete(
            () =>
            {

            }
            ); 
    }
}
