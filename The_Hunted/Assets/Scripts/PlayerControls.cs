using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 7;
    private Vector3 moveDirections = Vector3.zero;
    public int health;

    private EnemyFollow enemy;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        enemy = FindObjectOfType<EnemyFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);


        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            health = health - enemy.damage;

            if(health <= 0)
            {
                GameManager.Instance.GameOver();

                Destroy(gameObject);
            }
        }
    }

}
