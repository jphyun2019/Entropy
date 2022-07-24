using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{


    public Collider dice;
    public CameraScr cam;
    public float checking;
    public Collider point;

    public bool hit1;
    public bool hit2;
    public bool hit3;


    public Player player;

    public ArrayList rank1 = new ArrayList();
    public ArrayList rank2 = new ArrayList();
    public ArrayList rank3 = new ArrayList();

    public uiscr ui;

    // Start is called before the first frame update
    void Start()
    {
        checking = 0;
        hit1 = false;
        hit2 = false;
        hit3 = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (checking == 1)
        {

            if (Time.timeScale < 1)
            {
                Time.timeScale = 1;
            }

            checking--;
            cam.unCheck();


        }
        if (checking == 40)
        {
            player.check();

        }
        if (checking > 25)
        {

            checking--;
            cam.check();

        }
        else
        {
            checking--;

        }
    }
        

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dice"))
        {
            if(((player.lap == 1)&&!hit1)|| ((player.lap == 2) && !hit2)|| ((player.lap == 3) && !hit3))
            {
                checking = 60;

                player.precheck();
                Time.timeScale = 0.2f;

                switch (player.lap)
                {
                    case 1:
                        hit1 = true;
                        ui.placeholder = rank1.Count + 1;
                        break;
                    case 2:
                        hit2 = true;
                        ui.placeholder = rank2.Count + 1;
                        break;
                    case 3:
                        hit3 = true;
                        ui.placeholder = rank3.Count + 1;
                        break;
                }


            }            
        }

        if (other.CompareTag("enemy"))
        {
            aiscr e = other.GetComponent<aiscr>();

            switch (e.lap)
            {
                case 1:
                    if (!rank1.Contains(e))
                    {
                        rank1.Add(e);
                    }
                    break;
                case 2:
                    if (!rank2.Contains(e))
                    {
                        rank2.Add(e);
                    }
                    break;
                case 3:
                    if (!rank3.Contains(e))
                    {
                        rank3.Add(e);
                    }
                    break;
            }
            e.obvnotcheating = true;
        }
    }

}
