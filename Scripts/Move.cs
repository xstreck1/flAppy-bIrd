using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float tileSize = 1f;
    public float speed = 2f;

    void Update()
    {
        {
            transform.localPosition += Vector3.left * Time.deltaTime * speed;
            if (transform.localPosition.x < -tileSize / 2f)
            {
                transform.localPosition += Vector3.right * tileSize;
            }
        }
    }
}
