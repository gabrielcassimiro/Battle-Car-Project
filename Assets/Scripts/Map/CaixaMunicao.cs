using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaMunicao : MonoBehaviour
{
    private PlayerManager m_Player;

    private void OnTriggerEnter(Collider other) {
        
        if(!(other.CompareTag("Player1") || other.CompareTag("Player2"))){
            return;
        }

        m_Player = other.GetComponent<PlayerManager>();

        m_Player.m_Arrows += 5;
        Destroy(this.gameObject);

    }
}
