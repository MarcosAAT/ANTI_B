using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip[] wingSoundClips;
    [SerializeField] private AudioClip deathSoundClip;
    [SerializeField] private AudioClip[] drinkSoundClips;
    [SerializeField] private AudioClip antiSoundClip;

    public GameManager manager;

    public float upperLimit = 5f;
    private Vector3 direction;
    public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;

    public int ANTIHangoverCureValue = 3; // make sure to change adjust ReduceGravity() and IncreaseGravity() if changing this


    public bool isGameOver = false;
    public bool invincibilityActive = false;

    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D birdCollider;
    private int spriteIndex;
    public Sprite[] sprites;


    public HangoverMeter hangoverMeter;
    private int currentHangoverHealth;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        birdCollider = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        isGameOver = false;

        currentHangoverHealth = hangoverMeter.hangoverStartValue;
    }

    private void Update()
    {
        if (isGameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * strength;
                SoundEffectsManager.instance.PlayRandomSoundFXClip(wingSoundClips, transform, 1f);
            }

            direction.y += gravity * Time.deltaTime;
            Vector3 newPosition = transform.position + direction * Time.deltaTime;
            newPosition.y = Mathf.Min(newPosition.y, upperLimit);

            transform.position = newPosition;

            Vector3 rotation = transform.eulerAngles;
            rotation.z = direction.y * tilt;
            transform.eulerAngles = rotation;
        }
    }

    private bool isLowOpacity = true; // used for invincibility effect (flashing)
    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];

        if (invincibilityActive)
        {
            Color spriteColor = spriteRenderer.color;

            if (isLowOpacity)
            {
                spriteColor.a = 0.3f; // Set to lower opacity
            }
            else
            {
                spriteColor.a = 1f; // Set to full opacity
            }

            spriteRenderer.color = spriteColor;

            // Toggle the opacity on and off
            isLowOpacity = !isLowOpacity;
        }

    }


   

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Drink"){

            SoundEffectsManager.instance.PlayRandomSoundFXClip(drinkSoundClips, transform, 1f);

            //updates the hangover bar
            if (currentHangoverHealth < hangoverMeter.hangoverMax) { // maxs out healthbar at the max variable choosen
                currentHangoverHealth++;
                hangoverMeter.UpdateHangoverMeter(currentHangoverHealth);
            }
        }
        else if (other.gameObject.tag == "ANTI")
        {
            SoundEffectsManager.instance.PlaySoundFXClip(antiSoundClip, transform, 1f);

            //updates the hangover bar
            if (currentHangoverHealth > 0) {
                currentHangoverHealth -= ANTIHangoverCureValue;
                currentHangoverHealth = Mathf.Max(0, currentHangoverHealth); // this makes sure the hangover bar never goes below 0.
                hangoverMeter.UpdateHangoverMeter(currentHangoverHealth);
            }
        }
        else if (other.gameObject.tag == "Ground")
        {
            FindObjectOfType<GameManager>().GameOver();
            isGameOver = true;
            SoundEffectsManager.instance.PlaySoundFXClip(deathSoundClip, transform, 1f);

            // Set the opacity back to full when hitting ground
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 1f;
            spriteRenderer.color = spriteColor;

        }

        else if (other.gameObject.tag == "Obstacle" && !invincibilityActive)
        {
            FindObjectOfType<GameManager>().GameOver();
            isGameOver = true;
            SoundEffectsManager.instance.PlaySoundFXClip(deathSoundClip, transform, 1f);
        }
    }

    public void UpdateGravity(int score)
    {
        if (score % 10 == 0 && score != 0)
        {
            gravity -= 5.0f; // Increase gravity by reducing its value
        }
    }

    public void ResetGravity()
    {
        gravity = -9.81f;
    }

    public void ReduceGravity()
    {
        if (currentHangoverHealth > 0)
        {
            if (currentHangoverHealth <= 2 )
            {
                gravity = -9.81f;
            }
            else gravity += 6f;
        }
    }
    
    public void IncreaseGravity()
    {
        if (currentHangoverHealth < hangoverMeter.hangoverMax)
        {
            gravity -= 2f;
        }
    }

    public void Invincibility()
    {
        invincibilityActive = true;
    }

    public void DeactivateInvinsibility()
    {
        invincibilityActive = false;

        // makes sure the opacity is set back to full
        Color spriteColor = spriteRenderer.color; 
        spriteColor.a = 1f; 
        spriteRenderer.color = spriteColor;
    }
}
