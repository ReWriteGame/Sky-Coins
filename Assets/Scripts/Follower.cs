using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private Vector2 maxShift;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {    
                Vector3 dir = Vector3.right * touch.deltaPosition.x * speed * Time.deltaTime;

                if(transform.position.x + dir.x > maxShift.x && transform.position.x + dir.x < maxShift.y)
                    transform.position += dir;
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(Vector3.right * maxShift.x, .1f);
        Gizmos.DrawSphere(Vector3.right * maxShift.y, .1f);
    }
}
