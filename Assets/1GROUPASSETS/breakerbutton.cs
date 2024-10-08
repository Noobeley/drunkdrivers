using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakerbutton : MonoBehaviour
{
    public int redbuttons = 0;

    void Start()
    {
        TriggerFunction();
    }

    void TriggerFunction()
    {
        // 50/50
        if (Random.value < 0.5f)
        {
            transform.position += new Vector3(0.03f, 0f, 0f);
            redbuttons++;
        }
    }

    void OnTouch()
    {
        transform.position = Vector3.zero;
        redbuttons--;
    }
}
