using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Unity.Mathematics;
using UnityEngine;


public class Game : MonoBehaviour
{
private Animator animator;
public bool playerAction = false;
int AiVie = 3; //si vie de l'enemie = 0 joueur gagne
int PlayerVie = 4;


void Update()
{
    if(playerAction == true )
    {
        StartCoroutine(Wait());
        playerAction = false;
    }
}
IEnumerator Wait()
{
//Debug.Log("entre coroutine");
yield return new WaitForSeconds(2);
AiPlaying();
//Debug.Log("exit coroutine");
}

public void PlayerAction()
{
playerAction = true;
}

void AiPlaying()
{
Debug.Log("Enemie playing");
}
    // void animationPlaying()
    // {
    //     switch (AiVie)
    //     {
    //         case 3:
    //             animator.SetTrigger(animationVie3);
    //             break;
    //         case 2:
    //             animator.SetTrigger(animationVie2);
    //             break;
    //         case 1:
    //             animator.SetTrigger(animationVie1);
    //             break;
    //         case 0:
    //             animator.SetTrigger(animationVie0);
    //             break;
    //     }
    // }
}
