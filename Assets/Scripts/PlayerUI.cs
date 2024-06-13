using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharacterImg;
    public Text IDText;

    public Slider HpSlider;
    private GameObject player;
    public GameObject spawnPos;
    public Text CoinText;
    public Text MonsterText;
    public Text SpeedText;
    public Text HimText;
    public Text TimeText;
    public float Sec = 0 ;
    public float Min = 0;                


    bool isGameOver = false;

    private void Start()
    {
       
       IDText.text = GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);


        

       

    }

   
    private void Update()
    {
        Sec += Time.deltaTime;
        if(Sec >= 59 )
        {
            Sec = 0;
            Min += 1;
        }
        CoinText.text = ":" + GameManager.Instance.Coin.ToString();
        MonsterText.text =":" + GameManager.Instance.MonsterCount.ToString();
        display();
        SpeedText.text = ":" + Character.Instance.Speed;
        HimText.text = ":" + Character.Instance.AttackPower;
        TimeText.text = "1";
        TimeText.text = $"{Min:N0}Ка{Sec:N0}УЪ";
    }

    void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerHp;
    }
}
