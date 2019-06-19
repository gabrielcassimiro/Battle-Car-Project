using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [HideInInspector] public PlayerManager m_PlayerManager1;
    [HideInInspector] public PlayerManager m_PlayerManager2;

    [HideInInspector] public float m_Timer = 120.0f;
    [SerializeField] private float m_MaxTimer = 120.0f;
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
        m_Timer = m_MaxTimer;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if(!m_GameOver) m_Timer -= Time.deltaTime;
        if (m_SuddenDeath)
        {
            if(m_Player1BallonOld > m_PlayerManager1.m_Ballons || m_Player1CoinOld < m_PlayerManager1.m_Coins 
                || m_PlayerManager2.m_Coins > m_PlayerManager1.m_Coins || m_PlayerManager2.m_Ballons > m_PlayerManager1.m_Ballons)
            {
                GameOver(m_PlayerManager2);
            }
            if(m_Player2BallonOld > m_PlayerManager2.m_Ballons || m_Player2CoinOld < m_PlayerManager2.m_Coins
                || m_PlayerManager1.m_Coins > m_PlayerManager2.m_Coins || m_PlayerManager1.m_Ballons > m_PlayerManager2.m_Ballons)
            {
                GameOver(m_PlayerManager1);
            }
            if(m_Timer <= 0)
            {
                GameOver(null);
            }
        }
        if (m_Timer <= 0 && !m_SuddenDeath && !m_GameOver)
        {
            if (m_PlayerManager1.m_Coins == m_PlayerManager2.m_Coins && m_PlayerManager1.m_Ballons != m_PlayerManager2.m_Ballons)
            {
                SuddenDeath();
                StartCoroutine(GetComponent<HUD>().SuddenDeathText(3.0f));
            }
            else if(m_PlayerManager1.m_Coins > m_PlayerManager2.m_Coins || m_PlayerManager1.m_Ballons > m_PlayerManager2.m_Ballons)
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
            m_SuddenDeath = false;
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
        m_Timer = m_MaxTimer;
        m_GameOver = false;
        SceneManager.LoadScene("Game");
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
