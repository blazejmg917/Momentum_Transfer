using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //the only instance of the GameManager utilizing a singleton 
    private static GameManager instance;
    //whether the game is currently paused or not
    private static bool isPaused = false;

    public static GameManager GetInstance()
    {
        return instance;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //check if the game is paused or not
    public bool Paused()
    {
        return isPaused;
    }
    //pause or unpause the game
    public bool Pause()
    {
        //if the game is paused, unpause it
        if (isPaused)
        {
            Time.timeScale = 1.0F;
            isPaused = false;
            Debug.Log("Unpaused");
        }
        //if the game is unpaused, pause it
        else
        {
            Time.timeScale = 0.0F;
            isPaused = true;
            Debug.Log("Paused");
        }
        return isPaused;
    }
}
