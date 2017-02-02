using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 플레이어를 움직이는 클래스
/// </summary>
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour
{

    public bool isInputed = true, isMoved = true, isGrounded = false;

    public int currentJumpCnt = 0, maxJumpCnt = 2;
    public float moveSpeed, JumpPower;
    public float gravity = 20.0F;

    public float h;
    public float distToGround = 0;

    private float moveVelocity = 0;
    private Rigidbody ri;
    private Transform tr;
    private Collider col;

    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        //컴포넌트를 캐싱한다.
        ri = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        col = GetComponent<CapsuleCollider>();
    }

    // Use this for initialization
    void Start()
    {
        //충돌체의 높이를 구한다.
        distToGround = col.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        //조작 가능한 경우?
        if (isInputed)
        {
            //좌우 입력 값
            h = Input.GetAxis("Horizontal");

            //그라운드 체크
            isGrounded = GroundCheck();

            //점프 입력
            if (Input.GetKeyDown(KeyCode.Space) && currentJumpCnt < maxJumpCnt - 1)
            {
                Jump();
            }
        }
        //공중인 경우
        if (!isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;
        else if (currentJumpCnt == 0) {
            moveDirection = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        //움직일 수 있는 경우?
        if (isMoved)
        {
            Move();

            //점프를 한 상태에서 땅에 착지하였는가
            if (isGrounded)
            {
                currentJumpCnt = 0;
            }
        }
        tr.position += moveDirection * Time.deltaTime;
    }

    void Move()
    {
        ri.velocity = new Vector2(h * moveSpeed, ri.velocity.y);
    }

    void Jump()
    {
        ++currentJumpCnt;
        moveDirection.y = JumpPower;
        isGrounded = false;
    }

    /// <summary>
    /// 땅에 착지 하고 있는지 체크
    /// </summary>
    /// <returns>땅에 닿으면 True, 아니면 False</returns>
    bool GroundCheck()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.01f);
    }
}
