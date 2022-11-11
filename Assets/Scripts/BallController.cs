using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    private Transform netTransform;

    private void Start()
    {
        GlobalEventManager.shoot.AddListener(Shoot);
    }

    private void Update()
    {
        if (BallStatus.isInNet)
        {
            transform.position = netTransform.position;
        }
    }

    private void Shoot(Vector3 force)
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<Collider2D>().enabled = true;
        BallStatus.isInNet = false;
        transform.GetComponent<Rigidbody2D>().AddForce(force);
        print(force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Net"))
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            BallStatus.isInNet = true;
            BallStatus.isShot = false;
            netTransform = collision.transform;
            GlobalEventManager.NewNetAssigned(collision.gameObject);
        }
    }
}
