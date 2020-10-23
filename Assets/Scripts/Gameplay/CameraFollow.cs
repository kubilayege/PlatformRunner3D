using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform mainCamera;
    Vector3 offset;
    [SerializeField]
    float cameraSpeed;

    void Start()
    {
        mainCamera = Camera.main.gameObject.transform;
        offset = mainCamera.position - transform.position;
    }

    void Update()
    {
        if (Helper.IsPlaying())
        {
            Vector3 camPos = transform.position + (offset);
            mainCamera.position = Vector3.Lerp(mainCamera.position, camPos , Time.deltaTime * cameraSpeed);
        }
    }
}
