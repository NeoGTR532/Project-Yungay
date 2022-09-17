using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase : StateMachineBehaviour
{
    private PlayerModel playerModel;
    public PlayerModel GetPlayerModel(Animator animator)

    {
        if(playerModel == null)
        {
            playerModel = animator.GetComponent<PlayerModel>();
        }

        return playerModel;
    }
}
