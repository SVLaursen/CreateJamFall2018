using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeaponBehavior {

    void Shoot(int k);
    void StopShooting(int k);
    void Reload();
    void Upgrade();
    void Special();

}
