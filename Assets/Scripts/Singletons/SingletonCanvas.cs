using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonCanvas : MonoBehaviour
{
    public static SingletonCanvas instance;
    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
