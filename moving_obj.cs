using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_obj : MonoBehaviour
{

    public float speed = 1f;
    public bool movingfront = true;

    public float spherecastRadius = 5f;
    public Vector3 offset = Vector3.zero;
    public Vector3 forward_dirn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movingfront)
        {
            transform.localPosition -= forward_dirn * speed*Time.deltaTime;
        }else
            transform.localPosition += forward_dirn * speed*Time.deltaTime;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position+offset, spherecastRadius);


        foreach(Collider hit in hitColliders)
        {
            if(hit.gameObject.tag=="ground" && hit != this.gameObject)
            {
                if (movingfront)
                    movingfront = false;
                else
                    movingfront = true;
                break;
            }
        }
    }


    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position+offset, spherecastRadius);
    }
}
