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
            BasketEven.transform.position = randomPos(lastBasketEven);
            BasketEven.transform.rotation = randomQuataternion(BasketEven);
            lastBasketEven = new Vector3(lastBasketEven.x, lastBasketEven.y + 8, lastBasketEven.z);
        }
        else
        {
            GameObject BasketOdd = Instantiate(basket);
            BasketOdd.transform.parent = basketParent;
            BasketOdd.transform.position = randomPos(lastBasketOdd);
            BasketOdd.transform.rotation = randomQuataternion(BasketOdd);
            lastBasketOdd = new Vector3(lastBasketOdd.x, lastBasketOdd.y + 8, lastBasketOdd.z);
        }
    }

    private Vector3 randomPos (Vector3 lastPos)
    {
        float x;
        if(lastPos.x < 0)
            x = lastPos.x + UnityEngine.Random.Range(0f, 0.3f);
        else if(lastPos.x > 0)
            x = lastPos.x - UnityEngine.Random.Range(0f, 0.3f);
        else
            x = lastPos.x;
            
        float y = lastPos.y + UnityEngine.Random.Range(5f, 8f);
        float z = lastPos.z;
        return new Vector3 (x, y, z);
    }

    private Quaternion randomQuataternion(GameObject lastObj)
    {
        if(lastObj.transform.position.x < 0)
        {
            Quaternion quaternion = lastObj.transform.rotation;
            quaternion = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0, -30f));
            return quaternion;
        }
        else if(lastObj.transform.position.x > 0)
        {
            Quaternion quaternion = lastObj.transform.rotation;
            quaternion = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0, 30f));
            return quaternion;
        }
        else
        {
            return Quaternion.identity;
        }
    }
}
