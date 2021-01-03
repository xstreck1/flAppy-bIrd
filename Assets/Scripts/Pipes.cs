// Pipes.cs
using UnityEngine;

public class Pipes : MonoBehaviour
{
    private const float spacing = 2f; // Distance between pipes
    private const int totalPipes = 3;
    private Vector3 startPos;
    public float pipeVariance = .5f;

    private void Awake()
    {
        startPos = transform.localPosition;
        RandomizeY(); 
    }
    
    private void LateUpdate()
    {
        var trans = transform;
        trans.Translate(Vector3.left * Time.deltaTime);
        if (trans.localPosition.x < -spacing)
        {
            trans.Translate(Vector3.right * spacing * totalPipes);
        }
    }

    public void InitialPosition()
    {
        transform.localPosition = startPos;
        RandomizeY();
    }

    private void RandomizeY()
    {
        float posY = Random.Range(-pipeVariance, pipeVariance);
        transform.Translate(Vector3.up * posY);
    }
}