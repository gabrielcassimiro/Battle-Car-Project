using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balao : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser") || other.CompareTag("Bullet"))
        {
            GetComponentInParent<PlayerManager>().m_Baloes--;
            Destroy(this.gameObject);
        }
    }
}
