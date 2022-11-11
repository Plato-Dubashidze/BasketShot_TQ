using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float power;

    [Header ("Dots")]
    public int dotsVault;
    public GameObject dotPrefab;
    public Transform dotsTransform;

    private GameObject curNet, curBasket;
    private Transform lastDotTransform;
    private Vector3 startMousePos;

    private List<GameObject> dotsObjects = new List<GameObject>();

    private void Start()
    {
        GlobalEventManager.newNetAssigned.AddListener(NewNetAssigned);

        float tempValue = 1f;

        for (int i = 0; i < dotsVault; i++)
        {
            GameObject dot = Instantiate(dotPrefab);
            dot.transform.parent = dotsTransform;
            if (i > 10)
            {
                dot.transform.localScale = new Vector2(tempValue, tempValue);
                tempValue -= 0.05f;
            }

            dotsObjects.Add(dot);
        }

        dotsTransform.gameObject.SetActive(false);
    }

    private void NewNetAssigned(GameObject net)
    {
        curNet = net;
        curBasket = net.transform.parent.gameObject;
    }

    private void Update()
    {
        if (!BallStatus.isShot)
        {
            if (Input.GetMouseButton(0))
            {
                if (!BallStatus.aiming)
                {
                    BallStatus.aiming = true;
                    startMousePos = Input.mousePosition;
                    CalculatePath();
                    BasketRotation(curBasket);
                    ShowPath();
                }
                else
                {
                    BasketRotation(curBasket);
                    CalculatePath();
                }
            }
            else if (BallStatus.aiming)
            {
                GlobalEventManager.Shoot(GetForce(Input.mousePosition));
                BallStatus.isShot = true;
                BallStatus.aiming = false;
                HidePath();
            }
        }
    }

    Vector2 GetForce(Vector3 mousePos)
    {
        return (new Vector2(startMousePos.x, startMousePos.y) - new Vector2(mousePos.x, mousePos.y)) * power;
    }


    private void CalculatePath()
    {
        dotsTransform.gameObject.SetActive(true);

        Vector2 vel = GetForce(Input.mousePosition) * Time.fixedDeltaTime / GetComponent<Rigidbody2D>().mass;
        for (int i = 0; i < dotsVault; i++)
        {
            float t = i / 30f;
            Vector3 point = PathPoint(transform.position, vel, t);
            point.z = -1.0f;
            dotsObjects[i].transform.position = point;
        }
        lastDotTransform = dotsObjects.Last().transform;
    }

    private Vector2 PathPoint(Vector2 startP, Vector2 startVel, float t)
    {
        return startP + startVel * t + 0.5f * Physics2D.gravity * t * t;
    }

    private void HidePath()
    {
        dotsTransform.gameObject.SetActive(false);
    }
    private void ShowPath()
    {
        dotsTransform.gameObject.SetActive(true);
    }

    private void BasketRotation(GameObject basket)
    {
        Vector3 dir = lastDotTransform.position - basket.transform.position;
        dir.Normalize();

        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        basket.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90f);

    }
}
