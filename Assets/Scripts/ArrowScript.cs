using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] private Text displayText;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private string[] textArray;
    private int currentIndex = 0;

    void Start()
    {
        if (textArray.Length > 0)
        {
            displayText.text = textArray[currentIndex];
        }

        leftButton.onClick.AddListener(ChangeTextLeft);
        rightButton.onClick.AddListener(ChangeTextRight);
    }

    void ChangeTextLeft()
    {
        currentIndex = (currentIndex - 1 + textArray.Length) % textArray.Length;
        displayText.text = textArray[currentIndex];
    }

    void ChangeTextRight()
    {
        currentIndex = (currentIndex + 1) % textArray.Length;
        displayText.text = textArray[currentIndex];
    }
}
