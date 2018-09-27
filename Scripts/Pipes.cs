using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float yPos = 0f;
    public float xPos = 0f;

    public Vector3 getPipe()
    {
        float leftMost = float.MaxValue;
        Transform leftChild = null;
        foreach (Transform child in transform)
        {
            if (child.localPosition.x < leftMost && child.localPosition.x > -.35f)
            {
                leftChild = child;
                leftMost = child.localPosition.x;
            }
        }
        yPos = leftChild.localPosition.y;
        xPos = leftChild.localPosition.x;
        return leftChild.localPosition;
    }

    public void ResetPos()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<MovePipe>().ResetPos();
        }
    }
}
