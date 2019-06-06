using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDemolicao : MonoBehaviour
{
    [Range(0f, 360f)]
    public float m_Angle = 60.0f;
    private bool m_TrocarVelocidade = true;
    [SerializeField] private float m_Step = 15.0f;

    private HingeJoint m_HingeJoint;

    public void Start()
    {
        m_HingeJoint = GetComponent<HingeJoint>();
        m_HingeJoint.useLimits = true;
        m_HingeJoint.useMotor = true;

        JointLimits jointLimits = m_HingeJoint.limits;
        jointLimits.min = -m_Angle;
        jointLimits.max = m_Angle;

        m_HingeJoint.limits = jointLimits;
    }

    public void FixedUpdate()
    {
        //Debug.Log("Angulo: " + m_HingeJoint.angle);
        // if (Mathf.Approximately(Mathf.Abs(m_HingeJoint.angle), m_Angle))
        if (m_HingeJoint.angle >= m_Angle - m_Step && m_TrocarVelocidade)
        {
            JointMotor jointMotor = m_HingeJoint.motor;
            jointMotor.targetVelocity *= -1;
            m_HingeJoint.motor = jointMotor;
            m_TrocarVelocidade = false;
        }
        
        if (m_HingeJoint.angle <= -m_Angle + m_Step && !m_TrocarVelocidade)
        {
            JointMotor jointMotor = m_HingeJoint.motor;
            jointMotor.targetVelocity *= -1;
            m_HingeJoint.motor = jointMotor;
            m_TrocarVelocidade = true;
        }

    }
}
