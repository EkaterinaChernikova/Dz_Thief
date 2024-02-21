using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeChangeSpeed = 0.5f;
    [SerializeField] private AudioSource _audioSource;

    private bool _isVolumeUp;
    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;
    private float _targetVolume;

    private IEnumerator ChangeVolume()
    {
        TurnSoundOnOff();

        do
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChangeSpeed * Time.deltaTime);

            yield return null;
        }
        while (_audioSource.volume < _maxVolume && _audioSource.volume > _minVolume);

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

    public void StartAlarm()
    {
        _isVolumeUp = !_isVolumeUp;
        _targetVolume = _isVolumeUp ? _maxVolume : _minVolume;
        StartCoroutine(ChangeVolume());
    }
}