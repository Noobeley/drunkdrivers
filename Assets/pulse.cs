using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulse : MonoBehaviour
{
    private Vector3 initialScale;
    private float scaleChange = 0.02f;
    private float scaleDuration = 3f;
    private float timer = 0f;
    private bool increasing = true;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= scaleDuration)
        {
            timer = 0f;
            increasing = !increasing;
        }

        if (increasing)
        {
            IncreaseScale();
        }
        else
        {
            DecreaseScale();
        }
    }

    private void IncreaseScale()
    {
        Vector3 newScale = transform.localScale + new Vector3(scaleChange, scaleChange, scaleChange) * Time.deltaTime / scaleDuration;
        transform.localScale = newScale;
    }

    private void DecreaseScale()
    {
        Vector3 newScale = transform.localScale - new Vector3(scaleChange, scaleChange, scaleChange) * Time.deltaTime / scaleDuration;
        transform.localScale = newScale;
    }
}
