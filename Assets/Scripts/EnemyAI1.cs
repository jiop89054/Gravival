using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI1 : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent agent;
    public bool tracking;
    public Rigidbody rb;
    public RaycastHit hit;

    public EnemyAI1 instance;
    public Transform firePoint;
    public GameObject enemyBulletPrefab;
    public float bulletForce;

    public Vector3 directionToPlayer;
    public Vector3 enemyPosition;

    public LayerMask playerMask;
    public LayerMask groundMask;

    public string detectedTag;
    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //agent.destination = player.position;
        StartCoroutine(TrackPlayer());
        instance = this;
    }
    public void Update()
    {
        
    }
    IEnumerator TrackPlayer()
    {
        for (; ; )
        {
            if (agent.enabled)
            {
                enemyPosition = transform.position;
                directionToPlayer = player.position - enemyPosition;
                Ray ray = new Ray(enemyPosition, directionToPlayer);
                RaycastHit hitData;
                Physics.Raycast(ray, out hitData, 1000, 576);
                detectedTag = hitData.collider.tag;
                if (hitData.collider.tag == "Player")
                {
                    agent.isStopped = true;
                    tracking = false;
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                    Shoot(enemyBulletPrefab);
                }
                else
                {
                    agent.isStopped = false;
                    tracking = true;
                    agent.destination = player.position;
                }

                //enemyPosition = transform.position;
                //directionToPlayer = player.position - enemyPosition;
                Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
                Vector3 rotation = lookRotation.eulerAngles;
                transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                
            }
            yield return new WaitForSeconds(.7f);
        }
    }
    void Shoot(GameObject bulletType)
    {
        GameObject bullet = Instantiate(bulletType, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        FindObjectOfType<AudioManager>().Play("EnemyShoot");
    }
}
