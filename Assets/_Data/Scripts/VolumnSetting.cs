using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumnSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicCarSlider;
    [SerializeField] private Slider musicCarEngineSlider;
    [SerializeField] private Slider musicCarHitSlider;
    [SerializeField] private Slider musicCarScreechSlider;
    [SerializeField] private Slider musicCarBrakingSlider;
    [SerializeField] private Slider musicAlarmLightSlider;
    [SerializeField] private Slider music321GoSlider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("volumnCar") ||
            PlayerPrefs.HasKey("volumnCarEngine") ||
            PlayerPrefs.HasKey("volumnCarHit") ||
            PlayerPrefs.HasKey("volumnCarScreech") ||
            PlayerPrefs.HasKey("volumnCarBraking") ||
            PlayerPrefs.HasKey("volumnPolice") ||
            PlayerPrefs.HasKey("volumnCountDown")
            )
        {
            LoadVolumn();
        }
        else
        {
            SetVolumnCar();
        }
    }
    public void SetVolumnCar()
    {
        float volumnCar = musicCarSlider.value;
        float volumnCarEngine = musicCarEngineSlider.value;
        float volumnCarHit = musicCarHitSlider.value;
        float volumnCarScreech = musicCarScreechSlider.value;
        float volumnCarBraking = musicCarBrakingSlider.value;
        float volumnCarPolice = musicAlarmLightSlider.value;
        float volumnCar321Go = music321GoSlider.value;

        audioMixer.SetFloat("volumnCar", Mathf.Log10(volumnCar) * 20);
        audioMixer.SetFloat("volumnCarEngine", Mathf.Log10(volumnCarEngine) * 20);
        audioMixer.SetFloat("volumnCarHit", Mathf.Log10(volumnCarHit) * 20);
        audioMixer.SetFloat("volumnCarScreech", Mathf.Log10(volumnCarScreech) * 20);
        audioMixer.SetFloat("volumnCarBraking", Mathf.Log10(volumnCarBraking) * 20);
        audioMixer.SetFloat("volumnPolice", Mathf.Log10(volumnCarPolice) * 20);
        audioMixer.SetFloat("volumnCountDown", Mathf.Log10(volumnCar321Go) * 20);

        PlayerPrefs.SetFloat("volumnCar", volumnCar);
        PlayerPrefs.SetFloat("volumnCarEngine", volumnCarEngine);
        PlayerPrefs.SetFloat("volumnCarHit", volumnCarHit);
        PlayerPrefs.SetFloat("volumnCarScreech", volumnCarScreech);
        PlayerPrefs.SetFloat("volumnCarBraking", volumnCarBraking);
        PlayerPrefs.SetFloat("volumnPolice", volumnCarPolice);
        PlayerPrefs.SetFloat("volumnCountDown", volumnCar321Go);
    }

    private void LoadVolumn()
    {
        musicCarSlider.value = PlayerPrefs.GetFloat("volumnCar");
        musicCarEngineSlider.value = PlayerPrefs.GetFloat("volumnCarEngine");
        musicCarHitSlider.value = PlayerPrefs.GetFloat("volumnCarHit");
        musicCarScreechSlider.value = PlayerPrefs.GetFloat("volumnCarScreech");
        musicCarBrakingSlider.value = PlayerPrefs.GetFloat("volumnCarBraking");
        musicAlarmLightSlider.value = PlayerPrefs.GetFloat("volumnPolice");
        music321GoSlider.value = PlayerPrefs.GetFloat("volumnCountDown");
        SetVolumnCar();
    }
}
