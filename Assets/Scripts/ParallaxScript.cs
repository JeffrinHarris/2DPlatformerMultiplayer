using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{

    public float amount = 0f;
    public GameObject cam;

    private Vector3 currentPos;
    private Vector3 camPos;

    [SerializeField]
    private float width;

    void Start()
    {
        currentPos = GetComponent<Transform>().position;
        camPos = cam.GetComponent<Transform>().position;
        //width = GetComponent<SpriteRenderer>().bounds.size.x/2f;
        width = 10.5f;
    }

    void Update()
    {
        float posDiff = cam.GetComponent<Transform>().position.x - camPos.x;
        float newPos = currentPos.x + amount*posDiff;

        float posChange = camPos.x - newPos;

        if(posChange > width)
            newPos += width*2;
        
        if(posChange < -1f*width)
            newPos -= width*2;

        GetComponent<Transform>().position = new Vector3(newPos,currentPos.y, currentPos.z);



        currentPos = GetComponent<Transform>().position;
        camPos = cam.GetComponent<Transform>().position;
    }
}
