using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] linePos;
    public float speed = 2f;
    int lineNum = 11;

    public float EnemyHp;
    void Start()
    {
        transform.position = linePos[lineNum].transform.position;
    }

    void Update()
    {
        MovePath();
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
        }

    }
}
