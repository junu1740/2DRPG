using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn : MonoBehaviour
{
  public  void Exit()
    {
       
            Application.Quit();
        
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void Change()
    {
        SceneManager.LoadScene(1);
    }
}
