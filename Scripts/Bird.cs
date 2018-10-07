using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Agent
{
    Rigidbody2D myBody;
    public float forceRatio = 1f;
    Vector3 startPos;
    bool dead = false;
    bool pushed = false;
    public PipeSet pipes;
    public float counter = 0f;
    const float height = 2f;

    public Sprite normal;
    public Sprite flap;

    public void Push()
    {
        myBody.AddForce(Vector2.up * forceRatio, ForceMode2D.Impulse);
    }

    private void Update()
    {
        counter += Time.deltaTime;
    }

    public override void InitializeAgent()
    {
        myBody = GetComponent<Rigidbody2D>();
        startPos = transform.localPosition;
    }

    public override void CollectObservations()
    {
        AddVectorObs(gameObject.transform.localPosition.y / height);
        AddVectorObs(Mathf.Clamp(myBody.velocity.y, -height, height) / height);
        Vector3 pipePos = pipes.getPipe().localPosition;
        AddVectorObs((pipePos.y - .6f) / height);
        AddVectorObs((pipePos.y + .6f) / height);
        AddVectorObs(pushed ? 1f : -1f);
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

            int jump = Mathf.FloorToInt(vectorAction[0]);
            if (jump == 0)
            {
                pushed = false;
            }
            if (jump == 1 && !pushed)
            {
                pushed = true;
                Push();
            }
        }
    }

    public override void AgentReset()
    {
        myBody.velocity = Vector3.zero;
        transform.localPosition = startPos;
        dead = false;
        counter = 0f;
        pipes.ResetPos();
    }

    private void OnTriggerEnter2D(Collider2D collision2d)
    {
        dead = true;
    }

}
