using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarming : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isIntruderInside = false;
    private Coroutine _currentCoroutine = null;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void ChangeAlarmMode()
    {
        _isIntruderInside = !_isIntruderInside;

        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        int minVolume = 0;
        int maxVolume = 1;
        float changeStep = 0.2f;
        int finishVolume;

        if (_isIntruderInside == true)
            finishVolume = maxVolume;
        else
            finishVolume = minVolume;

        while (_audioSource.volume != finishVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, finishVolume, changeStep * Time.deltaTime);

            if (_audioSource.volume == minVolume)
                _audioSource.loop = false;
            else
                _audioSource.loop = true;

            yield return null;
        }
    }
}
