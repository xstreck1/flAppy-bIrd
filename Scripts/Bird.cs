// Bird.cs
using MLAgents;
using UnityEngine;

public class Bird : Agent
{
    private Rigidbody2D myBody;
    private Vector3 startPos;
    private bool dead = false;

    private bool screenPressed = false;
    const float height = 2f;
    const float pipeSpace = .6f;

    public PipeSet pipes;
    public float counter = 0f;


    private void Update()
    {
        counter += Time.deltaTime;
    }

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        startPos = transform.localPosition;
    }

    private void Push()
    {
        myBody.AddForce(Vector2.up, ForceMode2D.Impulse);
    }

    public override void CollectObservations()
    {
        AddVectorObs(gameObject.transform.localPosition.y / height);
        AddVectorObs(Mathf.Clamp(myBody.velocity.y, -height, height) / height);
        Vector3 pipePos = pipes.GetNextPipe().localPosition;
        AddVectorObs((pipePos.y - pipeSpace) / height);
        AddVectorObs((pipePos.y + pipeSpace) / height);
        AddVectorObs(screenPressed ? 1f : -1f);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        if (dead)
        {
            SetReward(-1f);
            Done();
        }
        else
        {
            SetReward(0.01f);

            int tap = Mathf.FloorToInt(vectorAction[0]);
            if (tap == 0)
            {
                screenPressed = false;
            }
            if (tap == 1 && !screenPressed)
            {
                screenPressed = true;
                Push();
            }
        }
    }

    public override void AgentReset()
    {
        myBody.velocity = Vector3.zero;
        transform.localPosition = startPos;
        dead = false;
        pipes.ResetPos();
        counter = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision2d)
    {
        dead = true;
    }
}
