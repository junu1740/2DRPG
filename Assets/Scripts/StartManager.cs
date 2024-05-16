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

    //�α���
    public void LoginBtn()
    {
        if(PlayerPrefs.GetString("ID") != LoginID.text)
        {
            LoginUi.SetActive(false);
            ErrorUi.SetActive(true);
            ErrorMsg.text = "�߷��߷� ���̵�Ʋ�ȱ��䢾����.";
            Invoke("ErrorMsg", 3f);
            return;
        }
        if (PlayerPrefs.GetString("PW") != LoginPW.text)
        {
            LoginUi.SetActive(false);
            ErrorUi.SetActive(true);
            ErrorMsg.text = "�߷��߷� ��й�ȣ��Ʋ�ȱ��䢾����.";
            Invoke("ErrorMsg", 3f);
            return;
        }
        SceneManager.LoadScene(1);
    }
    //����
    public void MembershipBtn()
    {
        PlayerPrefs.SetString("ID", MembershipID.text);
        PlayerPrefs.SetString("PW", MembershipPW.text);
        PlayerPrefs.SetString("Find", MembershipFind.text);

        MembershipUI.SetActive(false);
        Debug.Log("�Ϸ�");   
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
    //��Ʈ
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
            ErrorMsg.text = "�߷��߷� �߸��� ��Ʈ�󱸿䢾����";
        }
        Invoke("ErrorMsgExit", 3f);
    }
}
