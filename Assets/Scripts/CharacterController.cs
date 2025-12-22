using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public int MaxHealth;
    public Image[] Hearts;
    public GameObject DiePanel;

    private Vector2 _inputVector;
    private Rigidbody2D rb;
    private int _currentHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _currentHealth = MaxHealth;
        UpdateHearts();
        DiePanel.SetActive(false);
    }

    void Update()
    {
        _inputVector.x = Input.GetAxisRaw("Horizontal");
        _inputVector.y = Input.GetAxisRaw("Vertical");

        if (_inputVector.x != 0 && _inputVector.y != 0)
        {
            return;
        }

        _inputVector.Normalize();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position +  _inputVector * MovementSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Damage"))
            TakeDamage(1);      
    }

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        UpdateHearts();

        if (_currentHealth <= 0)
            GameOver();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < _currentHealth)
                Hearts[i].enabled = true;
        
            else
                Hearts[i].enabled = false;
        }
    }

    void GameOver()
    {
        DiePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
