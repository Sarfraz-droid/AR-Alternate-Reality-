using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject nextLevel;
    public GameObject Dead;
    public bool lookpause = false;
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        transition = GameObject.FindGameObjectWithTag("transition").GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeSelf == true)
            {
                Resume();
            }
            else
            {
                lookpause = true;
                Cursor.lockState = CursorLockMode.None;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void Resume()
    {
        lookpause = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        lookpause = true;
        nextLevel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Ded()
    {
        Cursor.lockState = CursorLockMode.None;
        lookpause = true;
        Dead.SetActive(true);
        Time.timeScale = 0f;
    }



    public void Restart()
    {
        StartCoroutine(Changelevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void Next_Level()
    {
        StartCoroutine(Changelevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator Changelevel(int value)
    {
        lookpause = false;
        Time.timeScale = 1f;
        transition.SetBool("out", true);
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(value);


    }

}
