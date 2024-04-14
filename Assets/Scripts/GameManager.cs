using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DroneController droneController;
    public GameObject froogy_Scored;

    public void GoalScored(int goalNum)
    {
        float xPos = -10 + goalNum * 5;
        Instantiate(froogy_Scored, new Vector3(xPos, 5, 0), Quaternion.identity);
    }
}
