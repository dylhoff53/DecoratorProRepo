using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWall : MonoBehaviour
{
    public int value;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>().color != value || other.GetComponent<PlayerMovement>().isGreen == true)
        {
            FindObjectOfType<GameManager>().EndGame(null);
        }
    }

}
