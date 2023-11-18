using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;
    public float speed;
    public float horizontal;
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text vida;
    public int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        vida.text = "Life: " + life;
        if(life <= 0)
        {
            gameManager.ResetScene();
        }
        FlipCharacter();
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontal * speed, _rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            gameManager.Score();
            Destroy(collision.gameObject);
        }
    }
    private void FlipCharacter()
    {
        if (horizontal < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
    public void SetLife(int life1)
    {
        life = life - life1;
    }
}
