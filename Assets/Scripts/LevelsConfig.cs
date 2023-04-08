using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level config", menuName = "Configs/Level config")]
public class LevelsConfig : ScriptableObject
{
    public List<int> TargetLevelCount;
}
