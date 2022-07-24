using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiscr : MonoBehaviour
{
    public Player player;
    public Rigidbody dice;
    public GameObject[] points;
    public int goalcount;
    public GameObject goal;
    public Vector3 difference;
    public Vector3 direction;
    public float force;
    public ArrayList store = new ArrayList();
    public int lap;
    public bool obvnotcheating;
    public bool playing;
    public string color;



    // Start is called before the first frame update
    void Start()
    {
        goalcount = 0;
        goal = points[goalcount];
        lap = 1;
        obvnotcheating = false;
        playing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playing)
        {
            difference = goal.transform.position - transform.position;
            if (difference.magnitude > 25)
            {
                direction = difference / difference.magnitude;
                dice.AddForce(direction * force);
            }
            else
            {
                if (goalcount == points.Length - 1)
                {
                    goalcount = 0;
                    goal = points[goalcount];
                }
                else
                {

                    goalcount++;
                    goal = points[goalcount];
                }

            }

            store.Add(dice.velocity.magnitude);

            if (store.Count == 600)
            {
                float counter = 0;
                foreach (float f in store)
                {
                    counter += f;
                }

                store.RemoveAt(0);
                if ((counter / 600) < 10)
                {
                    dice.transform.position = points[goalcount - 1].transform.position;
                    store.Clear();
                }
            }
        }
        





    }
}
