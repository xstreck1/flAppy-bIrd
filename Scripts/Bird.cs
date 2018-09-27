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
    public Pipes pipes;
    public float counter = 0f;

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
        AddVectorObs(gameObject.transform.localPosition.y);
        AddVectorObs(myBody.velocity.y);
        Vector3 pipePos = pipes.getPipe();
        AddVectorObs(pipePos.y - .6f);
        AddVectorObs(pipePos.y + .6f);
        AddVectorObs(pushed ? 1f : 0f);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        int jump = Mathf.FloorToInt(vectorAction[0]);
        if (jump == 0 && pushed)
        {
            pushed = false;
        }
        if (jump == 1 && !pushed)
        {
            pushed = true;
            Push();
        }

        if (dead)
        {
            SetReward(-1f);
            Done();
        }
        else
        {
            SetReward(0.01f);
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
