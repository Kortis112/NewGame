using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    protected override bool PersistBetweenScenes => false;
    public static EnemyManager Instance { get; private set; }

    public static event Action OnRoomCleared;

    private readonly List<EnemyHealth> _enemies = new();

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;

        _enemies.AddRange(FindObjectsOfType<EnemyHealth>());
    }

    public void Unregister(EnemyHealth e)
    {
        _enemies.Remove(e);
        if (_enemies.Count == 0) OnRoomCleared?.Invoke();
    }
}
