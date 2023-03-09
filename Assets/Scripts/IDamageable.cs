using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDmg(int dmg, TankController TC = null);

    void Die();

}
