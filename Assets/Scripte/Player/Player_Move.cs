using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerMove : MonoBehaviour
{
    PlayerController controller;
    [SerializeField] private TextMeshProUGUI ScorcsText;
    private Rigidbody2D rb;  
    public float speed = 4f;
    private float horizontal;
    private int addPionts;
    private float direction = 0f;
    void Start()
    {   
        controller = new PlayerController();
        rb = GetComponent<Rigidbody2D>();
      
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * speed * Time.deltaTime , rb.velocity.y);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Platfrom"))
        {
            addPionts++;
            ScorcsText.text = "Scorcs :" + addPionts;
            FindObjectOfType<AudioManager>().Play("Land");

        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            addPionts += 5;
            ScorcsText.text = "Scorcs :" + addPionts;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");

        }

    }
   
    public void MoveLeft() { direction = -1f; }           
    public void MoveRight() { direction = 1f; }  
    public void StopMovement() { direction = 0f; }
      
   
}


