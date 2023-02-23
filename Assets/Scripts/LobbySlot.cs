using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySlot : MonoBehaviour
{
    LobbyController lobbyController;
    [SerializeField] int playerNum;
    [SerializeField] int slotDisplay;
    [SerializeField] Image tankImage;
    [SerializeField] Image playerPanel;
    [SerializeField] GameObject slotButtons;
    
    private bool slotActive = false;

    private void Awake()
    {
        lobbyController = FindObjectOfType<LobbyController>();
        slotDisplay = playerNum;
    }

    public void SetSlotDisplay(int slotNum, Color tankColor, Color panelColor)
    {   
        slotDisplay = slotNum;

        // Change Image Colors
        tankImage.color = tankColor;
        playerPanel.color = panelColor;

    }

    public int ReturnPlayerNum()
    {
        return playerNum;
    }

    public int ReturnSlotDisplay()
    {
        return slotDisplay;
    }

    public bool ReturnSlotActive()
    {
        return slotActive;
    }

    public void PlayerSlotClicked()
    {
        lobbyController.PlayerSlotClicked(this);
    }

    public void PlayerColorChangeForward()
    {
        lobbyController.SetUpColorChange(this, true);
    }

    public void PlayerColorChangeBack()
    {
        lobbyController.SetUpColorChange(this, false);
    }

    public void SetSlotActive(bool state)
    {
        slotActive = state;
        slotButtons.SetActive(state);
    }

}
