using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBacteriaBoss_Charge : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] BlueBacteriaBoss bb;

    private void Awake() {
        bb = FindObjectOfType<BlueBacteriaBoss>();
    }
    void Start()
    {
        if(bb.currentPhase == BlueBacteriaBoss.Phase.Phase1) {
            StartCoroutine(Spawn(Vector3.down));
        } else {
            StartCoroutine(Spawn(Vector3.up));
        }
    }

    IEnumerator Spawn(Vector3 dir) {
        yield return new WaitForSeconds(1f);
        GameObject spawnedPrefab = Instantiate(prefab);
        spawnedPrefab.transform.position = transform.position;
        spawnedPrefab.GetComponent<BlueBacteriaBoss_Orb>().DirectionCalc(dir);
        Destroy(this.gameObject);
    }
}
