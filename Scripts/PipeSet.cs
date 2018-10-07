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
            if (child.localPosition.x < leftMost &&
                child.localPosition.x > -.3f)
            {
                leftChild = child;
                leftMost = child.localPosition.x;
            }
        }
        return leftChild;
    }
}