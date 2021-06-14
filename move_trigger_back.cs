using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_trigger_back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if(collision.collider.tag == "ground")
        {
            GetComponentInParent<moving_obj>().movingfront = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
    }

}
