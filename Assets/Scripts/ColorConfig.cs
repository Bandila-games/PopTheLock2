using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color config", menuName = "Configs/Color config")]
public class ColorConfig : ScriptableObject
{
    public List<Color> Colors;
}
