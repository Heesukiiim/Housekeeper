using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour
{
    public float scrollSpeed = 2000.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float scroollWheel = Input.GetAxis("Mouse ScrollWheel");
        Vector3 cameraDirection = this.transform.localRotation * Vector3.forward;
        this.transform.position += cameraDirection * Time.deltaTime * scroollWheel * scrollSpeed;
    }
}
