using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer sfxMixer;
    [SerializeField] private Slider musiclider;
    [SerializeField] private Slider sfxSlider;

    public void changeMusicVolume(float value)
    {
        musicMixer.SetFloat("volume", value);
    }

    public void changeSFXVolume(float value)
    {
        musicMixer.SetFloat("volume", value);
    }

    public void back()
    {
        gameObject.SetActive(false);
    }
}
