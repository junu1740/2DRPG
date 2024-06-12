using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
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
                Debug.Log("ÈñÀç ÄÚÀÎ È¹µæ");
                Debug.Log("Player Coin :" + GameManager.Instance.Coin);
                Destroy(gameObject);
            }
            if(gameObject.tag == "Speed")
            {
                collision.gameObject.GetComponent<Character>().spood();
                Destroy(gameObject);
            }
            if (gameObject.tag == "Strength")
            {
                Debug.Log("Èû");
                Character.Instance.AttackPower += 10;
                Destroy(gameObject);
            }

        }
    }
}
