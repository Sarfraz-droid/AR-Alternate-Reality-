using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1_Door_Open : MonoBehaviour
{

    public float castRadius = 10f;
    public GameObject UI;
    [SerializeField] bool ispressed = false;
    public Animator Door_Anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MeshRenderer>().enabled == false)
            return;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, castRadius);
        if (!ispressed)
        {
            bool isPlayerin = false;
            foreach (Collider hit in hitColliders)
            {
                Debug.Log(hit.gameObject.tag);
                if (hit.gameObject.tag == "Player")
                {
                    isPlayerin = true;
                    UI.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        ispressed = true;
                        Door_Anim.gameObject.GetComponent<door_audio>().AudioPlay();
                        Door_Anim.SetBool("isOpen", true);
                    }
                }

                if(!isPlayerin)
                {
                    UI.SetActive(false);
                }
            }
        }else
        {
            UI.SetActive(false);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, castRadius);
    }
}
