using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    private int ChanceOfStarSpawn;
    private void Start()
    {
        ChanceOfStarSpawn = PlayerPrefs.GetInt("ChanceOfStarSpawning");
        if(ChanceOfStarSpawn >= Random.Range(0, 100))
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //Add event launch TODO
            Destroy(gameObject);
        }
    }
}
