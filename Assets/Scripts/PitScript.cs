using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitScript : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<MenuScript>().LoadLevel("EndScreen");
        }
        else if (other.gameObject.tag != "Ground")
        {
            Destroy(other.gameObject);
        }
    }
}
