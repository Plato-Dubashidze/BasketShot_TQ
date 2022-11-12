using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    private Transform netTransform;
    private Rigidbody2D rb;
    private Collider2D col;

    private bool isOnRim, isOnWall;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
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
        rb.isKinematic = false;
        col.enabled = true;
        BallStatus.isInNet = false;
        rb.AddForce(force);
        rb.AddTorque(10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Net"))
        {
            rb.isKinematic = true;
            col.enabled = false;
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = 0;
            BallStatus.isInNet = true;
            BallStatus.isShot = false;
            netTransform = collision.transform;
            GlobalEventManager.NewNetAssigned(collision.gameObject);
            CameraStatus.camIsMoving = true;
            GlobalEventManager.SpawnBasket();
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            GlobalEventManager.LevelEnd();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rim"))
        {
            isOnRim = true;
        }

        if (collision.gameObject.CompareTag("MainCamera"))
        {
            isOnWall = true;
        }

        if (isOnWall && isOnRim)
        {
            GlobalEventManager.LevelEnd();
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rim"))
        {
            isOnRim = false;
        }

        if (collision.gameObject.CompareTag("MainCamera"))
        {
            isOnWall = false;
        }
    }
}
