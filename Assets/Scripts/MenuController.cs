using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{
    public void OnPlayButton ()
    {
        SceneManager.LoadScene("Scenes/Minigame");
        FindObjectOfType<AudioManager>().Play("Start");
    }
}
