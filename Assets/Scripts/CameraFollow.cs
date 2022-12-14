using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Color blackCol, whiteCol;
    public GameObject target;

    private string backgroundMode;
    private bool sound;
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        AddCollider();
        backgroundMode = PlayerPrefs.GetString("BackGroundMode");
        sound = PlayerPrefs.GetInt("SoundBool") != 0;
        switch (backgroundMode)
        {
            case "White":
                cam.backgroundColor = whiteCol;
                break;
            case "Black":
                cam.backgroundColor = blackCol;
                break;
        }

        switch (sound)
        {
            case true:
                AudioListener.volume = 1;
                break;
            case false:
                AudioListener.volume = 0;
                break;
        }

    }

    void AddCollider()
    {
        if (Camera.main == null) { Debug.LogError("Camera.main not found, failed to create edge colliders"); return; }

        if (!cam.orthographic) { Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders"); return; }

        var bottomLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var topLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        var topRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        var bottomRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

        // add or use existing EdgeCollider2D
        var edge = GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : GetComponent<EdgeCollider2D>();

        var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
        edge.points = edgePoints;
    }

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
