using TMPro;
using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI multiplierText; // Reference to mult text
    [SerializeField] private float score = 0;

    public string shipName;
    public float publicScore = 0;

    public int tapCount = 0;
    private float lastTapsPerSecond;

    private void Start()
    {
        StartCoroutine(MeasureTapsPerSecond());

        if (multiplierText != null)
            multiplierText.text = "";
    }

    public float tapSpeed()
    {
        return lastTapsPerSecond;
    }

    public float GetTapMultiplier()
    {
        float speed = tapSpeed();

        if (speed >= 9f) return 4f;
        if (speed >= 6f) return 3f;
        if (speed >= 3f) return 2f;
        return 1f;
    }

    private IEnumerator MeasureTapsPerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            lastTapsPerSecond = Mathf.Round(tapCount * 10f) / 10f;
            tapCount = 0;

            // Update multiplier UI if multiplier > 1
            UpdateMultiplierUI();
        }
    }

    private void UpdateMultiplierUI()
    {
        float multiplier = GetTapMultiplier();
        if (multiplier > 1f && multiplierText != null)
        {
            multiplierText.text = multiplier + "X MULT";
            multiplierText.gameObject.SetActive(true);

            // Hide the multiplier text after 0.8 seconds
            StartCoroutine(HideMultiplierText());
        }
        else if (multiplierText != null)
        {
            multiplierText.gameObject.SetActive(false);
        }
    }

    private IEnumerator HideMultiplierText()
    {
        yield return new WaitForSeconds(0.8f);
        if (multiplierText != null)
            multiplierText.gameObject.SetActive(false);
    }

    public void UpdateScore(float scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"{shipName} Distance: {score:F2}";
        publicScore = score;
    }
}
