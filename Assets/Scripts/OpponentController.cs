using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public IdentityCard identityCard;

    [SerializeField] private Sprite _madSprite;
    [SerializeField] private Sprite _slappedSprite;
    [SerializeField] private Sprite _laughingSlightlySprite;
    [SerializeField] private Sprite _reflectingSprite;
    [SerializeField] private Sprite _takingObjectSprite;

    private SpriteRenderer _spriteRenderer;

    private OpponentLife _opponentLife;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _opponentLife = GetComponent<OpponentLife>();
    }

    public IEnumerator Slap()
    {
        _spriteRenderer.sprite = _slappedSprite;

        yield return new WaitForSeconds(2f);

        if (CheckIdentityCard(Action.Slap))
        {
            _spriteRenderer.sprite = _laughingSlightlySprite;
        }
        else
        {
            _spriteRenderer.sprite = _madSprite;
        }

        yield return new WaitForSeconds(3f);

        _spriteRenderer.sprite = _reflectingSprite;

        yield return new WaitForSeconds(2f);

        _spriteRenderer.sprite = _takingObjectSprite;





        yield return new WaitForSeconds(2f);

        GameManager.instance.ChangePlayerTurn();
    }

    public bool CheckIdentityCard(Action action)
    {
        if (identityCard.funnyActions.Contains(action))
        {
            _opponentLife.Life--;
            Debug.Log(_opponentLife.Life);

            return true;
        }

        return false;
    }
}
