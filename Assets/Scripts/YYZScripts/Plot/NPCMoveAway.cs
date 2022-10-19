using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoveAway : MonoBehaviour
{
    public Animator animator;
    public Vector3 dir;
    public float speed, acceleration, maxSpeed, maxWaitTime;
    public bool isWalking, speedUp;
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 0;
    }
    void Update()
    {
        //animator.SetBool("isWalking", isWalking);
        if (isWalking)
        {
            if(speedUp && speed < maxSpeed - acceleration * Time.deltaTime)
            {
                speed += acceleration * Time.deltaTime;
            }
            else if (speedUp)
            {
                speed = maxSpeed;
                speedUp = false;
            }
            else if(!speedUp && speed > acceleration * Time.deltaTime)
            {
                speed -= acceleration * Time.deltaTime;
            }
            else if(!speedUp)
            {
                speed = 0;
            }
            if(speed == 0 && !speedUp)
                isWalking = false;
            transform.position += speed * Time.deltaTime * dir;
        }
    }
    public void MoveAwayTrigger()
    {
        Invoke(nameof(MoveAway), Random.Range(0, maxWaitTime));
    }
    void MoveAway()
    {
        isWalking = true;
        speedUp = true;
    }
}
