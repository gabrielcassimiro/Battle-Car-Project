using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public PlayerManager m_PlayerManager1;
    [HideInInspector] public PlayerManager m_PlayerManager2;

    public float m_Timer = 120.0f;
    public float m_SuddentDeathTimer = 30.0f;
    private int m_Player1CoinOld;
    private int m_Player2CoinOld;
    private int m_Player1BallonOld;
    private int m_Player2BallonOld;

    public bool m_GameOver = false;
    public bool m_Paused = false;
    private bool m_SuddenDeath = false;

    private void Start()
    {
        m_PlayerManager1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerManager>();
        m_PlayerManager2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        m_Timer -= Time.deltaTime;
        if (m_SuddenDeath)
        {
            if(m_Player1BallonOld > m_PlayerManager1.m_Ballons || m_Player1CoinOld < m_PlayerManager1.m_Coins)
            {
                GameOver(m_PlayerManager2);
            }
            if(m_Player2BallonOld > m_PlayerManager2.m_Ballons || m_Player2CoinOld < m_PlayerManager2.m_Coins)
            {
                GameOver(m_PlayerManager1);
            }
            if(m_Timer <= 0)
            {
                GameOver(null);
            }
        }
        if (m_Timer <= 0 && !m_SuddenDeath)
        {
            if (m_PlayerManager1.m_Coins == m_PlayerManager2.m_Coins)
            {
                SuddenDeath();
            }
            else if(m_PlayerManager1.m_Coins > m_PlayerManager2.m_Coins)
            {
                GameOver(m_PlayerManager1);
            }
            else
            {
                GameOver(m_PlayerManager2);
            }
        }
        if(m_PlayerManager1.m_Ballons <= 0)
        {
            GameOver(m_PlayerManager2);
        }
        if(m_PlayerManager2.m_Ballons <= 0)
        {
            GameOver(m_PlayerManager1);
        }
    }

    private void PauseGame()
    {
        m_Paused = true;
    }

    private void GameOver(PlayerManager winner)
    {
        m_GameOver = true;
        if (winner == null)
        {
            GetComponent<HUD>().m_GameOverText.text = "EMPATE";
        }
        else
        {
            GetComponent<HUD>().m_GameOverText.text = winner.name + " Ganhou";
        }
        PauseGame();
    }

    public void Retry()
    {
        Time.timeScale = 1;
    }

    private void SuddenDeath()
    {
        m_Player1BallonOld = m_PlayerManager1.m_Ballons;
        m_Player1CoinOld   =   m_PlayerManager1.m_Coins;
        m_Player2BallonOld = m_PlayerManager2.m_Ballons;
        m_Player2CoinOld   =   m_PlayerManager2.m_Coins;
        m_SuddenDeath = true;
        m_Timer = m_SuddentDeathTimer;
    }
}
