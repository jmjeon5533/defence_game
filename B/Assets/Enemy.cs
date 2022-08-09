using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] linePos;
    public Text HP;
    public float speed = 2f;
    int lineNum = 11;

    public static float EnemyHp;
    void Start()
    {

        transform.position = linePos[lineNum].transform.position;
    }

    void Update()
    {
        if (CompareTag("Enem"))
        {
            MovePath();
            HPmove(); 
        }
    }
    public void MovePath()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, linePos[lineNum].transform.position, speed * Time.deltaTime);

        if (transform.position == linePos[lineNum].transform.position)
        {
            lineNum--;
        }
        if (lineNum == linePos.Length)
        {
            Destroy(gameObject);
            Destroy(HP);
        }

    }
    void HPmove()
    {
        HP.text = $"{EnemyHp}";
        HP.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0f));
    }
}
