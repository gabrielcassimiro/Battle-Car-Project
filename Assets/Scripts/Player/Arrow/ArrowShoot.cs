using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    [Header("Input Name")]
    [SerializeField] private string m_InputFire;
    
    [Header("Instantiate Arrow")]
    [SerializeField]
    private Rigidbody m_ArrowPrefab;

    [SerializeField]
    private Transform m_ArrowSpawn;

    [SerializeField]
    private float m_MinForce = 10.0f;

    [SerializeField]
    private float m_MaxForce = 50.0f;

    [SerializeField]
    private float m_TimeToMaxForce = 2.0f;

    [SerializeField]
    private float m_CurrentForce;

    private float m_ElapsedTime;

    [SerializeField]
    private float m_timeToBullet = 0;
    [SerializeField]
    private float m_BulletReady;
    [SerializeField]
    private bool Fire;

    private PlayerManager m_Player;

    private void Start() {
        m_Player = GetComponentInParent<PlayerManager>();
    }

    public void Update()
    {
        m_timeToBullet += Time.deltaTime;
        if(m_Player.m_Flechas > 0){

            if (Input.GetButton(m_InputFire) && m_timeToBullet > m_BulletReady)
            {
                m_CurrentForce = Mathf.Lerp(m_MinForce, m_MaxForce, m_ElapsedTime / m_TimeToMaxForce);
                m_ElapsedTime += Time.deltaTime;
                Fire = true;
            }

            if (Input.GetButtonUp(m_InputFire) && Fire)
            {
                Fire = false;
                m_timeToBullet = 0;
                m_ElapsedTime = 0.0f;
                Rigidbody arrow = Instantiate<Rigidbody>(m_ArrowPrefab, m_ArrowSpawn.position, m_ArrowSpawn.rotation);
                arrow.AddForce(m_ArrowSpawn.up * m_CurrentForce, ForceMode.VelocityChange);
                m_Player.m_Flechas--;
            }
        }
    }
}
