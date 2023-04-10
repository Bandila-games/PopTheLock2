using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GameUICanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointsText;

    [SerializeField]
    private EventTrigger trigger;

    [SerializeField]
    private GameManager gameManager;

    public void InitializeGameCanvas()
    {
        trigger.triggers[0].callback.AddListener((test) => { OnScreenTapEvent(); });
    }

    public void OnScreenTapEvent()
    {
        if (gameManager.PlayState == PlayStateEnum.Play)
        {
            gameManager.EventManager.Send((int)GameEvents.OnScreenTap);
        }
    }

    public void ShowButton(bool isShow)
    {
        trigger.gameObject.SetActive(isShow);
    }

    public void ShowTargetText(bool isShow)
    {
        pointsText.gameObject.SetActive(isShow);
    }

    public void SetTargetPointsText(int targetPoints)
    {
        pointsText.text = targetPoints.ToString();
    }
}
