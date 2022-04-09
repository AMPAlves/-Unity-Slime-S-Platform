using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int rotateSpeed;
    private int numberOfCollectables;
    private int caughtCollectables;

    private void Start()
    {
        numberOfCollectables = 1;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }

    public int getNumberCollectables()
    {
        return numberOfCollectables;
    }


    public int getCaughtCollectables()
    {
        return caughtCollectables;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameBehaviour>().addPoints();
            Destroy(gameObject);
        }
    }

}
