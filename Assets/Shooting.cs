using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public Texture2D crosshairImage;
    public float crosshairFractionScale = 0.125f;

    void OnGUI() {
        float xMin = (Screen.width / 2) - ((crosshairImage.width * crosshairFractionScale) / 2);
        float yMin = (Screen.height / 2) - ((crosshairImage.height * crosshairFractionScale) / 2);
        GUI.DrawTexture(
            new Rect(
                xMin, 
                yMin, 
                crosshairImage.width * crosshairFractionScale, 
                crosshairImage.height * crosshairFractionScale), 
            crosshairImage
        );
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void Shoot() {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f)) {
            if (hit.transform.tag == "Zombie") {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
