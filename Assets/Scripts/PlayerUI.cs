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

    private void Start()
    {
       IDText.text = GameManager.Instance.UserID;
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + GameManager.Instance.Name);
        player = Instantiate(playerPrefab);
       
    }
    private void Update()
    {
        display();
    }

    void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerHp;
    }
}
