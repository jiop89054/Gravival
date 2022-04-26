using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ImpactPush : MonoBehaviour
{
    public Vector3 bulletVelocity;
    public float pushStrength;
    public Rigidbody bulletBody;
    public Rigidbody targetBody;
    public EnemyPhysicsReset targetPhysics;
    private void Awake()
    {
        Invoke("delayedInitialization", .1f);
        Invoke("killBall", 3f);
    }
    private void delayedInitialization()
    {
        bulletVelocity = bulletBody.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Movable" || collision.gameObject.tag == "Enemy")
        {
            targetBody = collision.gameObject.GetComponent<Rigidbody>();
            targetBody.AddForce(bulletVelocity.normalized * pushStrength);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            targetPhysics = collision.gameObject.GetComponent<EnemyPhysicsReset>();
            targetPhysics.initiateCoroutine();
        }
        if(collision.gameObject.tag != "Player")
        Destroy(gameObject);
        
    }
    void killBall()
    {
        Destroy(gameObject);
    }
}
