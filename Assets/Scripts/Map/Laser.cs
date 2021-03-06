﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private int m_MaxReflectionCount = 3;

    [SerializeField]
    private float m_MaxStepDistance = 200.0f;

    [SerializeField]
    private float m_SpeedTextureOffset = 5.0f;

    private LineRenderer m_Line;

    public void Awake()
    {
        m_Line = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        float offset = Time.time * m_SpeedTextureOffset;
        m_Line.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));

        DrawLineReflection(transform.position, transform.forward, m_MaxReflectionCount, 0, m_MaxStepDistance, false);
    }

    public void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.ArrowHandleCap(0, transform.position, transform.rotation, 1.0f, EventType.Repaint);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.25f);

        DrawLineReflection(transform.position, transform.forward, m_MaxReflectionCount, 0, m_MaxStepDistance, true);
    }

    private void DrawLineReflection(Vector3 position, Vector3 direction, int reflectionRemaining, int index, float remainingDistance, bool enableGizmos)
    {
        if (reflectionRemaining <= 0 || remainingDistance <= 0) return;

        Vector3 startPosition = position;

        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, remainingDistance))
        {
            if(hit.collider.CompareTag("Balao")){
                hit.collider.GetComponentInParent<PlayerManager>().m_Ballons--;
                Destroy(hit.collider.gameObject);
            }
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
            remainingDistance -= Vector3.Distance(startPosition, position);
        }
        else
        {
            position += direction * remainingDistance;
            remainingDistance -= Vector3.Distance(startPosition, position);
        }

        if (!enableGizmos)
        {
            if (index == 0)
            {
                m_Line.SetPosition(index, startPosition);
                index++;
            }

            m_Line.positionCount = index + 1;
            m_Line.SetPosition(index, position);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(startPosition, position);
        }

        DrawLineReflection(position, direction, reflectionRemaining - 1, index + 1, remainingDistance, enableGizmos);
    }
}
