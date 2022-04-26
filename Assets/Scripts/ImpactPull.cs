using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactPull : MonoBehaviour
{
    public Vector3 bulletVelocity;
    public Vector3 invertedVelocity;
    public float pullStrength;
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
        //invertedVelocity = new Vector3(-bulletVelocity.x, -bulletVelocity.y, -bulletVelocity.z);
        invertedVelocity = -bulletVelocity;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Movable") {
            Rigidbody targetRB = collision.gameObject.GetComponent<Rigidbody>();
            targetRB.AddForce(invertedVelocity * pullStrength);
        }
        Destroy(gameObject);
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Movable" || collision.gameObject.tag == "Enemy")
        {
            targetBody = collision.gameObject.GetComponent<Rigidbody>();
            targetBody.AddForce(invertedVelocity.normalized * pullStrength);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            targetPhysics = collision.gameObject.GetComponent<EnemyPhysicsReset>();
            targetPhysics.initiateCoroutine();
        }
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);

    }
    void killBall()
    {
        Destroy(gameObject);
    }
}
