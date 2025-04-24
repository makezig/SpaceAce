using System.Collections.Generic;
using UnityEngine;

public class FoodForward : MonoBehaviour
{
    public float speed = 40.0f; // adjust foods speed
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    // Keep track of last 3 played clips
    private Queue<AudioClip> lastPlayed = new Queue<AudioClip>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get AudioSource only once
        PlayRandomClip(); // Play sound when food is shot

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed); // move food forward
        
    }
    void PlayRandomClip()
    {
        if (audioClips.Length == 0) return;

        AudioClip chosenClip = null;
        int attempts = 0;

        // Try to pick a clip not in the last 3
        do
        {
            chosenClip = audioClips[Random.Range(0, audioClips.Length)];
            attempts++;
        } while (lastPlayed.Contains(chosenClip) && attempts < 10); // prevent infinite loops

        // Play the clip
        audioSource.clip = chosenClip;
        audioSource.volume = 0.6f; // lower the volume here
        audioSource.Play();

        // Update the queue
        lastPlayed.Enqueue(chosenClip);
        if (lastPlayed.Count > 3)
            lastPlayed.Dequeue();
    }
}
