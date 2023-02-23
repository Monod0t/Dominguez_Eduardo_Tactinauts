using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    int currentPlayerCount = 0;
    int confirmedPlayerCount = 0;
    int maxPlayerCount = 4;

    [Header("Components")]
    [SerializeField] List<LobbySlot> lobbySlotsList;
    [SerializeField] Button confirm;

    [Header("Empty Slot Colors")]
    [SerializeField] Color emptyTankColor;
    [SerializeField] Color emptyPanelColor;

    [Header("Player Colors")]
    [SerializeField] List<Color> tankColor;
    [SerializeField] List<Color> panelColor;

    private int curDisplayNum;
    private int sameDisplayNums;

    private void Awake()
    {
        UpdateContinueButton();
    }

    public void PlayerSlotClicked(LobbySlot slot)
    {
        if (slot.ReturnSlotActive())
            RemovePlayer(slot);
        else
            AddPlayer(slot);

    }

    public void AddPlayer(LobbySlot slot)
    {
        currentPlayerCount++;
        slot.SetSlotActive(true);
        UpdateContinueButton();
        SetSlotColor(slot, slot.ReturnSlotDisplay());
    }

    public void RemovePlayer(LobbySlot slot)
    {
        currentPlayerCount--;
        slot.SetSlotActive(false);
        UpdateContinueButton();
        SetSlotColor(slot, slot.ReturnSlotDisplay());
    }

    public void SetUpColorChange(LobbySlot slot, bool direction)
    {
        curDisplayNum = slot.ReturnSlotDisplay();
        sameDisplayNums = 0;

        if (currentPlayerCount == maxPlayerCount)
            return;

        if (direction)
            CycleColorForward(slot);
        else
            CycleColorBack(slot);

    }

    public void CycleColorForward(LobbySlot slot)
    {
        curDisplayNum++;

        if (curDisplayNum >= tankColor.Count)
        {
            curDisplayNum = 0;
        }

        for (int i = 0; i < lobbySlotsList.Count; i++)
        {
            if (lobbySlotsList[i] != slot)
            {
                if (lobbySlotsList[i].ReturnSlotDisplay() == curDisplayNum && lobbySlotsList[i].ReturnSlotActive())
                {
                    sameDisplayNums++;
                }
            }

        }

        if (sameDisplayNums > 0)
        {
            sameDisplayNums = 0;
            CycleColorForward(slot);
        }
        else
        {
            sameDisplayNums = 0;
            SetSlotColor(slot, curDisplayNum);
        }

    }

    public void CycleColorBack(LobbySlot slot)
    {
        curDisplayNum--;

        if (curDisplayNum < 0)
        {
            curDisplayNum = tankColor.Count-1;
        }

        for (int i = 0; i < lobbySlotsList.Count; i++)
        {
            if (lobbySlotsList[i] != slot)
            {
                if (lobbySlotsList[i].ReturnSlotDisplay() == curDisplayNum && lobbySlotsList[i].ReturnSlotActive())
                {
                    sameDisplayNums++;
                }
            }

        }

        if (sameDisplayNums > 0)
        {
            sameDisplayNums = 0;
            CycleColorBack(slot);
        }
        else
        {
            sameDisplayNums = 0;
            SetSlotColor(slot, curDisplayNum);
        }


    }

    void SetSlotColor(LobbySlot slot, int slotNum)
    {
        if (!slot.ReturnSlotActive())
        {
            slot.SetSlotDisplay(slot.ReturnPlayerNum(), emptyTankColor, emptyPanelColor); ;
            return;
        }

        curDisplayNum = slotNum;

        for (int i = 0; i < lobbySlotsList.Count; i++)
        {
            if (lobbySlotsList[i] != slot)
            {
                if (lobbySlotsList[i].ReturnSlotDisplay() == curDisplayNum && lobbySlotsList[i].ReturnSlotActive())
                {
                    sameDisplayNums++;
                }
            }

        }

        if (sameDisplayNums > 0)
        {
            sameDisplayNums = 0;
            CycleColorForward(slot);
        }
        else
        {
            sameDisplayNums = 0;
            slot.SetSlotDisplay(curDisplayNum, tankColor[curDisplayNum], panelColor[curDisplayNum]);
        }


    }

    private void UpdateContinueButton()
    {
        if (currentPlayerCount > 1)
        {
            confirm.interactable = true;
        }
        else
        {
            confirm.interactable = false;
        }
    }

    public void StartGameProtocol()
    {
        
        

    }

}
