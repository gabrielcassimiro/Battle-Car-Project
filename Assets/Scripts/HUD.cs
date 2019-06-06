using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text m_Player1Ballon;
    public Text m_Player1Arrows;
    public Text m_Player1Moedas;

    public Text m_Player2Ballon;
    public Text m_Player2Arrows;
    public Text m_Player2Moedas;

    PlayerManager m_PlayerManager1;
    PlayerManager m_PlayerManager2;

    private void Start()
    {
        m_PlayerManager1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerManager>();
        m_PlayerManager2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerManager>();
    }

    private void Update()
    {
        m_Player1Arrows.text = m_PlayerManager1.m_Flechas.ToString("00");
        m_Player1Moedas.text = m_PlayerManager1.m_Moedas.ToString("00");
        m_Player1Ballon.text = m_PlayerManager1.m_Baloes.ToString("0");

        m_Player2Arrows.text = m_PlayerManager2.m_Flechas.ToString("00");
        m_Player2Moedas.text = m_PlayerManager2.m_Moedas.ToString("00");
        m_Player2Ballon.text = m_PlayerManager2.m_Baloes.ToString("0");
    }
}
