using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketsSpawner : MonoBehaviour
{
    public GameObject basket;
    public Transform basketParent;

    public static int basketsSpawned;

    private Vector3 lastBasketEven, lastBasketOdd;

    private void Awake()
    {
        basketsSpawned = 0;
    }

    private void Start()
    {
        GlobalEventManager.spawnBasket.AddListener(SpawnBasket);
        lastBasketOdd = new Vector3(-1.5f, 4f, 0f);
        lastBasketEven = new Vector3(1.5f, 0f, 0f);
    }

    private void SpawnBasket()
    {
        if((basketsSpawned + 1) % 2 == 0)
        {
            GameObject BasketEven = Instantiate(basket);
            BasketEven.transform.parent = basketParent;
            BasketEven.transform.position = new Vector3(lastBasketEven.x, lastBasketEven.y + 8, lastBasketEven.z);
            lastBasketEven = BasketEven.transform.position;
        }
        else
        {
            GameObject BasketOdd = Instantiate(basket);
            BasketOdd.transform.parent = basketParent;
            BasketOdd.transform.position = new Vector3(lastBasketOdd.x, lastBasketOdd.y + 8, lastBasketOdd.z);
            lastBasketOdd = BasketOdd.transform.position;
        }
    }
}
