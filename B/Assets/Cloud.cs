using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour
{
    RectTransform rect;
    public float cloudSpeed;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1f,0) * Time.deltaTime * cloudSpeed);
        PositionCloud();

    }
    void PositionCloud()
    {
        if (rect.anchoredPosition.x <= -2600)
            rect.anchoredPosition += new Vector2(7416, 0);
    }
}
