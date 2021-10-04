using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    private Slider slider;
    private Toggle toggle;
    private float multiplier = 30f;
    private bool disableToggleEvent;

    private void Awake()
    {
        toggle = GetComponentInChildren<Toggle>();
        slider = GetComponent<Slider>();

        slider.onValueChanged.AddListener(UpdateSliderValue);
        toggle.onValueChanged.AddListener(UpdateToggleValue);
    }

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter);
    }

    private void UpdateToggleValue(bool enableSound)
    {
        if (disableToggleEvent)
            return;

        if (enableSound)
            slider.value = slider.maxValue;
        else
            slider.value = slider.minValue;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }

    private void UpdateSliderValue(float value)
    {
        mixer.SetFloat(volumeParameter, Mathf.Log10(value) * multiplier);
        disableToggleEvent = true;
        toggle.isOn = slider.value > slider.minValue;
        disableToggleEvent = false;
    }
}
