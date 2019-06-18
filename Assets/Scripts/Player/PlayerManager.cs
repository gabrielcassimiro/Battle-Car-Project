using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int m_Coins = 0;
    public int m_Arrows = 10;
    public int m_Ballons = 3;

    void Start()
    {
        if(this.tag == "Player1")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void Update()
    {

    }
}
