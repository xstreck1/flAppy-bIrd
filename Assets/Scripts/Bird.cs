// Bird.cs

using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Bird : Agent
{
    private Rigidbody2D myBody;
    private bool screenPressed;

    const float height = 2f;

    public PipeSet pipes;
    public float counter;

    private void Update()
    {
        counter += Time.deltaTime;
    }

    public override void Initialize()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Push()
    {
        myBody.AddForce(Vector2.up * 4f, ForceMode2D.Impulse);
    }

    public override void CollectObservations(VectorSensor vs)
    {
        var nextPipePos = pipes.GetNextPipe().localPosition;
        float vel = Mathf.Clamp(myBody.velocity.y, -height, height);

        vs.AddObservation(transform.localPosition.y / height);
        vs.AddObservation(vel / height);
        vs.AddObservation(nextPipePos.y / height);
        vs.AddObservation(nextPipePos.x);
        vs.AddObservation(screenPressed ? 1f : -1f);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        AddReward(Time.fixedDeltaTime);

        int tap = Mathf.FloorToInt(vectorAction[0]);
        
        if (tap == 0)
        {
            screenPressed = false;
        }
        if (tap == 1 && !screenPressed)
        {
            Push();
            screenPressed = true;
        }
    }

    public override void OnEpisodeBegin()
    {
        myBody.velocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
        counter = 0f;
        pipes.ResetPos();
    }

    private void OnTriggerEnter2D(Collider2D collision2d)
    {
        SetReward(-1f);
        EndEpisode();
    }
    
    public override void Heuristic(float[] action)
    {
        action[0] = Input.GetKey(KeyCode.Space) ? 1f : 0f;
    }
}