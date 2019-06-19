using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int m_Coins = 0;
    public int m_Arrows = 10;
    public int m_Ballons = 3;

    [SerializeField] private bool m_IsUsingJoystick;
    [SerializeField] KeyCode m_RespawnKey = KeyCode.R;
    [SerializeField] Transform m_RespawnPoint;

    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.y <= -10.0f)
        {
            RespawnCar();
        }

        if (Input.GetKeyDown(m_RespawnKey))
        {
            RespawnCar();
        }
    }

    void RespawnCar()
    {
        transform.position = m_RespawnPoint.position;
        transform.rotation = m_RespawnPoint.rotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (m_Coins - 3 < 0)
        {
            m_Ballons--;
            Destroy(GetComponentInChildren<Balao>().gameObject);
        }
        else
        {
            m_Coins -= 3;
        }
    }
}
