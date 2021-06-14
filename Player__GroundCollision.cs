using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player__GroundCollision : MonoBehaviour
{
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }else if(other.gameObject.tag == "moving")
        {
            isGrounded = true;

            GetComponentInParent<PlayerController>().gameObject.transform.SetParent(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
        else if (other.gameObject.tag == "moving")
        {
            isGrounded = false;
            GetComponentInParent<PlayerController>().gameObject.transform.SetParent(null);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        else if (other.gameObject.tag == "moving")
        {
            isGrounded = true;
            GetComponentInParent<PlayerController>().gameObject.transform.parent = other.transform;
        }
    }
}
