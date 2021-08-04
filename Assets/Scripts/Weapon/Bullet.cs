using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem destructionParticle;
    protected bool SpawnParticles = true;
    protected AttackParams AttackParams;

    public void Init(Vector2 shootPoint, AttackParams attackParams)
    {
        AttackParams = attackParams;
        Shoot(shootPoint);
    }

    protected abstract void Shoot(Vector2 shootPoint);
    private void OnDestroy()
    {
        if(!destructionParticle || !SpawnParticles)
            return;

        Instantiate(destructionParticle, transform.position, Quaternion.identity);
    }
}
