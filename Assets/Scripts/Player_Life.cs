using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Life : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            
            Death();
        }
    }

    private void Death()
    {
        deathSoundEffect.Play();
        rbody.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
