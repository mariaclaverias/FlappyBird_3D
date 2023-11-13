using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private ScoreSO score;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.score.ToString();
    }
}
