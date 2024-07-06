using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderManager : MonoBehaviour
{
    [SerializeField] private GameObject ladderPrefab;
    [SerializeField] private List<Vector3> ladderPositions;

    void Start()
    {
        foreach (Vector3 position in ladderPositions)
        {
            Instantiate(ladderPrefab, position, Quaternion.identity);
        }
    }
}
