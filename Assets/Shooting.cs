using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public Texture2D crosshairImage;
    public int score = 0;
    public GameObject Splatter;
    public float crosshairFractionScale = 0.125f;

    public Font scoreFont;

    void OnGUI() {
        // Render crosshairs
        // -----------------
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

        // Render score
        // ------------
        GUIStyle style = new GUIStyle();
        style.font = scoreFont;
        style.fontSize = 100;
        style.alignment = TextAnchor.UpperCenter;
        style.normal.textColor = Color.white;
        GUI.Label(
            new Rect(
                Screen.width/2 - 50,
                100,
                100,
                20
            ),
            "Score: " + score.ToString(),
            style
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
                hit.transform.GetComponent<ZombieMove>().Die();
                score += 100;
            }
        }
    }
}
