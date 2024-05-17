using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [Header("Info")]
    public Text Name1;
    public Text Feature1;
    public Image CharImage;

    [Header("Character")]
    public GameObject[] charcters;
    private int charIndex = 0;

    public void SelectCharacterBtn(string btnName)
    {
        charcters[charIndex].SetActive(false);
        if (btnName == "Next")
        {
            charIndex++;
            charIndex = charIndex % charcters.Length;
        }

        if(btnName == "Prev")
        {
            charIndex--;
            charIndex = charIndex % charcters.Length;
            charIndex = charIndex < 0 ? charIndex + charcters.Length : charIndex;
        }

        Debug.Log($"CharIndex : {charIndex}");
        charcters[charIndex].SetActive(true);
    }


}
