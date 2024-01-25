using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slap : MonoBehaviour, IPointerClickHandler
{
    private Animator _slapAnimator;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;

    private void Start()
    {
        _slapAnimator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!GameManager.instance.playerTurn) return;

        _slapAnimator.SetTrigger("DoSlap");

        GameManager.instance.ChangePlayerTurn();
    }

    public void SlapOpponent()
    {
        FindObjectOfType<OpponentController>().GetComponent<Animator>().SetTrigger("OnSlapped");

        _audioSource.Play();
    }

    public void SlapPlayer()
    {
        _audioSource.Play();
    }
}
