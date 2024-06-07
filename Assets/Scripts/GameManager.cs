using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public string Name;
    public string UserID;
    public Text GmText;

    public float PlayerHp = 100f;
    public float PlayerExp = 1f;
    public int Coin;
    public int MonsterCount;
    public float GmCount = 2f;

    

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + Name);
        GameObject player = Instantiate(playerPrefab,spawnPos.position, spawnPos.rotation); 

        return player;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(Instance);
    }

     void Start()
    {
        UserID = PlayerPrefs.GetString("ID");
    }

    private void Update()
    {
        if(MonsterCount == 0)
        {
            GmCount -= Time.deltaTime;
            
            if (GmCount < 0)
            {
                SceneManager.LoadScene(3);
            }
            if (GmText != null)
            {
                GmText.gameObject.SetActive(true);  
                GmText.text = $"축하합니다!!";
            }
        }
    }


}
