using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [Header("Membership")]
    public GameObject MembershipUI;
    public InputField MembershipID;
    public InputField MembershipPW;
    public InputField MembershipFind;

    [Header("Login")]
    public GameObject LoginUi;
    public InputField LoginID;
    public InputField LoginPW;

    [Header("Find")]
    public GameObject FindUi;
    public InputField Find1;

    [Header("Error")]
    public GameObject ErrorUi;
    public Text ErrorMsg;

    //로그인
    public void LoginBtn()
    {
        if(PlayerPrefs.GetString("ID") != LoginID.text)
        {
            LoginUi.SetActive(false);
            ErrorUi.SetActive(true);
            ErrorMsg.text = "야레야레 아이디가틀렸군요♥♥♥.";
            Invoke("ErrorMsg", 3f);
            return;
        }
        if (PlayerPrefs.GetString("PW") != LoginPW.text)
        {
            LoginUi.SetActive(false);
            ErrorUi.SetActive(true);
            ErrorMsg.text = "야레야레 비밀번호가틀렸군요♥♥♥.";
            Invoke("ErrorMsg", 3f);
            return;
        }
        SceneManager.LoadScene(1);
    }
    //가입
    public void MembershipBtn()
    {
        PlayerPrefs.SetString("ID", MembershipID.text);
        PlayerPrefs.SetString("PW", MembershipPW.text);
        PlayerPrefs.SetString("Find", MembershipFind.text);

        MembershipUI.SetActive(false);
        Debug.Log("완료");   
    }

    private void Update()
    {
        Debug.Log("ID : " + PlayerPrefs.GetString("ID"));
        Debug.Log("PW : " + PlayerPrefs.GetString("PW"));
        Debug.Log("Find : " + PlayerPrefs.GetString("Find"));

    }

    void ErrorMsgExit()
    {
        ErrorUi.SetActive(false);
    }
    //힌트
    public void FindBtn()
    {
        FindUi.SetActive(false);
        ErrorUi.SetActive(true);

        if (PlayerPrefs.GetString("Find") == Find1.text)
        {
            ErrorMsg.text = $"ID :  {PlayerPrefs.GetString("ID")}\n PW : {PlayerPrefs.GetString("PW")}";
        }
        else
        {
            ErrorMsg.text = "야레야레 잘못된 힌트라구요♥♥♥";
        }
        Invoke("ErrorMsgExit", 3f);
    }
}
