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
        transform.Translate(new Vector2(-0.5f,0));
        PositionCloud();

    }
    void PositionCloud()
    {
        if(GetComponent<RectTransform>().localPosition.x <= -2600)
        transform.Translate(7416, 0, 0);
    }
}
