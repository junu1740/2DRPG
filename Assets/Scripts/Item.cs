using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public float CoolTIme = 3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Coin")
            {
                GameManager.Instance.Coin += 10;
                Debug.Log("Player Coin :" + GameManager.Instance.Coin);
                Destroy(gameObject);
            }
            if (gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerHp += 10;
                Debug.Log("Player PlayerHp :" + GameManager.Instance.PlayerHp);
                Destroy(gameObject);
            }
            if (gameObject.tag == "HJ")
            {
                GameManager.Instance.Coin += 100;
                Debug.Log("»Ò¿Á ƒ⁄¿Œ »πµÊ");
                Debug.Log("Player Coin :" + GameManager.Instance.Coin);
                Destroy(gameObject);
            }
            if(gameObject.tag == "Speed")
            {
                Character.Instance.Speed += 5;
                CoolTIme -= Time.deltaTime;
                
                if(CoolTIme == 0)
                {
                    Character.Instance.Speed -= 5;
                }
                Destroy(gameObject);
            }
            if (gameObject.tag == "Strength")
            {
                Attack.Instance.AttackDamage += 5;
                CoolTIme -= Time.deltaTime;

                if (CoolTIme == 0)
                {
                    Attack.Instance.AttackDamage -= 5;
                }
                Destroy(gameObject);
            }

        }
    }
}
