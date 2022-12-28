using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static PlayerMovement;

public class PlayerController : MonoBehaviour
{

    private void OnEnable() {
        PlayerInputController.OnMove1 += UpdatePlayer1;
        PlayerInputController.OnMove2 += UpdatePlayer2;
    }

    private void OnDisable() {
        PlayerInputController.OnMove1 -= UpdatePlayer1;
        PlayerInputController.OnMove2 -= UpdatePlayer2;
    }

    [SerializeField] private player _player = player.player1;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private int _jumpsAmount;
    private int _jumpsLeft;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private bool _isGrounded;

    private Vector2 _moveVector;
    private Rigidbody2D _rigidBody;
    private float _scaleX;

    public enum player {
        player1,
        player2
    }


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MovePlayer() {
        Flip();
        _rigidBody.velocity = new Vector2(_moveVector.x * _moveSpeed, _rigidBody.velocity.y);
    }

    private void Jump() {
        if (_moveVector.y > 0) {
            CheckIfGrounded();
            if (_jumpsLeft > 0) {
                _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
                _jumpsLeft--;
            }

        }

    }

    private void CheckIfGrounded() {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheck.GetComponent<CircleCollider2D>().radius, _groundLayer);
        ResetJumps();
    }

    private void ResetJumps() {
        if (_isGrounded) {
            _jumpsLeft = _jumpsAmount;
        }
    }

    private void Flip() {
        if (_moveVector.x > 0) {
            transform.localScale = new Vector3(_scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (_moveVector.x < 0) {
            transform.localScale = new Vector3((-1) * _scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void UpdatePlayer1(Vector2 moveVector) {
       if(_player == player.player1) {
            UpdateMoveVector(moveVector);
        }
    }

    private void UpdatePlayer2(Vector2 moveVector) {
        if (_player == player.player2) {
            UpdateMoveVector(moveVector);
        }
    }

    private void UpdateMoveVector(Vector2 moveVector) {
        _moveVector = moveVector;
    }

}
