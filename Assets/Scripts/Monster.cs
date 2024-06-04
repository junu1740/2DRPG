using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float moveTime = 0f;
    private float turnTime = 0f;
    private bool isDie = false;

    public float Hp = 30f;
    public float Damage = 5f;
    public float Exp = 2;

    public float Movespeed = 3f;
    public GameObject[] ItemObj;

    private Animator MonAnimator;

    private void Start()
    {

    MonAnimator = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie) return;
        if (collision.gameObject.tag == "Player")
        {
            MonAnimator.SetTrigger("Attack");
            GameManager.Instance.PlayerHp -=  Damage;
            Debug.Log(">>>>>>>>>>>>>>>>> PlayerHp " + GameManager.Instance.PlayerHp);
        }

        if (collision.gameObject.tag == "Attack")
        {
            MonAnimator.SetTrigger("Damage");
            Hp -= collision.gameObject.GetComponent<Attack>().AttackDamage;

            if(Hp <= 0) 
            {
                MonsterDie();
            }
        }

    }
    void MonsterDie()
    {
        isDie = true;
        MonAnimator.SetTrigger("Die");
        GameManager.Instance.PlayerExp += Exp;


        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1.5f);
    }
       private void OnDestroy()
        {
        int itemRandom = Random.Range(0, ItemObj.Length * 1);
        if (itemRandom < ItemObj.Length)
        {
            Instantiate(ItemObj[itemRandom], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }

        }

    private void Update()
    {
        MonsterMove();
    }

    void MonsterMove()
    {

        if (isDie) return;
        moveTime += Time.deltaTime;  
        if (moveTime <= turnTime) 
        {
            this.transform.Translate(Movespeed * Time.deltaTime, 0, 0);
        }
        else
        {
            turnTime = Random.Range(1, 5);
            moveTime = 0;

            transform.Rotate(0, 180, 0);
        }
    }
}
