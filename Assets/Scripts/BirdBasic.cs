// BirdBasic.cs
using UnityEngine;

public class BirdBasic : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Vector3 startPos;
    public PipeSet pipes;
    
    public float counter = 0f;
    
    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        startPos = transform.localPosition;
    }
    
    private void Update()
    {
        counter += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Push();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision2d)
    {
        ResetPos();
    }
    
    public void Push()
    {
        myBody.AddForce(Vector2.up * 4f, ForceMode2D.Impulse);
    }
    
    public void ResetPos()
    {
        myBody.velocity = Vector3.zero;
        transform.localPosition = startPos;
        pipes.ResetPos();
        counter = 0;
    }
}
