using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public GameObject Dialogue_UI;

   private GameObject playerobj;
    
    private float distance;

    public GameObject[] DialogueTextObj;
    private int dIndex = 0;

    void Update()
    {
        if (playerobj == null) playerobj = GameManager.Instance.player;
        if (playerobj == null) return;

       
        distance = Vector2.Distance(transform.position, playerobj.transform.position);
 

        if (distance <= 3 )
            Dialogue_UI.SetActive(true);
        else
            Dialogue_UI.SetActive(false);

    }

    public void TownBtn()
    {
        SceneManager.LoadScene("Town");
    }
    public void nextBtn(string name)
    {
        DialogueTextObj[dIndex].SetActive(false);
        if(name == "Next")
        {
            if (dIndex < DialogueTextObj.Length - 1) dIndex++;
        }
        else if (name == "Prev")
        {
            if (dIndex > 0 ) dIndex--;
        }
        DialogueTextObj[dIndex].SetActive(true);
    }
}
