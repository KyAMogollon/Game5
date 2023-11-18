using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitVegetables : MonoBehaviour
{
    PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            controller = player.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            controller.SetLife(1);
            Destroy(this.gameObject);
        }
    }
}
