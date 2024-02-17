using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeChangeSpeed = 0.5f;
    [SerializeField] private AudioSource _audioSource;

    private bool _isVolumeUp;

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Movement>(out Movement component) == true)
        {
            StartAlarm();
        }
    }

    private IEnumerator ChangeVolume()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        do
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 
                _isVolumeUp ? _audioSource.maxDistance : 0, 
                _volumeChangeSpeed * Time.deltaTime);

            yield return null;
        }
        while (_audioSource.volume < _audioSource.maxDistance && _audioSource.volume > 0);

        if(_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }

    }

    public void StartAlarm()
    {
        Debug.Log("ALARM");
        _isVolumeUp = !_isVolumeUp;
        StartCoroutine(ChangeVolume());
    }
}