using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : BallEvents
{
    [SerializeField] private ScoresCollector scoresCollector;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text maxScoreText;

    private void Update()
    {
        maxScoreText.text = "Рекорд:" + scoresCollector.MaxScores.ToString();
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type != SegmentType.Trap)
        {
            scoreText.text = scoresCollector.Scores.ToString();
        }
    }
}
