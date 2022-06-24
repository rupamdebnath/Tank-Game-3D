using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    BulletController bulletController;
    Rigidbody rb;
    public LayerMask tankMask;

    public ParticleSystem explosionParticles;

    public float explosionForce = 1000f;
    public float maxLifeTime = 2f;
    public float explosionRadius = 5f;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public void setBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public Rigidbody GetRigidBody()
    {
        return rb;
    }

    public BulletSO bullet;

    //[Obsolete] duration particle effect, using explosionParticles.main.
    private void OnTriggerEnter(Collider other)
    {       
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidBody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidBody)
                continue;
            targetRigidBody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            if (targetRigidBody.GetComponent<Transform>().tag == "Player")
            {              
                float damage = CalculateDamage(targetRigidBody.position);
                targetRigidBody.GetComponent<TankView>().setHealth(damage);

                if (targetRigidBody.GetComponent<TankView>().getHealth() <= 0)
                {
                    targetRigidBody.GetComponent<TankView>().PlayExplosion();
                    targetRigidBody.gameObject.SetActive(false);
                }
            }
            else if (targetRigidBody.GetComponent<Transform>().tag == "Enemy")
            {                
                float damage = CalculateDamage(targetRigidBody.position);
                targetRigidBody.GetComponent<EnemyTankView>().setHealth(damage);
                if (targetRigidBody.GetComponent<EnemyTankView>().getHealth() <= 0)
                {   
                    ServiceEvents.Instance.Count();                    
                    ServiceEvents.Instance.OnEnemyDeath?.Invoke(ServiceEvents.Instance.GetCountOfEnemiesDead());
                    targetRigidBody.GetComponent<EnemyTankView>().PlayExplosion();
                    Destroy(targetRigidBody.gameObject);

                }
                else
                    continue;
            }
        }
        explosionParticles.Play();
        //Debug.Log("Playing explosion");
        StartCoroutine(SetParticleInactive(explosionParticles.gameObject, explosionParticles.main.duration));       
    }

    IEnumerator SetParticleInactive(GameObject obj, float duration)
    {
        yield return new WaitForSeconds(duration);                
        BulletService.Instance.ReturnObjectToPoolDirectly(bulletController);
        bulletController.Disable();
        //obj.SetActive(false);
    }

    private float CalculateDamage(Vector3 _targetposition)
    {
        Vector3 explosionToTarget = _targetposition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
        float damage = relativeDistance * bullet.maxDamage;
        damage = Mathf.Max(0, damage);
        return damage;
    }

    public BulletController GetBulletController()
    {
        return bulletController;
    }

}
