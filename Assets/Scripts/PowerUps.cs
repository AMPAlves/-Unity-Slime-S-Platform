using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerBehaviour>().jumpingPowerUp();
            Destroy(gameObject);
        }
    }

}
