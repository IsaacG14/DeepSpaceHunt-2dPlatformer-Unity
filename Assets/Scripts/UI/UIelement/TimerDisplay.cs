using UnityEngine;
using UnityEngine.UI; // Use TMPro if using TextMeshPro
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Replace with Text if not using TMP
    private float timeElapsed = 0f;
    public bool isCounting = true;

    void Update()
    {
        if (!isCounting) return;

        timeElapsed += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        int milliseconds = Mathf.FloorToInt((timeElapsed * 1000) % 1000);

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void StopTimer()
    {
        isCounting = false;
    }

    public void StartTimer()
    {
        isCounting = true;
        timeElapsed = 0f;
    }
}
