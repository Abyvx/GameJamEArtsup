using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Banana : MonoBehaviour, IPointerClickHandler
{
    private Animator _animator;
    private AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!GameManager.instance.playerTurn) return;

        _animator.SetTrigger("OnBananaOpponent");

        GameManager.instance.ChangePlayerTurn();
    }

    public void BananaOpponent()
    {
        FindObjectOfType<OpponentController>().GetComponent<Animator>().SetTrigger("OnBanana");
    }

    public void BananaPlayer()
    {
        FindObjectOfType<PlayerController>().GetComponent<Animator>().SetTrigger("OnBanana");
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
}
