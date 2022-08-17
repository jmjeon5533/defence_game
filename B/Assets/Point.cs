using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mFollow;
    public GameObject mParticleSystem;
    public GameObject effectPrefab;
    public Transform effectGroup;
    GameObject instant;
    Effect e;
    public NestedScrollManager scrollManager;
    public MoneyBag moneyBag;
    int cool;
    public GameManager gameManager;
    void Start()
    {
        e = GetComponent<Effect>();
        //scrollManager = GetComponent<NestedScrollManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePosition();
    }

    void GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = new Vector3(mousePos.x, mousePos.y, 10);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mFollow.transform.position = mousePos;
        if (Input.GetMouseButtonDown(0))
        {
            


            if (scrollManager.targetPos < 0.25f && scrollManager.gameObject != null)
            {
                if (transform.position.y > -4.15f && transform.position.y < 4.31f && !scrollManager.isBeginDrag)
                {

                    instant = Instantiate(effectPrefab, mousePos, effectPrefab.transform.rotation);
                    ParticleSystem instantEffect = instant.GetComponent<ParticleSystem>();
                    instantEffect.Play();
                }
            }
        }
    }

    
    
}
