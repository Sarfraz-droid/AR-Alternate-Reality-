using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassManager : MonoBehaviour
{
    public GameObject[] ans;
    public Animator door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool final_check = true;
        foreach(GameObject obj in ans)
        {
            if(obj.GetComponent<number_check>().ischecked == false)
            {
                final_check = false;
            }
        }

        if(final_check == true && door.GetBool("isOpen")==false)
        {
            door.gameObject.GetComponent<door_audio>().AudioPlay();
            door.SetBool("isOpen", true);
        }
    }
}
