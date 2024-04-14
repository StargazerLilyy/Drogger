using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform movePoint;

    public Animator animator;

    public GameManager gameManager;

    public bool[] goals;
    public int goalsScored;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        movePoint.position = transform.position;
        goals = new bool[5];
        goalsScored = 0;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MovementSpeed", Vector3.Distance(transform.position, movePoint.position));
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }

        if (movePoint.position.x < -12f) { movePoint.position += new Vector3(1f, 0f, 0f); }
        if (movePoint.position.x > 12f) { movePoint.position += new Vector3(-1f, 0f, 0f); }
        if (movePoint.position.y < -7.1f) { movePoint.position += new Vector3(0f, 1f, 0f); }
        if (movePoint.position.y > 5.1f) { CheckIfGoal(); }
    }

    private void CheckIfGoal()
    {
        if (IsBetween(transform.position.x, -11, -9))
        {
            if (!goals[0])
            {
                goals[0] = true;
                goalsScored++;
                PlayerScored(0);
            }
        }
        if (IsBetween(transform.position.x, -6, -4))
        {
            if (!goals[1])
            {
                goals[1] = true;
                goalsScored++;
                PlayerScored(1);
            }
        }
        if (IsBetween(transform.position.x, -1, 1))
        {
            if (!goals[2])
            {
                goals[2] = true;
                goalsScored++;
                PlayerScored(2);
            }
        }
        if (IsBetween(transform.position.x, 4, 6))
        {
            if (!goals[3])
            {
                goals[3] = true;
                goalsScored++;
                PlayerScored(3);
            }
        }
        if (IsBetween(transform.position.x, 9, 11))
        {
            if (!goals[4])
            {
                goals[4] = true;
                goalsScored++;
                PlayerScored(4);
            }
        }
    }

    private bool IsBetween(float val, float min, float max)
    {
        if (val >= min && val <= max)
        {
            return true;
        }
        return false;
    }

    private void PlayerScored(int lillyPadNum)
    {
        gameManager.GoalScored(lillyPadNum);

        if (goalsScored == 5)
        {
            //TODO:Trigger Level Complete!
        }
    }
}
