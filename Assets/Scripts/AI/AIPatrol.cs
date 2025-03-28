using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public Node CurrentNode;
    public List<Node> path = new List<Node>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CreatePath();
    }

    public void CreatePath()
    {
        if (path.Count > 0)
        {
            int x = 0;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(path[x].transform.position.y, -2),
                3 * Time.deltaTime);
            if (Vector2.Distance(transform.position, path[x].transform.position) < 0.1f)
            {
                CurrentNode = path[x];
                path.RemoveAt(x);
            }
            else
            {
                //Node[] nodes = FindObjectsOfType<Node>();
                while (path==null||path.Count==0)
                {
                    //path=AStarManager.
                }
            }
        }
    }
}