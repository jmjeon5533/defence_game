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
    int cool;
    void Start()
    {
        e = GetComponent<Effect>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePosition();
    }

    void GetMousePosition()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            
            mousePos = new Vector3(mousePos.x, mousePos.y, 10);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mFollow.transform.position = mousePos;
            
           
           
            instant = Instantiate(effectPrefab,mousePos,effectPrefab.transform.rotation);
            ParticleSystem instantEffect = instant.GetComponent<ParticleSystem>();
            instantEffect.Play();
            

          

        }
    }

    
    
}
