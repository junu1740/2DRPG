using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearSceneUI : MonoBehaviour
{

    public Text IDText;
    void Start()
    {
        IDText.text = GameManager.Instance.UserID;
    }

    void Update()
    {
        
    }
}
