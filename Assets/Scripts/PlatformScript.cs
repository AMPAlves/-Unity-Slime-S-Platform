using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private Transform startPos, endPos;
    public List<Transform> positions;
    public float speed = 0.5f;

    private float startTime, totalDistance;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        if (positions.Count >= 2)
            lerpFunction();
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) * speed;
        if (t > 1)
        {
            lerpFunction();
            t -= 1;
            startTime = Time.time;
        }
        transform.position = Vector3.Lerp(startPos.position, endPos.position, t);
    }

    private void lerpFunction()
    {
        if (counter == positions.Count-1)
        {
            startPos = positions[counter];
            endPos = positions[0];
            counter = 0;
        }
        else
        {
            startPos = positions[counter];
            endPos = positions[counter+1];
            counter++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.SetParent(null);
        }
    }
}
