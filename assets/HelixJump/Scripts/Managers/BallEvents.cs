using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallEvents : MonoBehaviour
{
    [SerializeField] protected BallContreller ballContreller;

    protected virtual void Awake()
    {
        ballContreller.CollisionSegment.AddListener(OnBallCollisionSegment);
    }

    private void OnDestroy()
    {
        ballContreller.CollisionSegment.RemoveListener(OnBallCollisionSegment);
    }

    protected virtual void OnBallCollisionSegment(SegmentType type) { }
}
