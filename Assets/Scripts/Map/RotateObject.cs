using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float m_SpeedRotate;
    [SerializeField] private Vector3 m_MoveAxisRotation = Vector3.forward;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(m_MoveAxisRotation * m_SpeedRotate * Time.deltaTime);
    }
}
