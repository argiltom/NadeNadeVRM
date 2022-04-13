using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RateBar : MonoBehaviour
{
    [Range(0,1)] public float rateValue;
    [SerializeField] bool isLookCamera;
    [SerializeField] Color fillColor;
    [SerializeField] Color backGroundColor;

    [SerializeField] Slider slider;
    [SerializeField] Image fillImage;
    [SerializeField] Image backGroundImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = rateValue;
        fillImage.color = fillColor;
        backGroundImage.color = backGroundColor;
        if (isLookCamera)
        {
            Camera cam = Camera.main;
            transform.LookAt(cam.transform);
        }
    }
}
