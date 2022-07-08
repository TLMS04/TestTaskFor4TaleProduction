using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] GameObject _panelResult;
    [SerializeField] TextMeshProUGUI _resultText;
    [SerializeField] Button _retryButton;
    private void Awake()
    {
        _retryButton.onClick.AddListener(Retry);
        GlobalEventManager.OnScoreChanged.AddListener(ScoreTextSet);
        GlobalEventManager.OnTimeChanged.AddListener(TimeTextSet);
        GlobalEventManager.OnWin.AddListener(ShowWinPanel);
        GlobalEventManager.OnLose.AddListener(ShowLosePanel);
    }

    private void ScoreTextSet(int score)
    {
        _scoreText.text = score.ToString();
    }
    private void TimeTextSet(int seconds, int milliseconds)
    {
        _timeText.text = $"{seconds}.{milliseconds}";
    }
    private void ShowWinPanel()
    {
        _panelResult.SetActive(true);
        _resultText.text = "WIN";
    }
    private void ShowLosePanel()
    {
        _panelResult.SetActive(true);
        _resultText.text = "LOSE";
    }
    private void Retry()
    {
        _panelResult.SetActive(false);
        GameManager.Retry();
    }
}
