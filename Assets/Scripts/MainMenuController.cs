using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    bool currentlyChanging = false;  // Prevents selecting during sreen transitions
    bool popUpActive = false;        // Prevents selecing options other than current pop-up's

    public void EnterLobby()
    {
        Debug.Log("Enter Prep Lobby");

    }

    public void EnterSettings()
    {
        Debug.Log("Enter Settings");
    }

    public void BackToMenu()
    {
        Debug.Log("Return to Menu");

    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void SetChangingFlag(bool state)
    {
        currentlyChanging = state;
    }

    public void SetPopUpFlag(bool state)
    {
        popUpActive = state;
    }

}
