using UnityEngine;

[CreateAssetMenu(fileName = "Lock Configuration", menuName = "Configs/Lock")]
public class LockConfig : ScriptableObject
{
    public float rotateSpeed;
    public float rotateMaxSpeed;
    public float rotateIncrements;
    public float[] rotationPace;
}
