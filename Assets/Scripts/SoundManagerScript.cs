using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound;
    public static AudioClip walkSound;
    public static AudioClip shootSound;
    public static AudioClip electricitySound;
    public static AudioClip hydraulicSound;
    public static AudioClip leverSound;
    public static AudioClip powerUpSound;
    public static AudioClip powerDownSound;
    public static AudioClip blipSound;
    public static AudioClip lazerSound;

    static AudioSource audioSrc;
    void Start()
    {
        shootSound = Resources.Load<AudioClip>("Shoot");
        jumpSound = Resources.Load<AudioClip>("Jump");
        walkSound = Resources.Load<AudioClip>("Walk");
        electricitySound = Resources.Load<AudioClip>("Electricity");
        leverSound = Resources.Load<AudioClip>("Lever");
        hydraulicSound = Resources.Load<AudioClip>("Hydraulic");
        powerDownSound = Resources.Load<AudioClip>("PowerDown");
        powerUpSound = Resources.Load<AudioClip>("PowerUp");
        blipSound = Resources.Load<AudioClip>("Blip");
        lazerSound = Resources.Load<AudioClip>("Lazer");

        audioSrc = GetComponent<AudioSource>();
    }
    
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "Walk":
                audioSrc.PlayOneShot(walkSound);
                break;
            case "Shoot":
                audioSrc.PlayOneShot(shootSound);
                break;
            case "Lever":
                audioSrc.PlayOneShot(leverSound);
                break;
            case "Hydraulic":
                audioSrc.PlayOneShot(hydraulicSound);
                break;
            case "Electricity":
                audioSrc.PlayOneShot(electricitySound);
                break;
            case "PowerDown":
                audioSrc.PlayOneShot(powerDownSound);
                break;
            case "PowerUp":
                audioSrc.PlayOneShot(powerUpSound);
                break;
            case "Blip":
                audioSrc.PlayOneShot(blipSound);
                break;
            case "Lazer":
                audioSrc.PlayOneShot(lazerSound);
                break;
        }
    }
}
