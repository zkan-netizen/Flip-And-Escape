using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;

    Vector3 AnimModes;

    public Animator ControllerAnim;

    [SerializeField]
    private bool _isDead;

    [SerializeField]
    private Vector3 _forward;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private bool SlideMode;

    private int _desiredLane = 1;

    private float LaneDistance = 3.5f;

    [SerializeField]
    private float JumpForce;

    private float Gravity = -20;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void RightLeft()
    {
        if (_isDead == false && SlideMode != true)
        {
            if (SwipeManager.swipeRight)
            {
                _desiredLane++;
                if (_desiredLane == 3) _desiredLane = 2;
            }
            if (SwipeManager.swipeLeft)
            {
                _desiredLane--;
                if (_desiredLane == -1) _desiredLane = 0;
            }
            Vector3 TargetPosition =
                (transform.position.z * transform.forward) +
                (transform.position.y * transform.up);
            if (_desiredLane == 0)
            {
                TargetPosition += Vector3.left * LaneDistance;
            }
            else if (_desiredLane == 2)
            {
                TargetPosition += Vector3.right * LaneDistance;
            }
            if (transform.position != TargetPosition)
            {
                Vector3 diff = TargetPosition - transform.position;
                Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
                if (moveDir.sqrMagnitude < diff.magnitude)
                    _controller.Move(moveDir);
                else
                    _controller.Move(diff);
            }
        }
    }

    private void Forward()
    {
        _forward.z = Speed;
        if (GameManager._gamemanager.isGameStart && _isDead == false)
        {
            // ControllerAnim.SetBool("isGameStart", true);
            _controller.Move(_forward * Time.deltaTime);
            ControllerAnim.SetBool("isGameStart", true);
        }

        // _controller.center = _controller.center;
    }

    private void Jump()
    {
        if (_isDead == false && SlideMode == false)
        {
            if (_controller.isGrounded || transform.position.y < 1)
            {
                _controller.height = 1.5f;
                ControllerAnim.SetBool("Twist", false);
                if (SwipeManager.swipeUp)
                {
                    _forward.y = JumpForce;
                    ControllerAnim.SetBool("Twist", true);

                    Debug.Log("zıpla");
                }
            }
            else
            {
                _forward.y += Gravity * Time.deltaTime;
                _controller.height = .5f;
            }
        }
    }

    private IEnumerator _slide()
    {
        SlideMode = true;
        ControllerAnim.SetBool("Slide", true);
        transform.position =
            new Vector3(transform.position.x, 0.03f, transform.position.z);
        _controller.height = 0.4f;

        Speed = 13.5f;
        yield return new WaitForSeconds(.7f);
        ControllerAnim.SetBool("Slide", false);

        Speed = 8;
        SlideMode = false;
    }

    private void Slide()
    {
        if (
            SwipeManager.swipeDown &&
            _isDead == false &&
            transform.position.y < 1
        )
        {
            StartCoroutine(_slide());
        }
    }

    // Obstacle Hit Conditions
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle")
        {
            GameManager._gamemanager.GameOverTimer();
            _isDead = true;
            transform.position =
                new Vector3(transform.position.x, .6f, transform.position.z);
            ControllerAnim.SetBool("Dead", true);
        }
        if (hit.gameObject.tag == "Finish")
        {
            transform.position = new Vector3(0, 1, transform.position.z);
            _isDead = true;
            ControllerAnim.SetBool("FinishMode", true);
            GameManager._gamemanager.SenseiCanStart = true;
            GameManager._gamemanager.CallNextLevelUI();
        }
        // if (hit.gameObject.tag == "Gold")
        // {
        //     hit.collider.isTrigger=true;
        //     GameManager._gamemanager.ScorePoint();
        //     hit.gameObject.SetActive(false);
        // }
    }

    private void Update()
    {
        // if (SlideMode == true)
        // {
        // transform.position =
        //     new Vector3(transform.position.x, 0.03f, transform.position.z);
        //     _controller.height = 0.5f;
        // }
        // else if(SlideMode!=true && _isDead==false)
        // {
        //     transform.position =
        //         new Vector3(transform.position.x, 0.6f, transform.position.z);
        //     _controller.height = 1.65f;
        // }
        Slide();
        Jump();
        RightLeft();
    }

    private void FixedUpdate()
    {
        Forward();
    }
}
