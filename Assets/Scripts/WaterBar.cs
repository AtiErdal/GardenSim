using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{

    [SerializeField] Image foregroundImage;
    Camera fpsCam;

    private void Awake()
    {
        GetComponentInParent<Feeding>().OnWaterPctChanged += HandleWaterChanged;
    }

    private void Start()
    {
        fpsCam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if(foregroundImage.fillAmount <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    void HandleWaterChanged(float pct)
    {
        foregroundImage.fillAmount += pct;
    }


    private void LateUpdate()
    {
        transform.LookAt(fpsCam.transform);
        transform.Rotate(0, 180, 0);
    }
}
