using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject OptionMenu;
    [SerializeField] private GameObject pauseButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            OptionMenu.SetActive(true);
            Time.timeScale = 0f;
            pauseButton.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Selected");
        }
    }
}
