using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Player: MonoBehaviour{
    public float upperLimit = 5f; 
    private Vector3 direction; 
    public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;

    public bool isGameOver = false;

    private SpriteRenderer spriteRenderer;
    private int spriteIndex;
    public Sprite[] sprites;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        isGameOver = false;
    }

    private void Update()
    {
        // This will stop the character from moving after the game is over
        if(isGameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * strength;
            }


            direction.y += gravity * Time.deltaTime;
            Vector3 newPosition = transform.position + direction * Time.deltaTime;
            newPosition.y = Mathf.Min(newPosition.y, upperLimit);

            // Update the position
            transform.position = newPosition;


            // Tilt the bird based on the direction
            Vector3 rotation = transform.eulerAngles;
            rotation.z = direction.y * tilt;
            transform.eulerAngles = rotation;
        }
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        
        spriteRenderer.sprite = sprites[spriteIndex];
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Obstacle"){
            //FindObjectOfType<GameManager>().GameOver(); 
            //Destroy(gameObject);

        } else if(other.gameObject.tag == "ScoreWine"){
            FindObjectOfType<GameManager>().DecreaseScore();

        } else if(other.gameObject.tag == "Ground"){
            FindObjectOfType<GameManager>().GameOver();
            isGameOver = true;
        }
    }

   

}
