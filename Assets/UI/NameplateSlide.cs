using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameplateSlide : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip NameplateSlidingSound;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartSliding();
    }
    public void StartSliding()
    {
        transform.LeanMoveLocal(new Vector2(0, 900),1);
        audioSource.PlayOneShot(NameplateSlidingSound);
    }
}
