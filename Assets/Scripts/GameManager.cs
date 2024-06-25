using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public string Name;
    public string UserID;
    public GameObject player;

    public float PlayerHp = 100f;
    public float PlayerExp = 1f;
    public int Coin;

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + Name);
        player = Instantiate(playerPrefab,spawnPos.position, spawnPos.rotation); 

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

   
}
