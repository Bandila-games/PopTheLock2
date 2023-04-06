using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGameObject : MonoBehaviour, IEventObserver
{
    [SerializeField]
    private PlayerKnocker playerKnocker;

    [SerializeField]
    private GameObject playerCircle;

    [SerializeField]
    private GameObject playerKnob;

    [SerializeField]
    private LockConfig config;
    private float rotationalDir = 1;
    private float rotationIncSpeed = 0;

    [SerializeField]
    private GameManager gameManager;

    public void Initialize()
    {
        gameManager.eventManager.AddListener(this, (int)GameEvents.OnScreenTap);
        RandomizeKnob();
    }

    private void Update()
    {
        float rotationZ = GetRotationSpeed();
        Vector3 newRotation = new Vector3(0, 0, rotationZ);
        playerCircle.transform.eulerAngles = newRotation;
    }

    public void OnEvent(int eventId, object payload)
    {
        if (eventId == (int)GameEvents.OnScreenTap)
        {
            CheckHit();
        }
    }

    private float GetRotationSpeed()
    {
        float rotationSpeed = playerCircle.transform.eulerAngles.z + ((config.rotateSpeed + rotationIncSpeed) * rotationalDir);


        return rotationSpeed;
    }

    private void CheckHit()
    {
        if (playerKnocker.IsKnockerHit)
        {
            RandomizeKnob();
            playerKnocker.IsKnockerHit = false;
            rotationalDir *= -1;

            if ((config.rotateSpeed + rotationIncSpeed) < config.rotateMaxSpeed)
            {
                rotationIncSpeed += config.rotateIncrements;
            }
        }
        else
        {

        }
    }

    private void RandomizeKnob()
    {
        float rotationZ = (playerKnob.transform.eulerAngles.z + Random.Range(60, 360));
        Vector3 newRotation = new Vector3(0, 0, rotationZ);
        playerKnob.transform.eulerAngles = newRotation;
    }
}