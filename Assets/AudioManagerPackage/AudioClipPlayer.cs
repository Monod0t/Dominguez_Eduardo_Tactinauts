using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipPlayer : MonoBehaviour
{
    [SerializeField] AudioClip _death = null;
    [SerializeField] AudioClip _shoot = null;
    [SerializeField] AudioClip _empty = null;
    [SerializeField] AudioClip _invulnerable = null;

    public void Audio_Death()
    {
        AudioSource audioSource = AudioHelper._playClip2D(_death, 1f);
        audioSource.pitch = UnityEngine.Random.Range(0.5f, 1);
    }

    public void Audio_Shoot()
    {
        AudioSource audioSource = AudioHelper._playClip2D(_shoot, 0.25f);
        audioSource.pitch = UnityEngine.Random.Range(0.5f, 1);
    }

    public void Audio_Empty()
    {
        AudioSource audioSource = AudioHelper._playClip2D(_empty, 0.5f);
        audioSource.pitch = UnityEngine.Random.Range(0.5f, 1);
    }

    public void Audio_Invulnerable()
    {
        AudioSource audioSource = AudioHelper._playClip2D(_invulnerable, 0.5f);
        audioSource.pitch = UnityEngine.Random.Range(0.5f, 1);
    }

}
