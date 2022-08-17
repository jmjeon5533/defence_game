using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBag : MonoBehaviour
{
    // Start is called before the first frame update
    //RectTransform rect;
    public int cool;
    int c;
    public int livingTime = 30;
    int direction;
    public float upDownSpeed = 1f;
    public float speed = 1f;
    public bool isSummon = false;
    public NestedScrollManager scroll;
    void Start()
    {
        
        cool = Random.Range(60, 120);
        c = cool;
        direction = Random.Range(2,4);
        StartCoroutine(UpDown());
        StartCoroutine(delay());
        transform.position = new Vector3(-3, Random.Range(-4.3f, 4.3f), 100);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x + 1f > 3f && speed > 0) speed = -speed;
        else if (transform.position.x - 1f < -3f && speed < 0) speed = -speed;
        if (transform.position.y + 1f > 4.3f && upDownSpeed > 0) upDownSpeed = -upDownSpeed;
        else if (transform.position.y - 1f < -4.6f && upDownSpeed < 0) upDownSpeed = -upDownSpeed;
        if(isSummon) transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y + upDownSpeed * Time.deltaTime, transform.position.z);
        else transform.position = new Vector3(-3, Random.Range(-4.3f, 4.3f), 100);
        if(scroll.targetPos < 0.25f)
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(255, 255, 255, 0);

        } else
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(255, 255, 255, 100);
        }
    }

    IEnumerator delay()
    {
        Debug.Log(cool);
        yield return new WaitForSeconds(1f);
        if (livingTime > 0)
        {
            livingTime--;
        } else if (livingTime == 0)
        {
            isSummon = false;

        }
        if (cool > 0)
        {
            cool--;
            
            StartCoroutine(delay());

        }
        else
        {
            cool = Random.Range(60, 120);
            StartCoroutine(delay());
            transform.position = new Vector3(-3, Random.Range(-4.3f, 4.3f), 10);
            if(!isSummon) isSummon = true;
            livingTime = 30;
           


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
            Debug.Log("UpDown:" + randomChoose);
            if(randomChoose == 1)
            {
                upDownSpeed = Random.Range(0.4f, 0.8f);
            } else
            {
                upDownSpeed = Random.Range(-0.4f, -0.8f);
            }
            StartCoroutine(UpDown());

        }


    }
}