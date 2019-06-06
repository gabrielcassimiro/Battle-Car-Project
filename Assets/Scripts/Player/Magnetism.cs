using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetism : MonoBehaviour
{
    public enum MagnetismType { Repulsion = -1, None = 0, Attraction = 1 };
    public MagnetismType m_Type = MagnetismType.None;

    public Transform m_CenterPoint;
    public float m_Radius;
    public float m_StopRadius;
    public float m_Force;
    public LayerMask m_Layers;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(m_CenterPoint.position, m_Radius, m_Layers);

        float signal = (int)m_Type;

        foreach (var collider in colliders)
        {
            Rigidbody body = collider.GetComponent<Rigidbody>();
            if (!body) continue;

            Vector3 direction = m_CenterPoint.position - body.position;

            float distance = direction.magnitude;
            if (distance < m_StopRadius) continue;

            body.AddForce(direction.normalized * (m_Force / distance) * body.mass /* * Time.deltaTime*/ * signal);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 255, 0, 0.2f);
        Gizmos.DrawSphere(m_CenterPoint.position, m_StopRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moeda") || other.CompareTag("CaixaMunicao"))
        {
            other.GetComponent<MoveObject>().enabled = false;
            other.GetComponent<RotateObject>().enabled = false;
        }
    }
}
