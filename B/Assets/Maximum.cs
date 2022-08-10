using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maximum : MonoBehaviour
{
    Image sp;

    private void OnEnable()
    {
        sp = GetComponent<Image>();
        StartCoroutine(maximum());
    }
    void Update()
    {

    }
    IEnumerator maximum()
    {
        for(float i = 0; i < 1;)
        {
            sp.color = new Color(0, 1, 1, i);
            i += 0.01f;
            yield return new WaitForSeconds(0.006f);
        }
        yield return new WaitForSeconds(0.5f);

        for (float i = 1; i > 0;)
        {
            sp.color = new Color(0, 1, 1, i);
            i -= 0.01f;
            yield return new WaitForSeconds(0.006f);
        }
        StartCoroutine(maximum());
    }
}
