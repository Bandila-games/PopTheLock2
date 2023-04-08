using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        gameManager.EventManager.AddListener(this, (int)GameEvents.OnScreenTap);
        RandomizeKnob();
    }

    private void Update()
    {
        if (gameManager.PlayState == PlayStateEnum.Play)
        {
            float rotationZ = GetRotationSpeed();
            Vector3 newRotation = new Vector3(0, 0, rotationZ);
            playerCircle.transform.eulerAngles = newRotation;
        }
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
            SuccessHit();
        }
        else
        {
            FailHit();
        }
    }

    private void SuccessHit()
    {
        RandomizeKnob();
        playerKnocker.IsKnockerHit = false;
        rotationalDir *= -1;

        if ((config.rotateSpeed + rotationIncSpeed) < config.rotateMaxSpeed)
        {
            rotationIncSpeed += config.rotateIncrements;
        }

        gameManager.EventManager.Send((int)GameEvents.OnSuccessHit);
    }

    private void FailHit()
    {
        gameManager.EventManager.Send((int)GameEvents.OnFailHit);
    }

    private void RandomizeKnob()
    {
        float rotationZ = (playerKnob.transform.eulerAngles.z + Random.Range(60, 360));
        Vector3 newRotation = new Vector3(0, 0, rotationZ);
        playerKnob.transform.eulerAngles = newRotation;
    }

    public void ShowPlayerControllers(bool isShow)
    {
        playerCircle.SetActive(isShow);
        playerKnob.SetActive(isShow);
    }

    public void ResetLockObject()
    {
        RandomizeKnob();
        rotationIncSpeed = 0;
        rotationalDir = 1;
    }
}
