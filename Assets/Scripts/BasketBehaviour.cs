using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBehaviour : MonoBehaviour
{
    private void Start()
    {
        GlobalEventManager.levelEnd.AddListener(LevelEnd);
        BasketsSpawner.basketsSpawned++;
    }

    private void LevelEnd()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
