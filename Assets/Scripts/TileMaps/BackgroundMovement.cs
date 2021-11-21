using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float mapSizeY = 0;
    public float mapSizeX = 0;

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
        if (mapSizeY != 0)
        {
            currentY -= moveSpeed * Time.deltaTime;

            if (currentY < -mapSizeY)
            {
                currentY += mapSizeY;
            }
        }

        if (mapSizeX != 0)
        {
            currentX -= moveSpeed * Time.deltaTime;

            if (currentX < -mapSizeX)
            {
                currentX += mapSizeX;
            }
        }

        transform.position = new Vector3(currentX, currentY, transform.position.z) ;
    }
}
