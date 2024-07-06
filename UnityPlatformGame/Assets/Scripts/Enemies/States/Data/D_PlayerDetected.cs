using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[CreateAssetMenu(fileName = "newPlayerDetectedStateData", menuName = "Data/State Data/Player Detected Data")]

public class D_PlayerDetected : ScriptableObject
{
    public float longRangeActionTime = 1.5f;
    
}
