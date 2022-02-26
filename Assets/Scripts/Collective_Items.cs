using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collective_Items : MonoBehaviour
{
    [SerializeField]private Text ScoreText;
    private int score = 00;
    [SerializeField] private AudioSource collectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collective_items"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            score++;
            ScoreText.text = "Score : " + score;
        }
    }

}
