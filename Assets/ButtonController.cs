using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button button;
    public LevelUpMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Canvas").GetComponent<LevelUpMenu>();
        button = button.GetComponent<Button>();
        button.onClick.AddListener(test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void test() {
        Debug.Log("Test");
    }
}
