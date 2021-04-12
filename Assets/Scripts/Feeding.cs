using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeding : MonoBehaviour
{

    [SerializeField] int maxWater = 10;

    private float currentWater;

    public event Action<float> OnWaterPctChanged = delegate { };

    private void OnEnable()
    {
        currentWater = 0;
    }

    public void DecreaseWater(float amount)
    {
        OnWaterPctChanged(amount);
    }
}
