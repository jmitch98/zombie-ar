using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour {
    public float MoveSpeed = 3f;
    public GameObject Splatter;
    private GameObject _target;
    private bool _canAttack = true;

    void Awake() {
        _target = GameObject.FindGameObjectWithTag("Destination");
    }

    void Update() {
        transform.LookAt(_target.transform, _target.transform.up);
        if (Vector3.Distance(_target.transform.position, transform.position) <= 0.27f) {
            if (_canAttack) Attack();

        }
        else {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                _target.transform.position, 
                MoveSpeed * Time.deltaTime
            );
        }
    }

    void OnGUI() {

    }

    public void Attack() {
        _target.transform.GetComponent<Destination>().Damage();
    }

    public void Die() {
        Vector3 pos = transform.position;
        pos.y = 0;
        GameObject splat = Instantiate(
            Splatter, 
            transform.position, 
            Quaternion.Euler(new Vector3(0, 0, 0))
        );

        splat.transform.parent = transform.parent.transform;
        Destroy(gameObject);
    }
}
