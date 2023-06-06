using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public enum State {
        Inactive,        
        Active
    }

    public static State state;
    // Start is called before the first frame update
    void Start()
    {
        if(state == State.Active) {
            Debug.Log(CharacterStats.Shield); 
            GameObject player = GameObject.FindGameObjectWithTag("Controller");
            player.transform.GetChild(6).gameObject.SetActive(true);
        }
    }

}
