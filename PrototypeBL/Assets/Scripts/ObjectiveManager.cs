using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveManager : MonoBehaviour
{
    public UnityEvent OnObjectiveComplete;

    private bool _player1Finished = false;
    private bool _player2Finished = false;

    void Update()
    {
        if(_player1Finished && _player2Finished) {
            _player1Finished = false;
            _player2Finished = false;
            OnObjectiveComplete?.Invoke();
        }
    }

    public void UpdatePlayer1(bool finished) {
        _player1Finished = finished;
    }

    public void UpdatePlayer2(bool finished) {
        _player2Finished = finished;
    }

}
