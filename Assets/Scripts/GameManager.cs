using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _time = 15f;
    [SerializeField] private float _timeBonus = 5f;
    [SerializeField] uint _maxScore = 10;

    private float _timeLeft = 0f;
    private int _score = 0;
    private void Awake()
    {
        Time.timeScale = 1;
        GlobalEventManager.OnCoinTake.AddListener(IncreaseScore);
    }
    private void Start()
    {
        _timeLeft = _time;
        UpdateTime();
        StartCoroutine(StartTimer());
    }
    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTime();
            yield return null;
        }
        if(_score < _maxScore)
        {
            GlobalEventManager.SendLose();
            Time.timeScale = 0;
        }
    }
    private void UpdateTime()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        int seconds = Mathf.FloorToInt(_timeLeft % 60);
        int milliseconds = Mathf.FloorToInt((_timeLeft * 1000) - (seconds*1000));
        GlobalEventManager.SendTimeChanged(seconds, milliseconds);
    }
    private void GetBonusTime()
    {
        _timeLeft += _timeBonus;
        if (_timeLeft > _time)
        {
            _timeLeft = _time;
        }
        UpdateTime();
    }
    private void IncreaseScore()
    {
        _score++;
        GlobalEventManager.SendScoreChanged(_score);

        GetBonusTime();

        if (_score == _maxScore)
        {
            GlobalEventManager.SendWin();
            Time.timeScale = 0;
        }
    }
    public static void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
