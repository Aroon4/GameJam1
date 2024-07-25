using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{


[SerializeField] private AudioClip[] clips;
private int clipIndex;
private AudioSource audio1;
private bool audioPlaying = false;

void Start()
{
    audio1 = gameObject.GetComponent<AudioSource>();
}
void Update()
    {

        if (!audio1.isPlaying) 
        {

            clipIndex = Random.Range(0, clips.Length);
            audio1.clip = clips[clipIndex];
            audio1.PlayDelayed(Random.Range(10f, 20f));
            Debug.Log("Nothing playing, we set new audio to " + audio1.clip.name);
        }
    }
}