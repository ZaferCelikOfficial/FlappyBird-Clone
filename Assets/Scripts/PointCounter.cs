using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip CoinSound;
    int point = 1;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        GameManager.instance.PointCounter(point);
        audioSource.PlayOneShot(CoinSound);
    }
}
