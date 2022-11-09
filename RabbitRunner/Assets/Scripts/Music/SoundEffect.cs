using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource deathEffect;

    public bool levelsong = true;
    public bool deathsong = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void LevelMusic()
    {
        levelsong = true;
        deathsong = false;
        levelMusic.Play();
    }

    public void DeathSound()
    {
        if(levelMusic.isPlaying)
        {
            levelsong = false;
            levelMusic.Stop();
        }
        if(!deathEffect.isPlaying && deathsong==false)
        {
            deathEffect.Play();
            deathsong = true;
        }
    }
}
