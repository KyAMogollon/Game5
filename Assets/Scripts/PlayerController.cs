using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed;
    public float horizontal;
    [SerializeField] GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontal * speed, _rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            gameManager.Score();
            Destroy(collision.gameObject);
        }
    }
}
