using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            health.takeDamage(10);
            Destroy(gameObject);
        }
        if(other.tag != "Enemy" && other.tag != "Bullet")
        Destroy(gameObject);
        
    }
}
