using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 300f;
    [SerializeField] private bool IsHitSomething;
    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(!IsHitSomething){
            transform.rotation = Quaternion.LookRotation(rb.velocity)
                * Quaternion.Euler(Vector3.right * 90)
                * Quaternion.Euler(Vector3.up * Time.time * RotateSpeed);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(!other.collider.CompareTag("Bullet")){
            IsHitSomething = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(destroyCoroutine());
        }
    }
    
    private IEnumerator destroyCoroutine(){
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
