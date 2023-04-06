using UnityEngine;
using UnityEngine.UI;

public class GameUICanvas : MonoBehaviour
{
    [SerializeField]
    private Button ClickButton;

    [SerializeField]
    private GameManager gameManager;

    public void InitializeGameCanvas()
    {
        ClickButton.onClick.AddListener(OnScreenTap);
    }

    private void OnScreenTap()
    {
        gameManager.eventManager.Send((int)GameEvents.OnScreenTap);
    }
}
