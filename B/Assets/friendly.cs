using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class friendly : MonoBehaviour
{
    [SerializeField] Transform[] linePos;
    public float speed = 2f;
    int lineNum = 0;
    public static int AttackDamage;
    public Text Damage;
    Enemy enemy;
    void Start()
    {
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        transform.position = linePos[lineNum].transform.position;
    }
    void Update()
    {
        if (CompareTag("Friend"))
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
            lineNum++;
        }
        if (lineNum == linePos.Length)
        {
            Destroy(gameObject);
        }

    }
    void HPmove()
    {
        Damage.text = $"{AttackDamage}";
        Damage.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //�ε��� ���� ���̸鼭
        {
            if(collision.gameObject.GetComponent<Enemy>().EnemyHp <= AttackDamage) 
                //���ݷ��� �� ü�º��� ũ�ٸ�
            {
                Destroy(collision.gameObject);
                Destroy(enemy.HP);
                //�� �ı�
            }
            else if(collision.gameObject.GetComponent<Enemy>().EnemyHp >= AttackDamage)
                //���ݷ��� �� ü�º��� �۴ٸ�
            {
                collision.gameObject.GetComponent<Enemy>().EnemyHp =
                    collision.gameObject.GetComponent<Enemy>().EnemyHp - AttackDamage;
                //�� ü���� ���ݷ¸�ŭ ���
                Destroy(gameObject);
                Destroy(Damage);
                //�ڽ� �ı�
            }
        }
    }
}
