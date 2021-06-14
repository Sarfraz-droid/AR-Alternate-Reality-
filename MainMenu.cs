using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        transition = GameObject.FindGameObjectWithTag("transition").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        StartCoroutine(PlayGame());
    }
    IEnumerator PlayGame()
    {
        transition.SetBool("out", true);
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Quit()
    {
        StartCoroutine(Quit_Game());
    }

    IEnumerator Quit_Game()
    {
        transition.SetBool("out", true);
        yield return new WaitForSeconds(0.6f);
        Application.Quit();


    }
}
