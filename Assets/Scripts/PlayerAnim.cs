using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    private void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    private void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            } else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1);
        }
        else if (player.direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1);
        }
    }

    private void OnRun()
    {
        if(player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion  
}
