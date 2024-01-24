using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slap : MonoBehaviour, IPointerClickHandler
{
    private Animator _slapAnimator;

    private void Start()
    {
        _slapAnimator = GetComponent<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _slapAnimator.SetTrigger("DoSlap");
    }
}
