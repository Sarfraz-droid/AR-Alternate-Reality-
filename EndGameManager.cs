using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public Animator UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void End()
    {
        StartCoroutine(End_Start());
    }
    IEnumerator End_Start()
    {
        UI.SetBool("goback", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
