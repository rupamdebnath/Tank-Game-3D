using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    public LayerMask tankMask;

    public ParticleSystem explosionParticles;

    private float maxDamage;
    public float explosionForce = 1000f;
    public float maxLifeTime = 2f;
    public float explosionRadius = 5f;

    private void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    //[Obsolete] duration particle effect, using explosionParticles.main.
    private void OnTriggerEnter(Collider other)
    {       
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);
        //float targetHealth;
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidBody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidBody)
                continue;
            targetRigidBody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            if (targetRigidBody.GetComponent<TankView>())
            {
                //targetHealth = targetRigidBody.GetComponent<TankView>().getHealth();
                float damage = CalculateDamage(targetRigidBody.position);
                targetRigidBody.GetComponent<TankView>().setHealth(damage);
                if (targetRigidBody.GetComponent<TankView>().getHealth() <= 0)
                {
                    Destroy(targetRigidBody.gameObject);
                }
            }
            else if (targetRigidBody.GetComponent<EnemyTankView>())
            {
                float damage = CalculateDamage(targetRigidBody.position);
                //targetHealth = targetRigidBody.GetComponent<EnemyTankView>().getHealth();
                //target health deduction
                targetRigidBody.GetComponent<EnemyTankView>().setHealth(damage);

                if (targetRigidBody.GetComponent<EnemyTankView>().getHealth() <= 0)
                {
                    Destroy(targetRigidBody.gameObject);
                }
                else
                    continue;
            }            

        }
        explosionParticles.transform.parent = null;
        explosionParticles.Play();
        Destroy(explosionParticles.gameObject, explosionParticles.main.duration);
        Destroy(gameObject);
    }

    private float CalculateDamage(Vector3 _targetposition)
    {
        Vector3 explosionToTarget = _targetposition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
        float damage = relativeDistance * maxDamage;
        damage = Mathf.Max(0, damage);
        return damage;
    }

    //public float setMaxDamage(float _damage)
    //{
    //    maxDamage = 30f;
    //    return maxDamage;
    //}
}
