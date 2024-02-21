using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeChangeSpeed = 0.5f;
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;
    private float _targetVolume;

    private Coroutine _alarmSound; 

    private IEnumerator ChangeVolume(float targetVolume)
    {
        TurnSoundOnOff();

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);

            yield return null;
        }

        TurnSoundOnOff();
    }

    private void TurnSoundOnOff()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }
        else if (_audioSource.volume == _minVolume)
        {
            _audioSource.Stop();
        }
    }

    public void SetAlarm(bool isOn)
    {
        _targetVolume = isOn ? _maxVolume : _minVolume;

        if (_alarmSound != null)
        {
            StopCoroutine(_alarmSound);
        }

        _alarmSound = StartCoroutine(ChangeVolume(_targetVolume));
    }
}