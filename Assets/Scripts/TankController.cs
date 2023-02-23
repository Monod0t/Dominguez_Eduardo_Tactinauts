using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankController : MonoBehaviour
{
    [Header("Tank Data")]
    [SerializeField] int playerNum;
    [SerializeField] int maxHP;
    [SerializeField] int maxLives = 3;
    [SerializeField] int maxAmmo = 3;

    int curHP;
    int curLives;
    int curAmmo;

    [Header("Tank Movement")]
    [SerializeField] float driveSpd;
    [SerializeField] bool turnDir;
    [SerializeField] float turnSpd;

    [Header("Shooting")]
    [SerializeField] float baseBulletSpd;

    float curBulletSpd;

    [Header("Tank Status")]
    [SerializeField] bool active = false;
    [SerializeField] bool alive = true;
    [SerializeField] float invincible;
    [SerializeField] bool driveEnabled = false;
    [SerializeField] bool turnEnabled = false;
    [SerializeField] bool shootEnabled = false;

    [Header("Tank Art")]
    [SerializeField] SpriteRenderer tankSprite;

    [Header("Significant Components")]
    [SerializeField] GameController _gameController;
    [SerializeField] TextMeshProUGUI curHPText;
    [SerializeField] TextMeshProUGUI lifeCountText;

    void Start()
    {
        curLives = maxLives;
        ResetTank();
    }

    // Update is called once per frame
    void Update()
    {
        InvincibilityTimer();
    }

    public void ResetTank()
    {
        alive = true;
        tankSprite.enabled = true;
        curHP = maxHP;
        curAmmo = maxAmmo;

        curHPText.text = curHP.ToString() + "HP";
        lifeCountText.text = curLives.ToString() + "Lives";
    }

    public void TakeDmg(int dmg)
    {
        if (invincible > 0 || !alive || !active)
            return;

        curHP -= dmg;
        curHPText.text = curHP.ToString() + "HP";
        if (curHP <= 0)
        {
            Die();
        }
    }

    public void SetInvincibility(float iFrameTime)
    {
        invincible = iFrameTime;
    }

    void InvincibilityTimer()
    {
        if (invincible > 0)
        {
            invincible -= Time.deltaTime;
        }
        else
        {
            invincible = 0;
        }
    }

    void Die()
    {
        curLives--;
        lifeCountText.text = curLives.ToString() + "Lives";
        alive = false;
        tankSprite.enabled = false;
        if (curLives > 0)
        {
            StartCoroutine((_gameController.Respawn(this.gameObject, this)));
        }
        else
        {
            _gameController.DeclareDeath();
        }
    }

    public void SetActiveStatus(bool state)
    {
        active = state;
    }

    public bool ReturnLifeStatus()
    {
        if (curLives > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
