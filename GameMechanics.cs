using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;


public class GameMechanics : MonoBehaviour
{
    public GameObject Map1;
    public GameObject Map2;
  

    public float timer = 5f;
    float total_time;
    public bool isalt = false;
    public bool canpress = false;

    public Volume volume;

    public ColorAdjustments ca;
    public ChromaticAberration abb;

    public Image UI_slider;

    public AudioSource ar_in;
    public AudioSource ar_out;

    // Start is called before the first frame update
    void Start()
    {
        total_time = timer;
        volume.profile.TryGet(out ca);
        volume.profile.TryGet(out abb);
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKey(KeyCode.Mouse2) && timer > 0f && canpress)
            {
                UI_slider.fillAmount -= (Time.deltaTime / total_time);
                timer -= Time.deltaTime;
                if(timer < 0f)
                {
                    canpress = false;
                }
                MapShow_remove(Map1, false);
                MapShow_remove(Map2, true);
                isalt = true;
                if (isalt && abb.intensity.value < 1)
                {
                    ca.saturation.value -= Time.deltaTime * 100 * 3;
                    abb.intensity.value += Time.deltaTime * 3;
                }

            }
            else
            {
                if (timer < 5f)
                {
                    UI_slider.fillAmount += (Time.deltaTime / total_time);
                    timer += Time.deltaTime;
                    
                }
                else
                {
                    UI_slider.fillAmount = 1;
                    timer = 5f;
                }
    
                if(timer > 1f)
                {
                    canpress = true;
                }
                isalt = false;
                MapShow_remove(Map1, true);
                MapShow_remove(Map2, false);
                if (!isalt && abb.intensity.value > 0)
                {
                    ca.saturation.value += Time.deltaTime * 100 * 3;
                    abb.intensity.value -= Time.deltaTime * 3;
                }
            }

            if(Input.GetKeyDown(KeyCode.Mouse2) && timer > 0f && canpress)
            {
                ar_in.Play();
            }
            if(Input.GetKeyUp(KeyCode.Mouse2))
            {
                ar_out.Play();
            }

    }

    void MapShow_remove(GameObject Map,bool value)
    {
        Transform[] objs = Map.GetComponentsInChildren<Transform>();

        
        foreach(Transform trs in objs)
        {
            if(trs.gameObject.GetComponent<MeshRenderer>() != null)
                trs.gameObject.GetComponent<MeshRenderer>().enabled = value;
        }
    }
}
