using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    [Header("Game Info")]
    [SerializeField] float timeLimit;
    [SerializeField] int pointGoal;
    [SerializeField] string objective;

    [Header("Players")]
    [SerializeField] List<TankController> tankPlayers;

    [Header("Player Hearts")]
    [SerializeField] List<Image> tankHearts;

    [Header("Player Controls")]
    [SerializeField] List<GameObject> controllerGroups;
    [SerializeField] List<Image> driveBtn;
    [SerializeField] List<Image> shootBtn;

    [Header("Game Components")]
    [SerializeField] LobbyData lobbyData;
    [SerializeField] GameObject playerControlsGroup;
    [SerializeField] GameObject playerDataGroup;

    [Header("Spawns")]
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] List<Transform> startingSpawns2Players = new List<Transform>();
    [SerializeField] List<Transform> startingSpawns3Players = new List<Transform>();
    [SerializeField] List<Transform> startingSpawns4Players = new List<Transform>();
    
    private List<Transform> startingSpawns = new List<Transform>();

    [Header("Other UI")]
    [SerializeField] GameObject introScreen;
    [SerializeField] GameObject winnerScreen;
    [SerializeField] TextMeshProUGUI winner;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject pauseOverlay;

    [Header("Game Settings")]
    float respawnTime = 3;

    int currentPlayerCount;
    int alivePlayerCount;

    List<Color> tanks;
    List<Color> panels;



    private void Awake()
    {
        lobbyData = FindObjectOfType<LobbyData>();
        currentPlayerCount = lobbyData.ReturnPlayerCount();
        alivePlayerCount = currentPlayerCount;
        tanks = lobbyData.ReturnTankColors();
        panels = lobbyData.ReturnPanelColors();

        InitializeSpawns();
        SetTanksUp();
    }

    public void Update()
    {
        
    }

    public IEnumerator Respawn(GameObject tankPos, TankController tank)
    {
        yield return new WaitForSeconds(respawnTime);
        tankPos.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        tank.ResetTank();
        tank.SetInvincibility(2);
    }

    public void DeclareDeath()
    {
        alivePlayerCount--;
    }

    public float ReturnTimeLimit()
    {
        return timeLimit;
    }

    public int ReturnPlayerCount()
    {
        return currentPlayerCount;
    }

    public int ReturnLivePlayerCount()
    {
        return alivePlayerCount;
    }

    public List<TankController> ReturnTankPlayers()
    {
        return tankPlayers;
    }

    public TextMeshProUGUI ReturnTimer()
    {
        return timer;
    }

    public GameObject ReturnIntroScreen()
    {
        return introScreen;
    }

    public TextMeshProUGUI ReturnCountdown()
    {
        return countdown;
    }

    public GameObject ReturnWinnerScreen()
    {
        return winnerScreen;
    }

    public TextMeshProUGUI ReturnWinnertext()
    {
        return winner;
    }

    public void DestroyLobbyData()
    {
        Destroy(lobbyData.gameObject);
    }

    void InitializeSpawns()
    {
        Debug.Log(currentPlayerCount);
        if (currentPlayerCount == 2)
        {
            for (int i=0; i < currentPlayerCount; i++)
            {
                startingSpawns = startingSpawns2Players;
            }
        }
        else if (currentPlayerCount == 3)
        {
            for (int i = 0; i < currentPlayerCount; i++)
            {
                startingSpawns = startingSpawns3Players;
            }
        }
        else if (currentPlayerCount == 4)
        {
            for (int i = 0; i < currentPlayerCount; i++)
            {
                startingSpawns = startingSpawns4Players;
            }
        }
        
    }

    void SetTanksUp()
    {
        for (int i=0; i < currentPlayerCount; i++)
        {
            tankPlayers[i].SetTankColor(tanks[i]);

            Color targetColor = tanks[i];
            targetColor.a = 150f / 255f;
            driveBtn[i].color = targetColor;
            shootBtn[i].color = targetColor;

            controllerGroups[i].GetComponent<TankButtons>().ControllerSetUp(currentPlayerCount);
            tankHearts[i].GetComponent<TankHealth>().ControllerSetUp(currentPlayerCount);

            tankPlayers[i].gameObject.transform.position = startingSpawns[i].gameObject.transform.position;
            tankPlayers[i].gameObject.transform.rotation = startingSpawns[i].gameObject.transform.rotation;

            tankPlayers[i].gameObject.SetActive(true);
            controllerGroups[i].SetActive(true);
        }
    }

}