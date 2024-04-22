using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSet", menuName = "Level/LevelSet")]
public class LevelSet : ScriptableObject
{
    [SerializeField] List<LevelData> _levels = new List<LevelData>();

    public List<LevelData> Levels
    {
        get => _levels;
        private set => _levels = value;
    }
}
