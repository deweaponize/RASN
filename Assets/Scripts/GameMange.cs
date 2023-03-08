using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMange : MonoBehaviour
{
    public float Delay = 1f;
    public float time;
    public bool Reset = false;
    void Update()
    {
        time += Time.unscaledDeltaTime;
        if(Input.GetKey(KeyCode.Escape) && time >= Delay)
        {
            Reset = !Reset;
            time = 0f;
            // Pause
        }

        if (Reset)
        {
            Time.timeScale = 0f;
        }
        else if (!Reset)
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("This Quit in provoked");
            Application.Quit();
        }
        
    }
}
