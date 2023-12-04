using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    //Refrences
    protected PlayerStats ps;
    public PassiveItemScriptableObject passiveItemData;
    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<PlayerStats>();
        ApplyModifier();
    }

    protected virtual void ApplyModifier()
    {

    }
}
