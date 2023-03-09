using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyData : DontDestroyOnLoad
{
    int playerCount;
    List<Color> tankPlayer = new List<Color>();
    List<Color> playerPanel = new List<Color>();

    public void UpdatePlayerData(int playerNum, List<LobbySlot> LobbySlot)
    {
        playerCount = playerNum;
        int curNum = 0;

        tankPlayer.Clear();
        playerPanel.Clear();

        for (int i = 0; i < 4; i++)
        {
            if (LobbySlot[i].ReturnSlotActive() == true)
            {
                tankPlayer.Add(LobbySlot[i].ReturnTankColor());
                playerPanel.Add(LobbySlot[i].ReturnPanelColor());
                curNum++;
            }
        }

    }

    public int ReturnPlayerCount()
    {
        return playerCount;
    }
    public List<Color> ReturnTankColors()
    {
        return tankPlayer;
    }
    public List<Color> ReturnPanelColors()
    {
        return playerPanel;
    }

}
