using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private int _life = 4;

    public int Life
    {
        get
        {
            return _life;
        }
        set
        {
            _life = value;

            if (_life <= 0)
            {
                GameManager.instance.PlayerDefeat();
            }
        }
    }
}
