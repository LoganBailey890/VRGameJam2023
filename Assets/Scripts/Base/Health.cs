using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health;

    public float Damage(float damage)
    {
        return health -= damage;
    }

    public float CurrentHealth()
    {
        return health;
    }
}
