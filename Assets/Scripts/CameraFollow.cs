using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
            if (CameraStatus.camIsMoving)
            {
                transform.position = new Vector3(transform.position.x,
                                     Mathf.Lerp(transform.position.y, target.transform.position.y + 4f, 0.02f), transform.position.z);

                if (transform.position.y >= target.transform.position.y + 3f)
                {
                    CameraStatus.camIsMoving = false;
                }
            }
        }
}
