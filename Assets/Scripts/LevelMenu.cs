using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelMenu : MonoBehaviour
{
    public Button[] LevelButtons;
    private void Awake()
    {
        int UnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            if (i + 1 > UnlockedLevel)
            {
                LevelButtons[i].interactable = false;
            }
        }
    }
    public void OpenLevel(int LevelId)
    {
        string levelName = "Level " + LevelId;
        SceneManager.LoadScene(levelName);
    }
}
