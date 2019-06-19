using UnityEngine;

[RequireComponent(typeof(CarKinematics))]
public class CarController : MonoBehaviour
{
    private CarKinematics m_CarKinematics;

    [Header("Player Input Names")]
    public string m_HorizontaAxisName = "Horizontal";
    public string m_AccelerateAxisName = "Accelerate";
    public string m_ReAxisName = "Ré";
    public string m_BrakeButtonName = "Brake";

    private void Awake()
    {
        m_CarKinematics = GetComponent<CarKinematics>();
    }

    public void Update()
    {
        m_CarKinematics.Horizontal = Input.GetAxis(m_HorizontaAxisName);
        m_CarKinematics.Vertical = Input.GetAxis(m_AccelerateAxisName) + Input.GetAxis(m_ReAxisName);
        m_CarKinematics.Brake = Input.GetButton(m_BrakeButtonName);
    }
}
