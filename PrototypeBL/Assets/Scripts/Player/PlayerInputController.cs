using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public delegate void Move1Action(Vector2 moveVector);
    public static event Move1Action OnMove1;

    public delegate void Move2Action(Vector2 moveVector);
    public static event Move2Action OnMove2;

    private PlayerInput _playerInput;

    private InputAction _move1Action;
    private InputAction _move2Action;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        SetPlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMove1();
        CheckMove2();
    }

    private void CheckMove1() {
        Vector2 moveVector = _move1Action.ReadValue<Vector2>();
        if (OnMove1 != null) OnMove1(moveVector);
    }

    private void CheckMove2() {
        Vector2 moveVector = _move2Action.ReadValue<Vector2>();
        if (OnMove2 != null) OnMove2(moveVector);
    }

    private void SetPlayerInput() {
        _move1Action = _playerInput.actions["Move1"];
        _move2Action = _playerInput.actions["Move2"];
    }

}
