using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] public GameObject coinPrefab; 
    [SerializeField] public GameObject[] spawnPoints; 


    public void SpawnCoin()
    {
        if (coinPrefab != null && spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void PlayerScored()
    {
        SpawnCoin();
    }

}
