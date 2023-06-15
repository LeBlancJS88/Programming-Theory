using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SetVolume : MonoBehaviour
{
        public AudioMixer mixer;

        public void MasterLevel (float sliderValue)
        {
            mixer.SetFloat("GameMainVol", Mathf.Log10(sliderValue) * 20);
        }

        public void MusicLevel(float sliderValue)
        {
            mixer.SetFloat("GameMusicVol", Mathf.Log10(sliderValue) * 20);
        }

        public void SFXLevel(float sliderValue)
        {
            mixer.SetFloat("GameSFXVol", Mathf.Log10(sliderValue) * 20);
        }
    }
