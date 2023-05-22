using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public void NewGameButton() {
        Invoke("StartGame", 1f);
    }
    
    private void StartGame() {
        SceneManager.LoadScene("Dungeon");
    }
}
