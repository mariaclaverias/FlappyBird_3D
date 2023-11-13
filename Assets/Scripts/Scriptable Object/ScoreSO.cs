using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObject/Data/Score", order = 0)]
public class ScoreSO : ScriptableObject
{
    [SerializeField]
    private int _score;
    [SerializeField]
    private int _highScore;
    public int score => _score;

    public void UpdateScore()
    {
        _score++;
    }

    public void HighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
        }
    }
}
