using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform player;
    public GameObject UIMenuManager;

    public float sensitivity = 10;

    float x = 0;
    float y = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (UIMenuManager.GetComponent<UIMenuManager>().lookpause == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        //input
        x += -Input.GetAxis("Mouse Y") * sensitivity;
        y += Input.GetAxis("Mouse X") * sensitivity;

        //clamping
        x = Mathf.Clamp(x, -90, 90);

        //rotation
        transform.localRotation = Quaternion.Euler(x, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, y, 0);
    }
}