using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UICanvasController : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup menuCanvasGroup;

    [SerializeField]
    private CanvasGroup levelResultCanvasGroup;

    #region Menu Elements

    [SerializeField]
    private Button playButton;

    //TODO: Gelo - To add exit button

    #endregion

    #region Level result elements

    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private Button menuButton;

    [SerializeField]
    private TextMeshProUGUI resultText;

    [SerializeField]
    private Image star;

    #endregion

    [SerializeField]
    private GameManager gameManager;

    public void InitializeUICanvas()
    {
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(onPlayClicked);

        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(onContinueClicked);
    }

    private void onPlayClicked()
    {
        ShowMenu(false);
        gameManager.EventManager.Send((int)GameEvents.LevelStart);
    }

    private void onContinueClicked()
    {
        ShowResultsScreen(false);
        gameManager.EventManager.Send((int)GameEvents.LevelStart);
    }

    public void ShowMenu(bool isShow)
    {
        menuCanvasGroup.alpha = isShow ? 1 : 0;
        menuCanvasGroup.blocksRaycasts = isShow;
        menuCanvasGroup.interactable = isShow;
    }

    public void ShowResultsScreen(bool isShow)
    {
        levelResultCanvasGroup.alpha = isShow ? 1 : 0;
        levelResultCanvasGroup.blocksRaycasts = isShow;
        levelResultCanvasGroup.interactable = isShow;
    }

    public void SetResultsTexT(string resultText)
    {
        this.resultText.text = resultText;
    }

    public void ShowStar(bool isShow)
    {
        star.gameObject.SetActive(isShow);
    }
}
