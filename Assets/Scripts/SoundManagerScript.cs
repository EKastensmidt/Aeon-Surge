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

    static AudioSource audioSrc;
    void Start()
    {
        shootSound = Resources.Load<AudioClip>("Shoot");
        jumpSound = Resources.Load<AudioClip>("Jump");
        walkSound = Resources.Load<AudioClip>("Walk");
        electricitySound = Resources.Load<AudioClip>("Electricity");
        leverSound = Resources.Load<AudioClip>("Lever");
        hydraulicSound = Resources.Load<AudioClip>("Hydraulic");


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

        }
    }
}
