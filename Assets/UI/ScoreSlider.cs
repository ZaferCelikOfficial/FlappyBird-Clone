using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSlider : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    AudioSource audioSource;
    [SerializeField] AudioClip SlidingSound;
    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        if (this.gameObject.tag == "GameOver")
        {
            SlideGameOver();
        }
        else
        {
            Invoke("SlideTowardsScreen", delay);
        }   
    }
    void SlideGameOver()
    {
        transform.LeanMoveLocal(new Vector2(0, 350), 0.5f);
        audioSource.PlayOneShot(SlidingSound);
    }
    void SlideTowardsScreen()
    {
        transform.LeanMoveLocal(new Vector2(0, 0),0.5f);
        audioSource.PlayOneShot(SlidingSound);
    }
}
