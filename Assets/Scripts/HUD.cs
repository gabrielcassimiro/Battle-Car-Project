using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text m_Player1Ballon;
    public Text m_Player1Arrows;
    public Text m_Player1Coins;

    public Text m_Player2Ballon;
    public Text m_Player2Arrows;
    public Text m_Player2Coins;

    public Text m_SuddenDeathText;
    public Text m_TimerText;

    [SerializeField] private Canvas m_GameOverCanvas;
    public Text m_GameOverText;

    GameController m_GameManager;

    private void Start()
    {
        m_GameManager = GameObject.Find("GameManager").GetComponent<GameController>();
        m_GameOverCanvas.enabled = false;
        m_SuddenDeathText.enabled = false;
    }

    private void Update()
    {
        m_Player1Arrows.text = m_GameManager.m_PlayerManager1.m_Arrows.ToString("00");
        m_Player1Coins.text  =  m_GameManager.m_PlayerManager1.m_Coins.ToString("00");
        m_Player1Ballon.text = m_GameManager.m_PlayerManager1.m_Ballons.ToString("0");

        m_Player2Arrows.text = m_GameManager.m_PlayerManager2.m_Arrows.ToString("00");
        m_Player2Coins.text  =  m_GameManager.m_PlayerManager2.m_Coins.ToString("00");
        m_Player2Ballon.text = m_GameManager.m_PlayerManager2.m_Ballons.ToString("0");

        m_TimerText.text = m_GameManager.m_Timer.ToString("000");

        if(m_GameManager.m_GameOver == true)
        {
            m_GameOverCanvas.enabled = true;
        }
    }

    public IEnumerator SuddenDeathText(float secondsToVanish)
    {

        m_SuddenDeathText.enabled = true;

        yield return new WaitForSeconds(secondsToVanish);

        m_SuddenDeathText.enabled = false;
    }
}
