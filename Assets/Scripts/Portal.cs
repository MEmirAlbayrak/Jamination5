using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private bool isLastMap;
    private static Portal portal;
    public static Portal Instance => portal;

    private void Awake() {
        if (portal == null)
        {
            portal = this;
        }

        else
        {
            Destroy(gameObject);
        }       
    }
    private void Start() {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            if (isLastMap) {
                return;
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
