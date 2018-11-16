using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeaponBehavior {

    void Shoot();
    void StopShooting();
    void Reload();
    void Upgrade();
    void Special();

}
