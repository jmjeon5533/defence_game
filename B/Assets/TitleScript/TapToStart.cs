using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public GameObject Tap;
    void Start()
    {
        StartCoroutine(twink());
    }
    IEnumerator twink()
    {
        Tap.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Tap.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(twink());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
