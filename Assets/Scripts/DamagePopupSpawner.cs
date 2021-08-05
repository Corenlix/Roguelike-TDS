using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class DamagePopupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject damagePopupPrefab;
    public static DamagePopupSpawner Instance;

    private void Awake()
    {
        if(Instance)
            Destroy(Instance.gameObject);
        Instance = this;
    }
    public void SpawnDamagePopup(Vector2 position, int damage)
    {
        var spawnedPopup = Instantiate(damagePopupPrefab,  position, quaternion.identity, transform);
        spawnedPopup.GetComponentInChildren<TextMeshPro>().text = damage.ToString();
    }
}
