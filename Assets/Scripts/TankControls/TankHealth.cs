using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] int playerNum;

    [Header("Significant Components")]
    [SerializeField] GameController GM;
    [SerializeField] RectTransform livesTransform;

    [Header("2 Player Dimensions")]
    [SerializeField] Vector2 position_2Players_P1 = new Vector2(-800, 425);
    [SerializeField] Vector2 position_2Players_P2 = new Vector2(800, -425);

    [Header("3 Player Dimensions")]
    [SerializeField] Vector2 position_3Players_P1 = new Vector2(-575, 470);
    [SerializeField] Vector2 position_3Players_P2 = new Vector2(-575, -470);
    [SerializeField] Vector2 position_3Players_P3 = new Vector2(800, -425);

    [Header("4 Player Dimensions")]
    [SerializeField] Vector2 position_4Players_P1 = new Vector2(-575, 470);
    [SerializeField] Vector2 position_4Players_P2 = new Vector2(-575, -470);
    [SerializeField] Vector2 position_4Players_P3 = new Vector2(575, 470);
    [SerializeField] Vector2 position_4Players_P4 = new Vector2(575, -470);

    void Start()
    {
        livesTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ControllerSetUp(int playerCount)
    {
        if (playerCount == 2)
        {
            if (playerNum == 1)
            {
                livesTransform.rotation = Quaternion.Euler(0f, 0f, -90);
                livesTransform.anchoredPosition = position_2Players_P1;
                this.gameObject.SetActive(true);

            }
            else if (playerNum == 2)
            {
                livesTransform.rotation = Quaternion.Euler(0f, 0f, 90);
                livesTransform.anchoredPosition = position_2Players_P2;
                this.gameObject.SetActive(true);

            }

        }
        else if (playerCount == 3)
        {
            if (playerNum == 1)
            {
                livesTransform.rotation = Quaternion.Euler(0f, 0f, -135);
                livesTransform.anchoredPosition = position_3Players_P1;
                this.gameObject.SetActive(true);

            }
            else if (playerNum == 2)
            {
                livesTransform.rotation = Quaternion.Euler(0f, 0f, -45);
                livesTransform.anchoredPosition = position_3Players_P2;
                this.gameObject.SetActive(true);

            }
            else if (playerNum == 3)
            {
                livesTransform.rotation = Quaternion.Euler(0f, 0f, 90);
                livesTransform.anchoredPosition = position_3Players_P3;
                this.gameObject.SetActive(true);

            }

        }
        else if (playerCount == 4)
        {
            if (playerNum == 1)
            {
                livesTransform.rotation = Quaternion.Euler(0f, 0f, -135);
                livesTransform.anchoredPosition = position_4Players_P1;
                this.gameObject.SetActive(true);

            }
            else if (playerNum == 2)
            {
                livesTransform.rotation = Quaternion.Euler(0f, 0f, -45);
                livesTransform.anchoredPosition = position_4Players_P2;
                this.gameObject.SetActive(true);

            }
            else if (playerNum == 3)
            {
                livesTransform.rotation = Quaternion.Euler(0f, 0f, -225);
                livesTransform.anchoredPosition = position_4Players_P3;
                this.gameObject.SetActive(true);

            }
            else if (playerNum == 4)
            {
                livesTransform.rotation = Quaternion.Euler(0f, 0f, 45);
                livesTransform.anchoredPosition = position_4Players_P4;
                this.gameObject.SetActive(true);

            }

        }


    }

}
