// Pipes.cs
using UnityEngine;

public class Pipes : MonoBehaviour
{
    const float spacing = 2f; // Distance between pipes
    const int totalPipes = 3;
    private Vector3 origPosition;
    public float pipeVariance = .5f;

    private void Awake()
    {
        origPosition = transform.localPosition;
        RandomizeY(); 
    }

    private void LateUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
        if (transform.localPosition.x < -spacing)
        {
            transform.Translate(Vector3.right *
                spacing * totalPipes);
        }
    }

    public void InitialPosition()
    {
        transform.localPosition = origPosition;
        RandomizeY();
    }

    private void RandomizeY()
    {
        transform.Translate(Vector3.up
            * Random.Range(-pipeVariance, pipeVariance));
    }
}