using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    SpriteRenderer sp;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (sp.color.a > 0)
        {
            transform.Translate(Vector2.up * Time.deltaTime);
            sp.color =
                new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - 0.01f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
