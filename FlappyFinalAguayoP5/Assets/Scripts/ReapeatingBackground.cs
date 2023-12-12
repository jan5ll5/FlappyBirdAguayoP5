using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontallength;
    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontallength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontallength)
        {
            RepositionBackground();
        }
    }
    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontallength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
