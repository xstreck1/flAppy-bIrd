using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    float boundary = 2f;
    float originalX = 0f;
    public float randomizeY = .5f;
    public float speed = 1f;


    private void Start()
    {
        originalX = transform.localPosition.x;
        transform.localPosition = Vector3.Scale(transform.position, Vector3.right + Vector3.forward) + Vector3.up * Random.Range(-randomizeY, randomizeY);
    }

    public void ResetPos()
    {
        transform.localPosition = new Vector3(originalX, Random.Range(-randomizeY, randomizeY), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * Time.deltaTime * speed;
        if (transform.localPosition.x <= -boundary)
        {
            transform.localPosition = Vector3.Scale(transform.localPosition, Vector3.right + Vector3.forward) + Vector3.up * Random.Range(-randomizeY, randomizeY);
            transform.localPosition += Vector3.right * 6;
        }
    }
}