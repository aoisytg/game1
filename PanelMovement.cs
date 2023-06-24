using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMovement : MonoBehaviour
{
    [SerializeField] private Transform upPlace;
    [SerializeField] private Transform downPlace;
    [SerializeField] private float moveSpeed;

    private bool isMovingUp;

    private void Update()
    {
        if (isMovingUp)
        {
            if (transform.position.y < upPlace.position.y)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, upPlace.position, step);
            }
            else
            {
                isMovingUp = false;
            }
        }
        else    
        {
            if (transform.position.y > downPlace.position.y)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, downPlace.position, step);
            }
            else
            {
                isMovingUp = true;
            }
        }
    }
}
