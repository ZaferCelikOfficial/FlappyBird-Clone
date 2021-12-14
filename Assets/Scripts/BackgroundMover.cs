using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    BoxCollider2D boxCollider;
    private float width;
    public float scrollspeed=-4.3f;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        width = boxCollider.size.x;
        boxCollider.enabled = false;
    }

    void Update()
    {
        if (GameManager.isGameStarted && !GameManager.isGameEnded)
        {
            if (transform.position.x < -40)
            {
                Vector2 resetPosition = new Vector2(width * 2, 0);
                transform.position = (Vector2)transform.position + resetPosition;
            }
        }
    }
}
