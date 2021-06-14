using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updown_hover : MonoBehaviour
{

    public float target;
    public float current;
    public float offset;
    public bool moveup = false;
    // Start is called before the first frame update
    void Start()
    {
        current = transform.position.y;
        target = transform.position.y + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= current)
        {
            moveup = true;
        }else if(transform.position.y >= target)
        {
            moveup = false;
        }

        if(moveup)
        {
            transform.position += new Vector3(0, Time.deltaTime, 0);
        }else
            transform.position -= new Vector3(0, Time.deltaTime, 0);
    }
}
