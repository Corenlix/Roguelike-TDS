using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem destructionParticle;
    protected bool SpawnParticles = true;
    
    public abstract void Init(Vector2 shootPoint, int damage, LayerMask interactiveLayers);

    private void OnDestroy()
    {
        if(!destructionParticle || !SpawnParticles)
            return;

        Instantiate(destructionParticle, transform.position, Quaternion.identity);
    }
}
