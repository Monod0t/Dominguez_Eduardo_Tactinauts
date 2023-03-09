using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{

    private GameController GC;
    private TankController TC;
    private float bulletSpd;

    [SerializeField] int bulletLifetime; // How long the bullet lasts
    [SerializeField] int bulletDmg; // Dmg inflicted on damageable objects
    [SerializeField] int recoilForce; // Recoil from shooting

    private void Start()
    {
        Destroy(this.gameObject, bulletLifetime);
    }

    private void Update()
    {
        BulletMotion();
    }

    public void InitializeBullet(TankController tankController, float curBulletSpd)
    {
        TC = tankController;
        bulletSpd = curBulletSpd;
        GC = FindObjectOfType<GameController>();
    }

    void BulletMotion()
    {
        // move the bullet forward in its current direction
        transform.Translate(Vector2.up * bulletSpd * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // check if the bullet has collided with an object that can take damage
        IDamageable damageableObject =
            other.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            // apply damage to the other object
            other.gameObject.GetComponent<IDamageable>().TakeDmg(bulletDmg, TC);
        }

        // destroy the bullet
        Destroy(this.gameObject);
    }

    public int ReturnRecoil()
    {
        return recoilForce;
    }

}
