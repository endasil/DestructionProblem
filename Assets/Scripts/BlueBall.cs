using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : MonoBehaviour
{
    private SpawnManager spawnManager;
    private void Awake() => spawnManager = FindObjectOfType<SpawnManager>();
    private void OnDestroy() => spawnManager.AddBlueDestroyed();
    public bool Dying = false;
}
