using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface ITankControls
{

    void ResetTank();

    void SetInvincibility(float iFrameTime);

    void SetActiveStatus(bool active);

    bool ReturnLifeStatus();

    void Drive();

    void Brake();

    void Rotate();

    void StopRotate();

    void Shoot();

    void Reload();

}
