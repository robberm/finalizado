using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public Vector3 offset = Vector3.zero;

    private Vector3 vel;

    private void FixedUpdate()
    {
        if(target == null)
        {
            return;
        }
        Vector3 _targetPos = target.transform.position + offset;
        _targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, _targetPos, ref vel, speed > 0 ? 1f/speed : 0f, 9999f, Time.fixedDeltaTime);
    }
}
