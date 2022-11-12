using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    public GameObject netCol;

    [SerializeField]private bool isReached;
    private void Start()
    {
        GlobalEventManager.shoot.AddListener(Shoot);
    }

    private void Shoot(Vector3 force)
    {
        StartCoroutine(EnbaleDelay());
    }

    private IEnumerator EnbaleDelay()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<Collider2D>().enabled = true;
        netCol.GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            netCol.GetComponent<Collider2D>().enabled = false;
            if (!isReached)
            {
                GlobalEventManager.NetReached();
                isReached = true;
            }
        }
    }
}
