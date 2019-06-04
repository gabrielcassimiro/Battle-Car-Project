using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float m_SmoothTime;
    [SerializeField] private float m_Magnitude;
    [SerializeField] private Vector3 m_MoveAxisPosition = Vector3.up;
    private Vector3 m_OriginalPosition;

    void Start()
    {
        m_OriginalPosition = transform.localPosition;
    }

    void Update()
    {
        float movement = m_Magnitude * Mathf.Sin(Time.time * (1 / m_SmoothTime));
        transform.position = m_OriginalPosition + m_MoveAxisPosition * movement;
    }
}
