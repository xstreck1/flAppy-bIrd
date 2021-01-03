// PipeSet.cs
using UnityEngine;
public class PipeSet : MonoBehaviour
{
    public void ResetPos()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Pipes>().InitialPosition();
        }
    }

    public Transform GetNextPipe()
    {
        float leftMost = float.MaxValue;
        Transform leftChild = null;
        foreach (Transform child in transform)
        {
            float childX = child.localPosition.x;
            if (childX < leftMost && childX > -.3f)
            {
                leftChild = child;
                leftMost = child.localPosition.x;
            }
        }
        return leftChild;
    }
}