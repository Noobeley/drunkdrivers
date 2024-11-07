using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomness : MonoBehaviour
{
    private float[] chances = { 0.5f, 0.1f, 0.25f, 0.6f };

    private void Update()
    {
        float value = UnityEngine.Random.Range(0f, 1f);
        for (int i = 0; i < chances.Length; i++)
        {
            if (value < Chance(i))
            {
                Debug.Log(i + 1);
                break;
            }
        }
    }

    private float Chance(int index)
    {
        float totalChance = 0f;
        for (int i = 0; i <= index; i++)
        {
            totalChance += chances[i];
        }
        return totalChance;
    }
}