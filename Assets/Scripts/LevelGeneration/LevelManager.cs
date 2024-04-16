using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelSet blueLevels;
    [SerializeField] List<LevelData> currentBlueLevels;
    [SerializeField] LevelSet purpleLevels;
    [SerializeField] List<LevelData> currentPurpleLevels;
    [SerializeField] LevelSet brownLevels;
    [SerializeField] List<LevelData> currentBrownLevels;
    [SerializeField] LevelSet pinkLevels;
    [SerializeField] List<LevelData> currentPinkLevels;
    LevelPhase currentPhase = LevelPhase.First;

    private void Awake() {
        SetCurrentLevels();
        ShuffleArray(currentBlueLevels);
        ShuffleArray(currentPurpleLevels);
        ShuffleArray(currentBrownLevels);
        ShuffleArray(currentPinkLevels);
    }

    private void Start() {
        GenerateNextLevel();
    }

    private void GenerateNextLevel() {
        LevelData nextLevelData = currentBlueLevels.Find(l => l.Phase == currentPhase);

        if(nextLevelData != null) {
            GameObject spawnedLevelPrefab = Instantiate(nextLevelData.Prefab);
            spawnedLevelPrefab.transform.position = Vector3.zero;
            Debug.Log("Spawned level");
        }
    }

    private void SetCurrentLevels() {
        if(blueLevels != null) {
            currentBlueLevels = new List<LevelData>(blueLevels.Levels);
        }
        if(brownLevels != null) {
            currentBrownLevels = new List<LevelData>(brownLevels.Levels);
        }
        if(purpleLevels != null) {
            currentPurpleLevels = new List<LevelData>(purpleLevels.Levels);
        }
        if(pinkLevels != null) {
            currentPinkLevels = new List<LevelData>(pinkLevels.Levels);
        }
    }

    void ShuffleArray(List<LevelData> list) {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            LevelData temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }
}
