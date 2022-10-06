using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>().isGreen != true)
        {
            FindObjectOfType<GameManager>().EndGame(null);
        }
    }
}
