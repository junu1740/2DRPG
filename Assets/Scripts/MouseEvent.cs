using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{

    public GameObject PotionUI;
    public GameObject PowerUI;
    void Start()
    {
        
    }

    void Update()
    {
        MouseClick();
    }

    void MouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Pos, Vector2.zero, 0f);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.name == "NOPC")
                {
                    PowerUI.SetActive(true);
                }
                if (hit.collider.gameObject.name == "Sugar")
                {
                    PotionUI.gameObject.SetActive(true);
                }
                if (hit.collider.gameObject.name == "Drink")
                {
                    Debug.Log("3");
                }

            }
        }
    }
}
