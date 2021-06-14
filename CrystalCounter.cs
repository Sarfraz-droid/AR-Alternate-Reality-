using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class CrystalCounter : MonoBehaviour
{
    public int total_crystals = 0;

    public TextMeshProUGUI text;

    public GameObject crystal_pop;
    public GameObject Win_gate;

    public UIMenuManager Manager;

    public AudioSource CrystalSound;
    public AudioSource winSound;
    // Start is called before the first frame update
    void Start()
    {

        Manager = GetComponentInChildren<UIMenuManager>();
        Win_gate = GameObject.FindGameObjectWithTag("WinGate");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = total_crystals + "/3";

        if(total_crystals == 3)
        {
            Win_gate.GetComponent<Animator>().SetBool("isOpen", true);
        }
    }
    


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "crystal")
        {
            total_crystals++;
            other.gameObject.SetActive(false);
            GameObject gb = Instantiate(crystal_pop,other.transform.position,Quaternion.identity);
            crystal_pop.GetComponent<ParticleSystem>().Play();
            Destroy(gb, 2f);
            CrystalSound.Play();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="win")
        {
            winSound.Play();
            Manager.Win();
        }
    }

}
