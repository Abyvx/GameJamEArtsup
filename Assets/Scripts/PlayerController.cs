using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip _laughingExtremelyClip;
    [SerializeField] private AudioClip _laughingSlightlyClip;

    private List<Action> _foundActions = new();

    public IdentityCard identityCard;

    private PlayerLife _playerLife;
    private Animator _animator;
    private AudioSource _audioSource;

    private void Awake()
    {
        _playerLife = GetComponent<PlayerLife>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public bool CheckIdentityCard(Action action)
    {
        if (identityCard.funnyActions.Contains(action)/* && !_foundActions.Contains(action)*/)
        {
            _foundActions.Add(action);

            _playerLife.Life--;
            Debug.Log(_playerLife.Life);

            _animator.SetTrigger("OnLaughingSlightly");

            _audioSource.clip = _laughingSlightlyClip;
            _audioSource.Play();

            return true;
        }

        return false;
    }

    public void CheckDefeated()
    {
        if (_playerLife.Life <= 0)
        {
            _animator.SetTrigger("OnLaughingExtremely");

            _audioSource.clip = _laughingExtremelyClip;
            _audioSource.Play();
        }
    }
}
