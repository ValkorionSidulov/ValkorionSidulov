using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresCollector : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private int scores;
    [SerializeField] private int maxScores;

    public int Scores => scores;
    public int MaxScores 
    {
        get { return maxScores; }
        set { maxScores = value; }
    }

    private void Update()
    {
        if (scores >= maxScores)
        {
            maxScores = scores;
        }
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            scores += levelProgress.CurrentLevel;
        }
    }
}
