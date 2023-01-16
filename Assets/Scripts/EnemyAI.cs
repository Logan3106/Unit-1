using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> points;

    public int nextID = 0;

    int idChangeValue = 1;

    public float speed = 0.6f;
    private void Reset()
    {
        Init();
    }

    void Init() { }

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //Get the next point transform
        Transform goalPoint =  points[nextID];
        //Flip the enemy transform to look into the points direction
        if(goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position,goalPoint.position,speed*Time.deltaTime);
        // Check the distance between the enemy and goal point to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position)<0.5f)
        {
            if(nextID == points.Count - 1)
            {
                idChangeValue =  - 1;
            }

            if (nextID == 0)
            {
                idChangeValue = 1;
            }

            nextID += idChangeValue;
        }
    }
}
