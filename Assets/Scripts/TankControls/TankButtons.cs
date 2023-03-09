using UnityEngine;

public class TankButtons : MonoBehaviour
{

    [Header("Player Data")]
    [SerializeField] int playerNum;

    [Header("Significant Components")]
    [SerializeField] GameController GM;
    [SerializeField] RectTransform buttonTransform;
    [SerializeField] GameObject driveBtn;
    [SerializeField] GameObject shootBtn;
    [SerializeField] RectTransform ammoDisplay;

    [Header("2 Player Dimensions")]
    [SerializeField] Vector2 position_2Players_P1 = new Vector2(-1190, 0);
    [SerializeField] Vector2 position_2Players_P2 = new Vector2(1190, 0);

    [Header("3 Player Dimensions")]
    [SerializeField] Vector2 position_3Players_P1 = new Vector2(-1040, 440);
    [SerializeField] Vector2 position_3Players_P2 = new Vector2(-1040, -440);
    [SerializeField] Vector2 position_3Players_P3 = new Vector2(1190, 0);

    [Header("4 Player Dimensions")]
    [SerializeField] Vector2 position_4Players_P1 = new Vector2(-1040, 440);
    [SerializeField] Vector2 position_4Players_P2 = new Vector2(-1040, -440);
    [SerializeField] Vector2 position_4Players_P3 = new Vector2(1040, 440);
    [SerializeField] Vector2 position_4Players_P4 = new Vector2(1040, -440);

    [Header("Ammo Dimensions")]
    [SerializeField] Vector2 ammoPos1 = new Vector2(-15, 125);
    [SerializeField] Vector3 ammoSca1 = new Vector3(1.25f, 1.25f, 1.25f);
    [SerializeField] Vector2 ammoPos2 = new Vector2(-100, 100);
    [SerializeField] Vector3 ammoSca2 = new Vector3(1, 1, 1);

    void Start()
    {
        buttonTransform = GetComponent<RectTransform>();

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
                buttonTransform.localScale = new Vector3(1, 1, 1);
                buttonTransform.rotation = Quaternion.Euler(0f, 0f, -90);
                buttonTransform.anchoredPosition = position_2Players_P1;

                ammoDisplay.anchoredPosition = ammoPos1;
                ammoDisplay.localRotation = Quaternion.Euler(0f, 0f, 0f);
                ammoDisplay.localScale = ammoSca1;

            }
            else if (playerNum == 2)
            {
                buttonTransform.localScale = new Vector3(1, 1, 1);
                buttonTransform.localRotation = Quaternion.Euler(0f, 0f, 90);
                buttonTransform.anchoredPosition = position_2Players_P2;

                ammoDisplay.anchoredPosition = ammoPos1;
                ammoDisplay.localRotation = Quaternion.Euler(0f, 0f, 0f);
                ammoDisplay.localScale = ammoSca1;

            }

        }
        else if (playerCount == 3)
        {
            if (playerNum == 1)
            {
                buttonTransform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                buttonTransform.localRotation = Quaternion.Euler(0f, 0f, -135);
                buttonTransform.anchoredPosition = position_3Players_P1;

                ammoDisplay.anchoredPosition = ammoPos2;
                ammoDisplay.localRotation = Quaternion.Euler(0f, 0f, 45f);
                ammoDisplay.localScale = ammoSca2;

            }
            else if (playerNum == 2)
            {
                buttonTransform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                buttonTransform.localRotation = Quaternion.Euler(0f, 0f, -45);
                buttonTransform.anchoredPosition = position_3Players_P2;

                ammoDisplay.anchoredPosition = ammoPos2;
                ammoDisplay.localRotation = Quaternion.Euler(0f, 0f, 45f);
                ammoDisplay.localScale = ammoSca2;

            }
            else if (playerNum == 3)
            {
                buttonTransform.localScale = new Vector3(1, 1, 1);
                buttonTransform.localRotation = Quaternion.Euler(0f, 0f, 90);
                buttonTransform.anchoredPosition = position_3Players_P3;

                ammoDisplay.anchoredPosition = ammoPos1;
                ammoDisplay.localRotation = Quaternion.Euler(0f, 0f, 0f);
                ammoDisplay.localScale = ammoSca1;

            }

        }
        else if (playerCount == 4)
        {
            if (playerNum == 1)
            {
                buttonTransform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                buttonTransform.localRotation = Quaternion.Euler(0f, 0f, -135);
                buttonTransform.anchoredPosition = position_4Players_P1;

                ammoDisplay.anchoredPosition = ammoPos2;
                ammoDisplay.localRotation = Quaternion.Euler(0f, 0f, 45f);
                ammoDisplay.localScale = ammoSca2;

            }
            else if (playerNum == 2)
            {
                buttonTransform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                buttonTransform.localRotation = Quaternion.Euler(0f, 0f, -45);
                buttonTransform.anchoredPosition = position_4Players_P2;

                ammoDisplay.anchoredPosition = ammoPos2;
                ammoDisplay.localRotation = Quaternion.Euler(0f, 0f, 45f);
                ammoDisplay.localScale = ammoSca2;

            }
            else if (playerNum == 3)
            {
                buttonTransform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                buttonTransform.localRotation = Quaternion.Euler(0f, 0f, 135);
                buttonTransform.anchoredPosition = position_4Players_P3;

                ammoDisplay.anchoredPosition = ammoPos2;
                ammoDisplay.localRotation = Quaternion.Euler(0f, 0f, 45f);
                ammoDisplay.localScale = ammoSca2;

            }
            else if (playerNum == 4)
            {
                buttonTransform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                buttonTransform.localRotation = Quaternion.Euler(0f, 0f, 45);
                buttonTransform.anchoredPosition = position_4Players_P4;

                ammoDisplay.anchoredPosition = ammoPos2;
                ammoDisplay.localRotation = Quaternion.Euler(0f, 0f, 45f);
                ammoDisplay.localScale = ammoSca2;

            }

        }

        this.gameObject.SetActive(true);

    }

}
