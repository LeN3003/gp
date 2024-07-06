
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public int coinCount;
   // public int keyCount;
    public TMP_Text coinText;
   // public TMP_Text keyText;

    public GameObject coinPrefab;
  //  public GameObject keyPrefab;

    public Vector3[] coinSpawnPoints;
    //public Vector3[] keySpawnPoints;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject); // Optional: if you want to persist the CoinManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
        SpawnCoins();
       // SpawnKeys();
    }

    public void IncreaseCoinCount(int amount)
    {
        coinCount += amount;
        Debug.Log("Coin count increased: " + coinCount);
        UpdateUI();
    }
    /*
    public void IncreaseKeyCount(int amount)
    {
        keyCount += amount;
        Debug.Log("Key count increased: " + keyCount);
        UpdateUI();
    }
    */
    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = ": " + coinCount.ToString();
            Debug.Log("Coin text updated: " + coinText.text);
        }
        else
        {
            Debug.LogError("CoinText reference is missing in CoinManager.");
        }
        /*
        if (keyText != null)
        {
            keyText.text = ": " + keyCount.ToString();
            Debug.Log("Key text updated: " + keyText.text);
        }
        else
        {
            Debug.LogError("KeyText reference is missing in CoinManager.");
        }
        */
    }

    private void SpawnCoins()
    {
        foreach (Vector3 spawnPoint in coinSpawnPoints)
        {
            Instantiate(coinPrefab, spawnPoint, Quaternion.identity);
        }
    }
    /*
    private void SpawnKeys()
    {
        foreach (Vector3 spawnPoint in keySpawnPoints)
        {
            Instantiate(keyPrefab, spawnPoint, Quaternion.identity);
        }
    }
    */
}
