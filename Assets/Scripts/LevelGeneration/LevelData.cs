using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Level/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] GameObject _levelPrefab;
    [SerializeField] LevelPhase _phase;

    public enum LevelPhase {
        First,
        Second,
        Third,
        Fourth,
        Boss
    }

    public GameObject Prefab
    {
        get => _levelPrefab;
        private set => _levelPrefab = value;
    }

    public LevelPhase Phase
    {
        get => _phase;
        private set => _phase = value;
    }
}
