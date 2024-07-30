using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    #region Variables
    public int damage = 10; // Example damage amount per attack
    public UnitType targetType;
    #endregion
    
    public void DealDamage(GameObject target)
    {
        target.GetComponent<Health>().ChangeHealth(damage);
    }
   
    void OnTriggerEnter(Collider target)
    {
        switch(targetType)
        {
            case UnitType.Player:
            if (target.CompareTag("Player"))
            {
                DealDamage(target.gameObject);
            }
            break;
            case UnitType.Enemy:
            if (target.CompareTag("Enemy"))
            {
                DealDamage(target.gameObject);
            }
            break;
        }

    }
}