using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJumper : MonoBehaviour
{
    public Rigidbody rb;
    public float intensity=45f;
    [SerializeField] float maxSpeed=15;
    public Animator birdAnimator;
    AudioSource audioSource;
    [SerializeField] AudioClip WingSound;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        birdAnimator = GetComponent<Animator>();
        rb.useGravity = false;
    }
    void Jumper()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(0,intensity,0,ForceMode.Impulse);
            audioSource.PlayOneShot(WingSound);
        } 
    }
    private void Update()
    {
        if (GameManager.isGameStarted && !GameManager.isGameEnded)
        {
            Jumper();
        }
    }
    private void FixedUpdate()
    {
        if (GameManager.isGameStarted && !GameManager.isGameEnded)
        {
            CheckSpeed();
        }
    }
    void CheckSpeed()
    {
        if (rb.velocity.y > 0)
        {
            birdAnimator.SetBool("isFalling", false);
            birdAnimator.SetBool("isFlying", true);
            if (rb.velocity.y > maxSpeed)
            {
                rb.velocity = new Vector3(0, maxSpeed, 0);
            }
        }
        else if(rb.velocity.y<0&&!birdAnimator.GetBool("isFalling"))
        {
            birdAnimator.SetBool("isFlying", false);
            birdAnimator.SetBool("isFalling", true);
        }
    }
}
