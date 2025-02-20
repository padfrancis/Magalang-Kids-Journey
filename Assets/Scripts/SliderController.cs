using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour 
{
    [SerializeField] private Text sliderText = null;

    [SerializeField] private float maxSliderAmount = 100.0f;

    public void SliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        sliderText.text = localValue.ToString("0");
    }

}
