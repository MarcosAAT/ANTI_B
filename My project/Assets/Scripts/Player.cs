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

    public int ANTIHangoverCureValue = 3;


    public bool isGameOver = false;

    private SpriteRenderer spriteRenderer;
    private int spriteIndex;
    public Sprite[] sprites;


    public HangoverMeter hangoverMeter;
    private int currentHangoverHealth;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }


   

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Drink"){

            SoundEffectsManager.instance.PlayRandomSoundFXClip(drinkSoundClips, transform, 1f);

            //updates the hangover bar
            if (currentHangoverHealth < hangoverMeter.hangoverMax) { 
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
        gravity *= 0.9f;
    }
    
    public void IncreaseGravity()
    {
        gravity *= 1.1f; // Increase gravity by 10%
    }
}
