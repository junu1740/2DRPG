using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [Header("Info")]
    public Text Name1;
    public Text Feature1;
    public Image CharImage;

    [Header("Character")]
    public GameObject[] characters;
    public CharacterInfo[] CharacterInfos;
    private int charIndex = 0;

    [Header("GameStart")]
    public GameObject Gamestart;
    public Text GameCount;
    private bool isPlayBtnClicked = false;
    private float gameCount = 3f;

    public static string CharacterName;

    private void Update()
    {
        if (isPlayBtnClicked)
        {
            gameCount -= Time.deltaTime;
            if(gameCount < 0)
            {
                SceneManager.LoadScene("Main");
            }
            GameCount.text = $"It's time to go game¢¾¢¾¢¾. \n  {gameCount:F1}";
        }
    }

    public void PlayBtn()
    {
        Gamestart.SetActive(true);
        isPlayBtnClicked=true;
        CharacterName = characters[charIndex].name;
    }
    public void SelectCharacterBtn(string btnName)
    {
        characters[charIndex].SetActive(false);
        if (btnName == "Next")
        {
            charIndex++;
            charIndex = charIndex % characters.Length;
        }

        if(btnName == "Prev")
        {
            charIndex--;
            charIndex = charIndex % characters.Length;
            charIndex = charIndex < 0 ? charIndex + characters.Length : charIndex;
        }
        characters[charIndex].SetActive(true);
        SetPanelInfo();
    }

    private void SetPanelInfo()
    {
        Name1.text = CharacterInfos[charIndex].Name;
        Feature1.text = CharacterInfos[charIndex].Feature;
        CharImage.sprite = characters[charIndex].GetComponent<SpriteRenderer>().sprite;
      


    }

    

    private void Start()
    {
        SetPanelInfo();
    }
}
