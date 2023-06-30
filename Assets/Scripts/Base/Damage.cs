using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            if (health.CurrentHealth() > 0)
                health.Damage(damage);
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            if (health.CurrentHealth() > 0)
                health.Damage(damage);
        }
    }


}
