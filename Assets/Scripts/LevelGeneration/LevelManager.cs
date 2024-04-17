using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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


    static LevelPhase currentPhase = LevelPhase.First;

    private LevelPhase[] phaseSequence = new LevelPhase[]
    {
        LevelPhase.First,
        LevelPhase.Second,
        LevelPhase.Third,
        LevelPhase.Fourth,
        LevelPhase.Boss_One,
        LevelPhase.Fifth,
        LevelPhase.Sixth,
        LevelPhase.Seventh,
        LevelPhase.Eighth,
        LevelPhase.Boss_Two
    };

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
        LevelData nextLevelData = currentPurpleLevels.Find(l => l.Phase == currentPhase);

        if(nextLevelData != null) {
            GameObject spawnedLevelPrefab = Instantiate(nextLevelData.Prefab);
            spawnedLevelPrefab.transform.position = Vector3.zero;

            UpdateCurrentPhase();
        }
    }

    void UpdateCurrentPhase() {
        int currentIndex = Array.IndexOf(phaseSequence, currentPhase);

        // Check if the current phase is found in the sequence
        if (currentIndex != -1 && currentIndex < phaseSequence.Length - 1) {
            // Update the current phase to the next phase in the sequence
            currentPhase = phaseSequence[currentIndex + 1];

            PlayerPrefs.SetInt("CurrentIndex", currentIndex + 1);
            PlayerPrefs.Save(); // Save PlayerPrefs data immediately
        }
        else {
            // Handle the case where the current phase is not found or it's the last phase
            Debug.LogWarning("No next phase defined for current phase: " + currentPhase);
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
