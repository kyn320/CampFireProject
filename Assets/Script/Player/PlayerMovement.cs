using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 플레이어를 움직이는 클래스
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float stamina = 200f;

    public bool isInputed = true, isMoved = true, isWalled = true, isGrounded = false, isGravity = false;

    public int currentJumpCnt = 0, maxJumpCnt = 2;
    public float moveSpeed, JumpPower;

    public float h, groundCheckDelayTime = 0.2f;
    public float distToGround = 0, wallDist = 0.7f;

    private Rigidbody ri;
    private Transform tr;
    private Collider col;

    public Vector2 pos;

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
            Slope();
        }
        //그라운드 체크
        if (isGravity)
        {
            GroundCheck();
        }
    }

    void Move()
    {
        Vector2 movePos = ri.velocity;
        movePos.x = h * moveSpeed;
        ri.velocity = movePos;
    }

    void Jump()
    {
        StartCoroutine("GroundCheckDelay");
        ++currentJumpCnt;
        ri.velocity = new Vector2(ri.velocity.x, JumpPower);
    }
    
    void GroundCheck()
    {
        isGrounded = Physics.Raycast(tr.position, -Vector3.up, distToGround + 0.1f, LayerMask.GetMask("Ground"));
        ri.useGravity = !isGrounded;
        if (isGrounded)
        {
            currentJumpCnt = 0;
        }
    }

    void Slope()
    {
        RaycastHit hit;
        Physics.Raycast(tr.position, -Vector3.up, out hit, distToGround + 0.5f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(tr.position, -Vector3.up * (distToGround + 0.5f), Color.red);

        if (isGravity && Mathf.Abs(h) > 0 && hit.collider != null && Mathf.Abs(hit.normal.x) > 0)
        {
            ri.velocity = new Vector2(ri.velocity.x, ri.velocity.y - Mathf.Abs(hit.normal.x));
        }
    }

    IEnumerator GroundCheckDelay()
    {
        isGravity = false;
        ri.useGravity = true;
        yield return new WaitForSeconds(groundCheckDelayTime);
        isGravity = true;
    }
}
