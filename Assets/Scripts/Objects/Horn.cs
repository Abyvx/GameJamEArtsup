using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Horn : MonoBehaviour, IPointerClickHandler
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

        _animator.SetTrigger("OnHornOpponent");

        GameManager.instance.ChangePlayerTurn();
    }

    public void HornOpponent()
    {
        FindObjectOfType<OpponentController>().GetComponent<Animator>().SetTrigger("OnHorned");

        _audioSource.Play();
    }

    public void HornPlayer()
    {
        FindObjectOfType<PlayerController>().GetComponent<Animator>().SetTrigger("OnHorned");

        _audioSource.Play();
    }
}
