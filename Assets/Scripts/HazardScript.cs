using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER NO HAZARD");
        if (other.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.position;
            FindObjectOfType<GameBehaviour>().takeDamage(25);
        }
    }
}
