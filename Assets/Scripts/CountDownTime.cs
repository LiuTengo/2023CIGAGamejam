using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTime : MonoBehaviour
{
    [SerializeField] private float maxTime;//初始时间
    [SerializeField] private Image sliderImg;//填充进度条的图片

    private Slider countDownSlider;//进度条
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
