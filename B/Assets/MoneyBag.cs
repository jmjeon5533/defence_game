using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBag : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rect;
    public int cool;
    int c;
    int direction;
    public float upDownSpeed = 120f;
    public float speed = 480f;
    bool isSummon = false;
    void Start()
    {
        
        cool = Random.Range(60, 120);
        c = cool;
        direction = Random.Range(2,4);
        StartCoroutine(UpDown());
        StartCoroutine(delay());
        rect = GetComponent<RectTransform>();
        rect.position = new Vector3(-50, Random.Range(260, 2520), rect.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rect.position.x + 40 > 1440 && speed > 0) speed = -speed;
        else if (rect.position.x - 40 < 0 && speed < 0) speed = -speed;
        if (rect.position.y + 20 > 2620 && upDownSpeed > 0) upDownSpeed = -upDownSpeed;
        else if (rect.position.y + 20 < 250 && upDownSpeed > 0) upDownSpeed = -upDownSpeed;
        if(isSummon) rect.position = new Vector3(rect.position.x + speed * Time.deltaTime, rect.position.y + upDownSpeed * Time.deltaTime, rect.position.z);
        else rect.position = new Vector3(-50, Random.Range(260, 2520), rect.position.z);
    }

    IEnumerator delay()
    {
        Debug.Log(cool);
        yield return new WaitForSeconds(1f);
        if (cool > 1)
        {
            cool--;
            if (isSummon && c < c -30)
            {
                isSummon = false;
            }
            StartCoroutine(delay());

        }
        else
        {
            cool = Random.Range(10, 20);
            StartCoroutine(delay());
            rect.transform.position = new Vector3(0, rect.transform.position.y, 0);
            if(!isSummon) isSummon = true;
           


        }


    }
    IEnumerator UpDown()
    {
        Debug.Log(cool);
        yield return new WaitForSeconds(1f);
        if (direction > 1)
        {
            direction--;
            StartCoroutine(UpDown());
        }
        else
        {
            direction = Random.Range(2, 4);
            int randomChoose = Random.Range(1, 3);
            if(randomChoose == 1)
            {
                upDownSpeed = Random.Range(120, 240);
            } else
            {
                upDownSpeed = Random.Range(-240, -120);
            }
            StartCoroutine(UpDown());

        }


    }
}
