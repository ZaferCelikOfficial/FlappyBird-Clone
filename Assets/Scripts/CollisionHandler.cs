using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    PipeMover[] pipeMover;
    BackgroundMover[] backgroundMover;
    BirdJumper birdJumper;
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField]AudioClip CrashSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pipeMover=FindObjectsOfType<PipeMover>();
        backgroundMover = FindObjectsOfType<BackgroundMover>();
        birdJumper = FindObjectOfType<BirdJumper>();
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(GameManager.isGameStarted&&!GameManager.isGameEnded)
        {
            LevelFailed();
            birdJumper.birdAnimator.enabled = false;
            for(int i=0;i<pipeMover.Length;i++)
            {

                pipeMover[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            for (int i = 0; i < backgroundMover.Length; i++)
            {
                backgroundMover[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            //rb.velocity = Vector3.zero;
            //rb.Sleep();
            audioSource.PlayOneShot(CrashSound);
        }
    }
    void LevelFailed()
    {
        GameManager.instance.OnLevelFailed();
        GameManager.instance.EndGame();
    }
}
