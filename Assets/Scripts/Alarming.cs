using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarming : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isIntruderInside = false;
    private IEnumerator _currentCoroutine = null;

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

        _currentCoroutine = ChangeVolume();
        
        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator ChangeVolume()
    {      
        float changeStep = 0.2f * Time.deltaTime;
        int finishVolume;

        if (_isIntruderInside == true)
            finishVolume = 1;
        else
            finishVolume = 0;

        while (_audioSource.volume != finishVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, finishVolume, changeStep);

            if (_audioSource.volume == 0)
                _audioSource.loop = false;
            else
                _audioSource.loop = true;

            yield return null;
        }
    }
}
