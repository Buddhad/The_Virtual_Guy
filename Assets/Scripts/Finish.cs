using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource winSoundEffect;
    private bool levelCompeleted = false;
   
    void Start()
    {
        winSoundEffect = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompeleted )
        {
            winSoundEffect.Play();
            levelCompeleted = true;
            Invoke("CompleteLevel", 2f);
            
        }

    }
   
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
