using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour, IEventObserver
{
    [SerializeField]
    private GameUICanvas gameUICanvas;

    [SerializeField]
    private LockGameObject lockController;

    [SerializeField]
    private UICanvasController uiCanvasController;

    [SerializeField]
    private LevelsConfig levelConfig;
    [SerializeField]
    private ColorConfig colorConfig;

    [SerializeField]
    private Camera mainCamera;

    public EventManager EventManager;
    public DataManager DataManager;
    public PlayStateEnum PlayState;

    // Start is called before the first frame update
    void Awake()
    {
        EventManager = new EventManager();
        DataManager = new DataManager();
        uiCanvasController.InitializeUICanvas();
        gameUICanvas.InitializeGameCanvas();
        lockController.Initialize();

        gameUICanvas.ShowTargetText(false);
        lockController.ShowPlayerControllers(false);
        this.PlayState = PlayStateEnum.Paused;

        EventManager.AddListener(this, (int)GameEvents.LevelStart);
        EventManager.AddListener(this, (int)GameEvents.OnSuccessHit);
        EventManager.AddListener(this, (int)GameEvents.OnFailHit);

        StartGameFlow();
    }

    private void StartGameFlow()
    {
        int currentLevel = DataManager.GetSavedProgressLevel();
        if (currentLevel < 0)
        {
            DataManager.SaveCurrentLevel(0);
        }

        gameUICanvas.ShowButton(false);
        uiCanvasController.ShowMenu(true);
    }

    private void StartLevel()
    {
        gameUICanvas.ShowButton(true);
        DataManager.CurrentTargetScore = levelConfig.TargetLevelCount[DataManager.CurrentLevel];
        gameUICanvas.SetTargetPointsText(DataManager.CurrentTargetScore);
        gameUICanvas.ShowTargetText(true);
        lockController.ResetLockObject();
        lockController.ShowPlayerControllers(true);
        this.PlayState = PlayStateEnum.Play;

        mainCamera.backgroundColor = colorConfig.Colors[Random.Range(0, colorConfig.Colors.Count)];        
    }

    private void PauseGame(bool isPaused)
    {
        gameUICanvas.ShowButton(false);
        //uiCanvasController.ShowPauseMenu(isPaused);
        //PlayState state = isPaused ? PlayState.Pause : PlayState.Play;
        //lockController.SetPlayState(PlayState.state);
    }

    private void InitiateWinSequence()
    {
        gameUICanvas.ShowButton(false);
        gameUICanvas.ShowTargetText(false);
        lockController.ShowPlayerControllers(false);
        this.PlayState = PlayStateEnum.Paused;
        uiCanvasController.ShowResultsScreen(true);
        uiCanvasController.SetResultsTexT("WINNER!");
        uiCanvasController.ShowStar(true);
       
        if ((DataManager.CurrentLevel + 1) < levelConfig.TargetLevelCount.Count)
        {
            DataManager.SaveCurrentLevel(DataManager.CurrentLevel + 1);
        }
        else
        {
            DataManager.SaveCurrentLevel(DataManager.CurrentLevel);
        }
    }

    private void InitiateLoseSequence()
    {
        gameUICanvas.ShowButton(false);
        gameUICanvas.ShowTargetText(false);
        uiCanvasController.ShowResultsScreen(true);
        uiCanvasController.ShowStar(false);
        uiCanvasController.SetResultsTexT("FAILED");
        this.PlayState = PlayStateEnum.Paused;
    }

    public void OnEvent(int eventId, object payload)
    {
        switch (eventId)
        {
            case (int)GameEvents.LevelStart:
                StartLevel();
                break;
            case (int)GameEvents.OnSuccessHit:
                DataManager.CurrentTargetScore--;
                gameUICanvas.SetTargetPointsText(DataManager.CurrentTargetScore);

                if (DataManager.CurrentTargetScore <= 0)
                {
                    //Initiate win
                    InitiateWinSequence();
                }

                break;
            case (int)GameEvents.OnFailHit:
                InitiateLoseSequence();
                break;
        }
    }
}
