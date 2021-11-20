using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float mapSize = 55f;

    private float currentY, currentX;
    // Start is called before the first frame update
    void Start()
    {
        currentY = transform.position.y;
        currentX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentY -= moveSpeed * Time.deltaTime;

        if (currentY < -mapSize)
        {
            currentY += mapSize;
        }

        transform.position = new Vector2(currentX, currentY);
    }
}
