using UnityEngine;
using UnityEngine.UI;

public class SliderValueUpdater : MonoBehaviour
{
    [SerializeField] private Slider[] sliders;
    [SerializeField] private Text[] sliderTexts;

    void Start()
    {
        if (sliders.Length != sliderTexts.Length)
        {
            Debug.LogError("Sliders and SliderTexts arrays must have the same length.");
            return;
        }

        for (int i = 0; i < sliders.Length; i++)
        {
            int index = i;
            sliders[i].minValue = 0;
            sliders[i].maxValue = 100;
            sliders[i].value = 100;
            sliders[i].onValueChanged.AddListener((value) => UpdateSliderText(index, value));
            UpdateSliderText(i, sliders[i].value);
        }
    }

    void UpdateSliderText(int index, float value)
    {
        sliderTexts[index].text = Mathf.RoundToInt(value).ToString();
    }
}
