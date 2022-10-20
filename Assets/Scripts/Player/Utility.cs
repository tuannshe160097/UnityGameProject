using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    [HideInInspector]
    public float MoveDirection;

    [HideInInspector]
    public bool IsFacingRight;

    [HideInInspector]
    public bool CanMove;

    [HideInInspector]
    public bool CanAttack;

    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private Transform _wallLeftCheck;
    [SerializeField]
    private Transform _wallRightCheck;

    // Start is called before the first frame update
    void Start()
    {
        MoveDirection = 0;
        IsFacingRight = true;
        CanMove = true;
        CanAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveDirection != 0)
        {
            transform.localScale = new Vector3(MoveDirection, transform.localScale.y, transform.localScale.z);
            IsFacingRight = MoveDirection > 0;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    public bool IsWallLeft()
    {
        return Physics2D.OverlapCircle(_wallLeftCheck.position, 0.1f, _groundLayer);
    }

    public bool IsWallRight()
    {
        return Physics2D.OverlapCircle(_wallRightCheck.position, 0.1f, _groundLayer);
    }

    public bool IsWall()
    {
        return IsWallLeft() || IsWallRight();
    }

    public bool MovementResetable()
    {
        return IsGrounded() || IsWallLeft() || IsWallRight();
    }

    public void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public int DirectionModifier()
    {
        return IsFacingRight ? 1 : -1;
    }
}
