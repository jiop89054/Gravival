using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPhysicsReset : MonoBehaviour
{
    public EnemyPhysicsReset instance;
    public NavMeshAgent targetAI;
    public Rigidbody rb;

    private void Awake()
    {
        instance = this;
    }

    public void initiateCoroutine()
    {
        StopAllCoroutines();
        StartCoroutine(EnablePhysics());
    }
    IEnumerator EnablePhysics()
    {
        targetAI.enabled = false;
        yield return new WaitForSeconds(2f);
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        targetAI.enabled = true;
        yield return null;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 12)
            Destroy(gameObject);
    }
}
