// PipeSet.cs
using UnityEngine;

public class PipeSet : MonoBehaviour
{
    public Transform getPipe()
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
        return leftChild;
    }

    public void ResetPos()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Pipes>().InitialPosition();
        }
    }
}
