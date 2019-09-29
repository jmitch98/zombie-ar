using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour {
    public float MoveSpeed = 3f;
    private GameObject _target;

    void Awake() {
        _target = GameObject.FindGameObjectWithTag("Destination");
    }

    void Update() {
        if (transform.position == _target.transform.position) {
            Destroy(gameObject);
            Debug.Log("Zombie reached EOL");
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, MoveSpeed * Time.deltaTime);
    }
}
