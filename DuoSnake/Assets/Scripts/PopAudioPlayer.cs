using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PopAudioPlayer : MonoBehaviour {

    private AudioSource _audioSource;
    private void Awake() => _audioSource = GetComponent<AudioSource>();
    private void OnEnable() => WordPop.OnAnyWordPopped += PlayPopAudio;
    private void OnDisable() => WordPop.OnAnyWordPopped -= PlayPopAudio;
    private void PlayPopAudio() => _audioSource.Play();
}