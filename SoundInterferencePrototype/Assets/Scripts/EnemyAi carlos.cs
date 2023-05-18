using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAicarlos : MonoBehaviour
{
    public Transform player;
    public List<Transform> points;
    public int nextId;
    private int idChangeValue = 1;
    public float speed = 2;

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, player.position) < 5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2 (player.position.x, transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            MoveToNextPoint();
        }
    }
    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextId];

        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, player.position) < 1f)
        {
            if(nextId == points.Count - 1)
            {
                idChangeValue = -1;
            }
            if(nextId == 0)
            {
                idChangeValue = 1;
            }
            nextId += idChangeValue;
        }
    }
}
