using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ienemie 
{
    // Start is called before the first frame update
    void TakeDamage(int amount);
    void PerformAttack();

}
