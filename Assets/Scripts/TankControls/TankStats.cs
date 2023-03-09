using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStats : MonoBehaviour
{
    [Header("Tank Data")]
    [SerializeField] protected int playerNum;
    [SerializeField] protected int points;
    [SerializeField] protected int maxHP = 1;
    [SerializeField] protected int maxLives = 3;
    [SerializeField] protected int maxAmmo = 3;

    protected int playerID;
    protected int curHP;
    protected int curLives;
    protected int curAmmo;

    [Header("Tank Movement")]
    [SerializeField] protected float driveSpd = 10;
    [SerializeField] protected float turnSpd = 10;

    protected float curDriveSpd;
    protected float curTurnSpd;

    [Header("Shooting")]
    [SerializeField] protected float baseBulletSpd = 15;
    [SerializeField] protected float shootingRate = 0.5f;
    [SerializeField] protected float reloadRate = 1;

    protected float curBulletSpd;
    protected float curshootingRate;
    protected float curReloadRate;

    protected float shootingTimer;
    protected float reloadTimer;

    [Header("Tank Status")]
    [SerializeField] protected bool active = false;
    [SerializeField] protected bool alive = true;
    [SerializeField] protected float invincible;
    [SerializeField] protected bool driveEnabled = false;
    [SerializeField] protected bool turnEnabled = false;
    [SerializeField] protected bool shootEnabled = false;

    


}
