using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BattleSettingsPage : MonoBehaviour
{
    [Serializable]
    public class SoundVolumeSliderSettingsData
    {
        public Slider VolumeSlider;
        public Text VolumeText;
        public string VolumeParamNameInMixer;
        private AudioMixer Mixer;

        public void SliderValueChanged(float param)
        {
            Mixer.SetFloat(VolumeParamNameInMixer, param);
            VolumeText.text = param.ToString("F0");
        }

        public void Init(AudioMixer mixer)
        {
            Mixer = mixer;

            float currentBGVolume;
            Mixer.GetFloat(VolumeParamNameInMixer, out currentBGVolume);
            VolumeText.text = currentBGVolume.ToString("F0");
            VolumeSlider.value = currentBGVolume;

            VolumeSlider.onValueChanged.AddListener(SliderValueChanged);
        }
    }

    public GameObject SettingsWindowRoot;
    public Button OpenSettingsButton;
    public Button CloseSettingsButton;
    public AudioMixer Mixer;

    public SoundVolumeSliderSettingsData[] SoundVolumeSettings;

    private void Awake()
    {
        SettingsWindowRoot.SetActive(false);

        void OnOpenSettingsButtonClick()
        {
            SettingsWindowRoot.SetActive(true);
        }

        OpenSettingsButton.onClick.AddListener(OnOpenSettingsButtonClick);

        CloseSettingsButton.onClick.AddListener(() => SettingsWindowRoot.SetActive(false));

        foreach (SoundVolumeSliderSettingsData soundVolumeSetting in SoundVolumeSettings)
            soundVolumeSetting.Init(Mixer);
    }
}
