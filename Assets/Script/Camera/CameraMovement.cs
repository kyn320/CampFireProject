using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;

    public float speed = 2f;
    public Vector3 DepthPos;

    private Transform tr;

    Vector3 currentPos, movePos;

    void Awake()
    {
        tr = GetComponent<Transform>();
        if (target == null)
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        tr.position = Vector3.Lerp(tr.position,target.position + DepthPos, speed * Time.deltaTime);
    }


}
