using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class OnTakeDamageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject newObject;
    private void OnEnable()
    {
        GetComponent<Health>().onDamaged?.AddListener(SpawnObject);
    }

    private void OnDisable()
    {
        GetComponent<Health>().onDamaged?.RemoveListener(SpawnObject);
    }

    private void SpawnObject(int damage)
    {
        Instantiate(newObject, transform.position, Quaternion.identity);
    }
}
