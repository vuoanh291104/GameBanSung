using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource backGroundSource;
    public AudioSource sfxSource;
    public AudioClip shootClip;
    public AudioClip deadClip;
    public AudioClip backgroundClip;
    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        PhatNhacNen();
    }
    void PhatNhacNen(){
        backGroundSource.clip = backgroundClip;
        backGroundSource.Play();
    }
    public void PlayShootClip(){
        sfxSource.PlayOneShot(shootClip);
    }
    public void PlayDeadClip(){
        sfxSource.PlayOneShot(deadClip);
    }

}
