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

    private void Start()
    {
        musiclider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void changeMusicVolume(float value)
    {
        musicMixer.SetFloat("volume", value);
        PlayerPrefs.SetFloat("musicVolume", value);
    }

    public void changeSFXVolume(float value)
    {
        musicMixer.SetFloat("volume", value);
        PlayerPrefs.SetFloat("sfxVolume", value);
    }

    public void back()
    {
        gameObject.SetActive(false);
    }
}
