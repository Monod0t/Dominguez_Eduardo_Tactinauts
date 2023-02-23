using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Game Info")]
    [SerializeField] float timeLimit;
    [SerializeField] int pointGoal;
    [SerializeField] string objective;

    [Header("Game Components")]
    [SerializeField] List<TankController> tankPlayers;
    [SerializeField] Transform[] spawnPoints;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject pauseOverlay;

    [Header("Game Settings")]
    float respawnTime = 3;

    int currentPlayerCount;
    int alivePlayerCount;

    private void Awake()
    {
        currentPlayerCount = tankPlayers.Count;
        alivePlayerCount = currentPlayerCount;
    }

    public void Update()
    {
        
    }

    public IEnumerator Respawn(GameObject tankPos, TankController tank)
    {
        yield return new WaitForSeconds(respawnTime);
        tankPos.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
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

}
