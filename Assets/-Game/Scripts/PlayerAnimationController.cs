using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    private Player player;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        player = GetComponent<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        HandleAnimations();
        HandleAttack();
        HandleDeath();
    }

    private void HandleAnimations()
    {
        Vector2 lastDirection = playerController.lastDirection;
        animator.SetFloat("moveX", lastDirection.x);
        animator.SetFloat("moveY", lastDirection.y);
        animator.SetBool("isMove", playerController.direction != Vector2.zero);
    }

    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            animator.SetBool("isAttack", true);
        }
        else if (Input.GetMouseButtonUp(0)) // 0 is the left mouse button
        {
            animator.SetBool("isAttack", false);
        }
    }

    private void HandleDeath()
    {
        if (player.health <= 0)
        {
            animator.SetBool("isDead", true);
        }
    }
}
