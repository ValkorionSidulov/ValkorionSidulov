using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private BallContreller ballContreller;
    [SerializeField] private LevelProgress levelProgress;


    private void Start()
    {
        levelGenerator.Generate(levelProgress.CurrentLevel);

        ballContreller.transform.position = new Vector3(ballContreller.transform.position.x, levelGenerator.LastFloorY + 1.45f , ballContreller.transform.position.z);
    }
}
