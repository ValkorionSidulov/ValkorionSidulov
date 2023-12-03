using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRefill : MonoBehaviour
{
    [SerializeField] private MeshRenderer axis;
    [SerializeField] private MeshRenderer ball;

    [SerializeField] private Material[] ballMaterials;
    [SerializeField] private Material[] axisMaterials;

    private void Start()
    {
        axis.material = axisMaterials[Random.Range(0, axisMaterials.Length)];
        ball.material = ballMaterials[Random.Range(0, ballMaterials.Length)];

    }
}
