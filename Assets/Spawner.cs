using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject zombie;
    public float spawnTime = 1f;
    private GameObject _target;

    void Awake() {
        _target = GameObject.FindGameObjectWithTag("Destination");
    }

    void Start() {
        InvokeRepeating("SpawnZombie", spawnTime, spawnTime);
    }

    void SpawnZombie() {
        float angle = Random.Range(-Mathf.PI, Mathf.PI);
        Vector3 pos = _target.transform.position;
        pos += new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * 3;
        pos.y = 0;
        GameObject z = Instantiate(zombie, gameObject.transform.TransformPoint(pos), Quaternion.Euler(new Vector3(0, 0, 0)));
        z.transform.parent = gameObject.transform.parent.transform;
    }
}
