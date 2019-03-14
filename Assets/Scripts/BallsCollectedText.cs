using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gets event from Ball Counter and updates the corresponding UI text.
/// </summary>
public class BallsCollectedText : MonoBehaviour
{

    public Text TextToUpdate;

    private void OnEnable()
    {
        BallCounter.OnBallCounterUpdated += UpdateText;
    }

    private void OnDisable()
    {
        BallCounter.OnBallCounterUpdated += UpdateText;
    }

    private void UpdateText(int count)
    {
        TextToUpdate.text = $"Balls Collected: {count}";
    }
}
