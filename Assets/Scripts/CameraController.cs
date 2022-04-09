using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    public Camera[] camArr;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        camArr[counter].enabled = true;
        deactivateCams(counter);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            counter = (counter+1 >= camArr.Length ? counter = 0 : counter + 1);
            deactivateCams(counter);
            camArr[counter].enabled = true;
        } else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            counter = (counter-1 < 0 ? camArr.Length-1 : counter-1);
            deactivateCams(counter);
            camArr[counter].enabled = true;
        }
    }

    void deactivateCams(int pos)
    {
        for(int i = 0; i < camArr.Length; i++)
        {
            if(i!=pos)
                camArr[i].enabled = false;
        }
    }
}
