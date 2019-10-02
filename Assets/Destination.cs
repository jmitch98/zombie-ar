using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour {
    private int health = 100;
    private int maxHealth = 100;
    public int damageValue = 7;
    private bool canDamage = true;
    public Font scoreFont;
    public SimpleHealthBar healthBar;
    public bool gameOver = false;
    void Start() {
        healthBar.UpdateBar(health, maxHealth);
    }

    void OnGUI() {
        // Game over text
        // --------------
        if (gameOver) {
            GUIStyle style = new GUIStyle();
            style.font = scoreFont;
            style.fontSize = 100;
            style.alignment = TextAnchor.MiddleCenter;
            style.normal.textColor = Color.white;
            GUI.Label(
                new Rect(
                    Screen.width/2 - 50,
                    Screen.height/2 - 20,
                    100,
                    20
                ),
                "Game Over!",
                style
            );

            // Start new game on tap
            // ---------------------
            if (Input.GetMouseButtonDown(0)) {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void Update() {
        if (health <= 0) {
            Time.timeScale = 0;
            gameOver = true;
        }        
    }

    public void Damage() {
        StartCoroutine(DoDamage());
    }

    public int Health() {
        return health;
    }

    IEnumerator DoDamage() {
        if (canDamage) {
            canDamage = false;
            health -= damageValue;
            healthBar.UpdateBar(health, maxHealth);
            yield return new WaitForSeconds(1.5f);
            canDamage = true;
        }
    }
}
