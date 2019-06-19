using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{

    [SerializeField] private GameObject m_RespawnObject;

    public float m_TimeToRespawn = 5.0f;

    private void OnTriggerExit(Collider other) {
        if(!(other.CompareTag("CaixaMunicao") || other.CompareTag("Moeda"))){
            return;
        }

        StartCoroutine(RespawnObj());
    }

    IEnumerator RespawnObj(){

        yield return new WaitForSeconds(m_TimeToRespawn);

        Instantiate(m_RespawnObject, transform.position, Quaternion.identity, transform.parent);

    }

}
