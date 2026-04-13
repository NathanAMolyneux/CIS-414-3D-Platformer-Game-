using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NMBaseShip : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;

    protected Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    protected virtual void Update()
    {
        MoveToTarget();
    }

    protected virtual void MoveToTarget()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        FaceMovement(direction);
    }

    protected virtual void FaceMovement(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            transform.right = direction;
        }
    }
}