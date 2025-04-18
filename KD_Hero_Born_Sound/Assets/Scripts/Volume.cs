using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    [SerializeField] string volume = "MasterVolume";
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider slider;
    [SerializeField] float multiplier = 30f;

    private void Awake()
    {

        slider.onValueChanged.AddListener(handle_slider);

    }
    private void OnDisable()
    {

        PlayerPrefs.SetFloat(volume, slider.value);

    }

    private void handle_slider(float value)
    {

        mixer.SetFloat(volume, Mathf.Log10(value) * multiplier);

    }

    private void handle_toggle(bool enabled)
    {

        slider.value = 1f;

        if (!enabled)
        {
            slider.value = 0.0001f;
        }
        else
        {
            slider.value = 1f;
        }

    }

    void Start()
    {

        slider.value = PlayerPrefs.GetFloat(volume, slider.value);

    }



}
