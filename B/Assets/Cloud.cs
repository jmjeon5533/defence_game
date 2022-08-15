using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left);
        PositionCloud();

    }
    void PositionCloud()
    {
        if(GetComponent<RectTransform>().localPosition.x <= -2600)
        transform.Translate(7416, 0, 0);
    }
}
