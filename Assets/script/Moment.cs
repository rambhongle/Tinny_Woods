using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moment : MonoBehaviour
{
    public Transform[] targets;
    public float speed;
    private bool IsMoving = false;
    private int tarindx = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovetoTarget();
        HandaleInput();
        if (targets.Length == tarindx)
        {
            tarindx = 0;
        }
    }

    private void HandaleInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            IsMoving = !IsMoving;
           
        }
       
    }
    private void MovetoTarget()
    {
        float distance = Vector3.Distance(transform.position, targets[tarindx].position); // cal dist from player to target
       
        if (distance > 0 && IsMoving)
        {
            float step = speed * Time.deltaTime; // cal how much distance need to move

            transform.position = Vector3.MoveTowards(transform.position, targets[tarindx].position, step);
        }
        if(distance <= 0)
        {
            IsMoving = false;
            tarindx++;
        }
        
       
    }
}
