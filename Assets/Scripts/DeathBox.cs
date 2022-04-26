using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<MenuScript>().LoadLevel("EndScreen");
        }
        else if (collision.gameObject.tag != "Ground")
        {
            Destroy(collision.gameObject);
        }
    }
}
