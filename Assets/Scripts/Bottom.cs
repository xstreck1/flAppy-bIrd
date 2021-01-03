// Bottom.cs
using UnityEngine;

public class Bottom : MonoBehaviour
{
    public float tileSize = 3.36f;

    private void LateUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
        if (transform.localPosition.x < -tileSize)
        {
            transform.Translate(Vector3.right * tileSize);
        }
    }
}
