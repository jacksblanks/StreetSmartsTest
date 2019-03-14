using UnityEngine;
using UnityEngine.UI;

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
