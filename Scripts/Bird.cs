using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Agent
{
    Rigidbody2D myBody;
    public float forceRatio = 1f;
    Vector3 startPos;
    float height = 5f;

    public void Push()
    {
        myBody.AddForce(Vector2.up * forceRatio, ForceMode2D.Impulse);
    }


    public override void InitializeAgent()
    {
        myBody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    public override void CollectObservations()
    {
        AddVectorObs(gameObject.transform.position.y);
        AddVectorObs(myBody.velocity.y);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        
        int jump = Mathf.FloorToInt(vectorAction[0]);

        if (jump == 1)
        {
            Push();
        }
        if (transform.position.y > height || transform.position.y < -height)
        {
            SetReward(-1f);
            Done();
        }
        else
        {
            SetReward((height - transform.position.y) * .01f);
        }
    }

    public override void AgentReset()
    {
        myBody.velocity = Vector3.zero;
        transform.position = startPos;
    }

}
