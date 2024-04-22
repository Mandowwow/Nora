using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LevelPhase {
    First,
    Second,
    Third,
    Fourth,
    Boss_One,
    Fifth,
    Sixth,
    Seventh,
    Eighth,
    Boss_Two
}

[CreateAssetMenu(fileName = "LevelData", menuName = "Level/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] GameObject _levelPrefab;
    [SerializeField] LevelPhase _phase;

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
