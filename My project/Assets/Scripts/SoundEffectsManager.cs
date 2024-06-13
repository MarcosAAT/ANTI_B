using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{

    public static SoundEffectsManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume) {

        //spawn in game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign the audioClip
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play(); 

        //get length of sfx clip
        float clipLength = audioSource.clip.length;

        //destroy the clip after it is done
        Destroy(audioSource.gameObject, clipLength);


 
}

public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume) {

        //assign a random index
        int rand = Random.Range(0, audioClip.Length);


        //spawn in game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign the audioClip
        audioSource.clip = audioClip[rand];

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play(); 

        //get length of sfx clip
        float clipLength = audioSource.clip.length;

        //destroy the clip after it is done
        Destroy(audioSource.gameObject, clipLength);


 
}
}
