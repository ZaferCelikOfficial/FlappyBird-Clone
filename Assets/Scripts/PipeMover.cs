using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    BoxCollider2D boxCollider;
    private float width;
    public float scrollspeed = -4.3f;
    [SerializeField] float pipeRandomer = 5f;
    PipePosition firstPosition;
    void Awake()
    {
        firstPosition = FindObjectOfType<PipePosition>();
    }
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(GameManager.isGameStarted && !GameManager.isGameEnded)
        {
            if (transform.position.x < -26)
            {
                transform.position = new Vector3(firstPosition.transform.position.x, firstPosition.transform.position.y + Random.Range(-pipeRandomer, pipeRandomer), firstPosition.transform.position.z);
            }
        }
    }
}
