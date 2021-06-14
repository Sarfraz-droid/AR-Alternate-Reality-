using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number_check : MonoBehaviour
{
    // Start is called before the first frame update

    public bool ischecked = false;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="num_box")
        {
            ischecked = true;
            collision.collider.GetComponent<Outline>().OutlineWidth = 10f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "num_box")
        {
            ischecked = true;   
            collision.collider.GetComponent<Outline>().OutlineWidth = 10f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "num_box")
        {
            ischecked = false;
            collision.collider.GetComponent<Outline>().OutlineWidth = 1f;
        }
    }
}
