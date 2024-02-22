using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeChangeSpeed = 0.5f;
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;
    private bool _isAlarmOn;

    private Coroutine _alarmSound; 

    private IEnumerator ChangeVolume(float targetVolume)
    {
        TurnSoundOn();

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);

            yield return null;
        }

        TurnSoundOff();
    }

    private void TurnSoundOn()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }
    }

    private void TurnSoundOff()
    {
        if (_audioSource.volume == _minVolume)
        {
            _audioSource.Stop();
        }
    }

    public void SetAlarmOn()
    {
        if (_alarmSound != null)
        {
            StopCoroutine(_alarmSound);
        }

        _alarmSound = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void SetAlarmOff()
    {
        if (_alarmSound != null)
        {
            StopCoroutine(_alarmSound);
        }

        _alarmSound = StartCoroutine(ChangeVolume(_minVolume));
    }
}