using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class SpawnObjectAfterTakingDamage : MonoBehaviour
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

    private void SpawnObject()
    {
        Instantiate(newObject, transform.position, Quaternion.identity);
    }
}
