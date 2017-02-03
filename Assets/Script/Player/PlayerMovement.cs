using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 플레이어를 움직이는 클래스
/// </summary>
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour
{

    public bool isInputed = true, isMoved = true, isGrounded = false, isGravity = false;

    public int currentJumpCnt = 0, maxJumpCnt = 2;
    public float moveSpeed, JumpPower, moveClamp = 20f;

    public float h, groundCheckDelayTime = 0.2f;
    public float distToGround = 0;
    
    private Rigidbody ri;
    private Transform tr;
    private Collider col;

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

            //점프 입력
            if (Input.GetKeyDown(KeyCode.Space) && currentJumpCnt < maxJumpCnt)
            {
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        //움직일 수 있는 경우?
        if (isMoved)
        {
            Move();
        }
        //그라운드 체크
        if (ri.useGravity && isGravity) {
            GroundCheck();
        }
    }

    void Move()
    {
        tr.position = Vector3.Lerp(tr.position,tr.position + Vector3.right * moveSpeed * h, Time.deltaTime * moveClamp);
    }
    
    void Jump()
    {
        StartCoroutine("GroundCheckDelay");
        ++currentJumpCnt;
        ri.velocity = new Vector2(ri.velocity.x,JumpPower);
    }

    /// <summary>
    /// 땅에 착지 하고 있는지 체크
    /// </summary>
    /// <returns>땅에 닿으면 True, 아니면 False</returns>
    void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.05f);
        if (isGrounded)
            currentJumpCnt = 0;
    }

    IEnumerator GroundCheckDelay() {
        isGravity = false;
        yield return new WaitForSeconds(groundCheckDelayTime);
        isGravity = true;
    }
}
