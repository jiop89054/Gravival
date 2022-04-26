using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    int waveCount;
    int spawnNumber;
    bool waveComplete;
    Vector3 spawnPosition;
    int quadrantChoice;
    float randX;
    float randZ;
    public GameObject enemy;
    public float enemiesLeft;

    public GameObject waveText;

    private void Awake()
    {
        //spawnWave(1);
    }
    private void Update()
    {
        GameObject[] enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemiesRemaining.Length;
        if (enemiesLeft == 0)
        {
            waveCount++;
            spawnWave(waveCount);
            waveText.GetComponent<TextMeshProUGUI>().text = "Wave: " + Mathf.Floor(waveCount).ToString();
            if(waveCount == 5)
            {
                FindObjectOfType<MenuScript>().LoadLevel("Win Screen");
            }
        }
    }
    public void spawnWave(int waveNumber)
    {
        for (int i = 0; i < waveNumber * 2; i++)
        {
            pickSpawn();
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
    public void pickSpawn()
    {
        quadrantChoice = Random.Range(1, 5);
        if (quadrantChoice == 1)
        {
            randX = Random.Range(10,40);
            randZ = Random.Range(-30, -15);
            spawnPosition = new Vector3(randX, 1, randZ);
        }
        if (quadrantChoice == 2)
        {
            randX = Random.Range(-40, -12);
            randZ = Random.Range(-30, -15);
            spawnPosition = new Vector3(randX, 1, randZ);
        }
        if (quadrantChoice == 3)
        {
            randX = Random.Range(10, 40);
            randZ = Random.Range(2, 19);
            spawnPosition = new Vector3(randX, 1, randZ);
        }
        if (quadrantChoice == 4)
        {
            randX = Random.Range(-40, -12);
            randZ = Random.Range(2, 19);
            spawnPosition = new Vector3(randX, 1, randZ);
        }

    }
}
