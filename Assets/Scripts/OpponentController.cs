using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public IdentityCard identityCard;

    [SerializeField] private AudioClip _laughingExtremelyClip;
    [SerializeField] private AudioClip _laughingSlightlyClip;

    private List<Action> _foundActions = new();

    private OpponentLife _opponentLife;
    private Animator _animator;
    private AudioSource _audioSource;

    private void Awake()
    {
        _opponentLife = GetComponent<OpponentLife>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public bool CheckIdentityCard(Action action)
    {
        if (identityCard.funnyActions.Contains(action) && !_foundActions.Contains(action))
        {
            _foundActions.Add(action);

            _opponentLife.Life--;
            Debug.Log(_opponentLife.Life);

            _animator.SetTrigger("OnLaughingSlightly");

            _audioSource.clip = _laughingSlightlyClip;
            _audioSource.Play();

            return true;
        }

        return false;
    }

    public void ChoseObject()
    {
        Action action;

        // int randomInt = Random.Range(0, System.Enum.GetValues(typeof(Action)).Length);
        // action = (Action)randomInt;

        action = Action.Horn;

        print(action);

        if (action == Action.Horn)
        {
            FindObjectOfType<Horn>().GetComponent<Animator>().SetTrigger("OnHornPlayer");
            _animator.SetTrigger("OnTakingHorn");
        }
        else if (action == Action.Slap)
        {
            FindObjectOfType<Slap>().GetComponent<Animator>().SetTrigger("OnSlapPlayer");
            _animator.SetTrigger("OnSlapping");
        }
        else
        {
            _animator.SetTrigger("OnTakingObject");
        }
    }

    public void ChangePlayerTurn()
    {
        GameManager.instance.ChangePlayerTurn();
    }

    public void CheckDefeated()
    {
        if (_opponentLife.Life <= 0)
        {
            _animator.SetTrigger("OnLaughingExtremely");

            _audioSource.clip = _laughingExtremelyClip;
            _audioSource.Play();
        }
    }

    public void ActivateGameObjects()
    {
        FindObjectOfType<Slap>().gameObject.SetActive(true);
    }
}
