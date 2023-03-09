using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TankController : TankStats, ITankControls, IDamageable
{

    [Header("Tank Arsenal")]
    [SerializeField] GameObject curBullet;
    private BaseBullet bulletStats;
    [SerializeField] Transform bulletPoint;

    [Header("Tank Art")]
    [SerializeField] SpriteRenderer tankSprite;

    [Header("Significant Components")]
    [SerializeField] GameController _gameController;
    [SerializeField] Rigidbody2D _rig2D;
    [SerializeField] Collider2D _col2D;
    [SerializeField] AudioClipPlayer audioManager;
    [SerializeField] TextMeshProUGUI curHPText;
    [SerializeField] TextMeshProUGUI lifeCountText;
    [SerializeField] Image ammoDisplay;

    private TankController lastDamagedBy;
    private bool driveActive;
    private float rotationTimer;

    void Start()
    {
        curLives = maxLives;
        bulletStats = curBullet.GetComponent<BaseBullet>();
        ResetTank();

    }

    // Update is called once per frame
    void Update()
    {
        InvincibilityTimer();
        Reload();
        TankControl();

    }

    public void ResetTank()
    {
        alive = true;
        lastDamagedBy = null;
        tankSprite.enabled = true;
        _col2D.enabled = true;
        curHP = maxHP;
        curAmmo = maxAmmo;

        curDriveSpd = driveSpd;
        curTurnSpd = turnSpd;

        curBulletSpd = baseBulletSpd;
        curshootingRate = shootingRate;
        curReloadRate = reloadRate;

        if (curHPText != null)
            curHPText.text = curHP.ToString();
        
        if (lifeCountText != null)
            lifeCountText.text = curLives.ToString();
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

    public void GrantPoints(int value)
    {
        points += value;
    }

    public void TakeDmg(int dmg, TankController TC = null)
    {
        if (invincible > 0 || !alive || !active)
        {
            if (invincible > 0)
                audioManager.Audio_Invulnerable();
            return;
        }
            

        if (TC != null)
        {
            lastDamagedBy = TC;
        }

        curHP -= dmg;
        if (curHPText != null)
            curHPText.text = curHP.ToString();
        if (curHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        curLives--;
        if (lifeCountText != null)
            lifeCountText.text = curLives.ToString();
        alive = false;
        tankSprite.enabled = false;
        _col2D.enabled = false;

        audioManager.Audio_Death();

        if (lastDamagedBy != null)
        {
            lastDamagedBy.GrantPoints(1);
        }

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

    public int ReturnPoints()
    {
        return points;
    }

    public int ReturnPlayerID()
    {
        return playerID;
    }

    public float ReturnDriveSpd()
    {
        return curDriveSpd;

    }

    public float ReturnTurnSpd()
    {
        return curTurnSpd;

    }

    public bool ReturnActiveStatus()
    {
        if (alive)
            return true;
        else
            return false;
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

    public void SetDriveActive(bool state)
    {
        driveActive = state;
    }

    void TankControl()
    {

        if (!alive)
            return;

        if (driveActive)
        {
            StopRotate();
            Drive();
        }
        else
        {
            Brake();
            Rotate();
        }

        if (rotationTimer > 0)
        {
            rotationTimer -= Time.deltaTime;
            StopRotate();
        }

    }

    public void Drive()
    {
        if (!active)
            return;

        // Calculate the force to apply to the tank based on the acceleration
        Vector2 force = transform.up * 50;

        // Apply the force to the tank Rigidbody2D component
        _rig2D.AddForce(force);

        // Limit the tank's velocity to the maximum speed
        _rig2D.velocity = Vector2.ClampMagnitude(_rig2D.velocity, curDriveSpd);

    }

    public void Brake()
    {
        if (!active || rotationTimer > 0)
            return;

        _rig2D.velocity = new Vector2(0, 0);
    }

    public void Rotate()
    {
        /*
                // accelerate the tank towards the max turn speed
                float desiredTurnSpeed = Mathf.Clamp(_rig2D.angularVelocity - curTurnAccel * Time.fixedDeltaTime * movementMultiplier, -curTurnSpd * movementMultiplier, 0);
                _rig2D.angularVelocity = desiredTurnSpeed;
        */

        if (!active)
            return;

        _rig2D.constraints = RigidbodyConstraints2D.None;
        _rig2D.angularVelocity = curTurnSpd;
    }

    public void StopRotate()
    {
        /*
                // decelerate the tank's turn speed towards zero
                float desiredTurnSpeed = Mathf.Clamp(_rig2D.angularVelocity + curTurnDecel * Time.fixedDeltaTime * movementMultiplier, 0, curTurnSpd * movementMultiplier);
                _rig2D.angularVelocity = desiredTurnSpeed;
        */
        if (!active)
            return;

        _rig2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _rig2D.angularVelocity = 0;

    }

    public void Shoot()
    {
        if (!active)
            return;

        if (curAmmo > 0 && shootingTimer <= 0)
        {
            curAmmo--;
            audioManager.Audio_Shoot();
            UpdateAmmoDisplay();
            Recoil();
            shootingTimer += shootingRate;
            reloadTimer = reloadRate;
            GameObject shotBullet = Instantiate(curBullet, bulletPoint.position, bulletPoint.rotation);
            shotBullet.GetComponent<BaseBullet>().InitializeBullet(this, curBulletSpd);
            rotationTimer = 0.25f;
        }
        else
            audioManager.Audio_Empty();
    }

    public void Recoil()
    {
        if (!active)
            return;

        Debug.Log("Recoil");
        _rig2D.AddRelativeForce(Vector2.down * bulletStats.ReturnRecoil(), ForceMode2D.Impulse);
    }

    public void Reload()
    {
        if (!active)
            return;

        if (shootingTimer > 0)
        {
            shootingTimer -= Time.deltaTime;
            return;
        }
        else if (shootingTimer < 0)
        {
            shootingTimer = 0;
        }

        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
            return;
        }
        else if (reloadTimer < 0)
        {
            reloadTimer = 0;
        }

        if (curAmmo < maxAmmo && reloadTimer == 0)
        {
            reloadTimer = reloadRate;
            curAmmo++;
            UpdateAmmoDisplay();
        }
    }

    void UpdateAmmoDisplay()
    {
        if (curAmmo < 4)
        {
            float fillAmount = (float)curAmmo / maxAmmo;
            ammoDisplay.fillAmount = fillAmount;
        }
        else
        {
            ammoDisplay.fillAmount = 1;
        }
    }

    public void SetTankColor(Color curColor)
    {
        tankSprite.color = curColor;
    }

    public void SetPlayerNumber(int number)
    {
        playerNum = number;
        playerID = playerNum - 1;
    }

    public void SetUI(TextMeshProUGUI text, Image ammoDis)
    {
        lifeCountText = text;
        ammoDisplay = ammoDis;
        lifeCountText.text = curLives.ToString();
        UpdateAmmoDisplay();
    }

}
