using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float speed;
    public float xScreenHalfSize = 500f;
    Transform background;

    float leftPosX = 0f;
    float rightPosX = 0f;

    void Start()
    {
        background = this.transform;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2;
    }

    void Update()
    {
        background.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

        if (background.position.x < leftPosX)
        {
            Vector3 nextPos = background.position;
            nextPos = new Vector3(nextPos.x + rightPosX, nextPos.y, nextPos.z);
            background.position = nextPos;
        }
    }
}