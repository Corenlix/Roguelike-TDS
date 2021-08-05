using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemiesRune : MonoBehaviour
{
    public UnityEvent<SpawnEnemiesRune> runeDestroyed; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            runeDestroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
