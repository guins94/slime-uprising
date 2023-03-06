using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSlime : Creature
{
    private Vector2 playerMovement = Vector2.zero;

    protected override void OnDeath()
    {

    }

    protected override void Move()
    {
        //animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed));
        transform.Translate(playerMovement * Time.deltaTime, Space.Self);
        Animator.SetFloat("Speed", Mathf.Abs(playerMovement.magnitude));
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        Debug.Log("Player move " + context.ReadValue<Vector2>().y);
        playerMovement = new Vector2(context.ReadValue<Vector2>().x * movementSpeed, context.ReadValue<Vector2>().y * movementSpeed);

        if (context.ReadValue<Vector2>().x <=0 ) SpriteRenderer.flipX = true;
        else SpriteRenderer.flipX = false;
        
    }

    private void StopPlayer(InputAction.CallbackContext context)
    {
        playerMovement = new Vector2(0, 0);
    }

    /// <summary>
    /// Enable the input system
    /// </summary>
    void Awake()
    {
        PlayerControls moveAction = new PlayerControls();
        moveAction.Player.Enable();
        moveAction.Player.Walk.performed += MovePlayer;
        moveAction.Player.Walk.canceled += MovePlayer;
    }

    /// <summary>
    /// Stops to listen for input system
    /// </summary>
    void OnDisable()
    {
        //moveAction.Disable();
    }
}
