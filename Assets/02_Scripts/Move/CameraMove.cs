using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target;
    Transform toTarget;
    void Start()
    {
        toTarget = target.transform;
        
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, toTarget.position, 2f * Time.fixedDeltaTime);
    }
}
