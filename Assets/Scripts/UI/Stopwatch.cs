using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour {
    public Text timerText;  // Reference to the UI Text component to display the timer

    private float elapsedTime = 0f;  // Elapsed time in seconds
    private bool isRunning = false;  // Flag to control stopwatch running state

    private void Start() {
        StartStopwatch();
    }

    private void Update() {
        if (isRunning) {
            // Update the elapsed time if the stopwatch is running
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay() {
        // Convert the elapsed time to a formatted string (mm:ss)
        string minutes = Mathf.Floor(elapsedTime / 60).ToString("00");
        string seconds = Mathf.Floor(elapsedTime % 60).ToString("00");
        string timeString = string.Format("{0}:{1}", minutes, seconds);

        // Update the UI Text component with the formatted time string
        timerText.text = timeString;
    }

    public void StartStopwatch() {
        // Start or resume the stopwatch
        isRunning = true;
    }

    public void PauseStopwatch() {
        // Pause the stopwatch
        isRunning = false;
    }

    public void ResetStopwatch() {
        // Reset the elapsed time
        elapsedTime = 0f;
        UpdateTimerDisplay();  // Update the display to show reset time
    }
}
