using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clean
{
    public class OpponentLife : MonoBehaviour
    {
        private int _life = 3;
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
                    Clean.GameManager.instance.PlayerVictory();
                }
            }
        }
    }
}
