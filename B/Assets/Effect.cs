using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public ParticleSystem effect;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay());
    }


    public void EffectPlay()
    {
        effect.transform.position = transform.position;
        effect.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator delay()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
