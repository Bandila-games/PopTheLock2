using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameUICanvas gameUICanvas;

    [SerializeField]
    private LockGameObject lockController;

    public EventManager eventManager;

    // Start is called before the first frame update
    void Awake()
    {
        eventManager = new EventManager();

        gameUICanvas.InitializeGameCanvas();
        lockController.Initialize();
    }
}
