using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponte : MonoBehaviour
{
    [SerializeField]
    private HingeJoint[] m_Joints;

    [SerializeField]
    private float[] m_Targets = { 90.0f, 0.0f };

    [SerializeField]
    private float m_TimeToEnableBridge = 25.0f;
    private float m_TimeToDisableBridge = 5.0f;
    private float m_Time = 0.0f;

    private int m_CurrentTarget;

    private void Update()
    {
        m_Time += Time.deltaTime;
        if (m_Time > m_TimeToEnableBridge)
        {
            StartCoroutine(EnableBridge());
            m_Time = 0.0f;
        }
    }

    IEnumerator EnableBridge()
    {
        ToggleBridge();

        yield return new WaitForSeconds(m_TimeToDisableBridge);

        ToggleBridge();
    }

    private void ToggleBridge()
    {
        foreach (HingeJoint joint in m_Joints)
        {
            JointSpring spring = joint.spring;
            spring.targetPosition = m_Targets[m_CurrentTarget];

            joint.spring = spring;
        }
        m_CurrentTarget = ++m_CurrentTarget % m_Targets.Length;
    }
}
