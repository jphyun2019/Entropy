using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool playing;
    public float force;
    public CameraScr cam;
    public Rigidbody dice;
    public GameObject player;
    public GameObject roulette;
    public GameObject handle1;
    public GameObject handle2;
    public SphereCollider spherecollider;
    public GameObject ball;
    private int handlec1;
    private int handlec2;
    public bool boostready;
    public bool reverse;
    public bool showering;

    public GameObject[] sides;

    public meteor meteor1;
    public meteor meteor2;
    public meteor meteor3;

    private int time1;
    private int time2;
    private int time3;

    public uiscr uiscr;
    
    public int texcount;

    public int boosttimer;

    public GameObject annoyingthing;

    public int lap;
    public ParticleSystem trail;

    public int timer;
    public int timermil;
    public int timersec;
    public int timermin;
    public bool timing;
    public string timerstring;
    public finish fin;


    public int startframes;

    public aiscr[] ai;
    public int finaltime;
    public AudioSource whoo;
    public AudioSource countdown;
    private int winneer = 0;




    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        handlec1 = 0;
        handlec2 = 40;
        boostready = false;
        reverse = false;
        showering = false;
        time1 = 0;
        time2 = 50;
        time3 = 100;
        lap = 1;
        playing = false;
        timer = 0;
        timermil = 0;
        timermin = 0;
        timersec = 0;
        timing = false;
        timerstring = "";
        startframes = 250;
        finaltime = 0;

    }

    // Update is called once per frame


    void FixedUpdate()
    {
        if (timing)
        {
            timermil += 2;
            timer += 2;
            if (timermil == 100)
            {
                timersec++;
                timermil = 0;
            }
            // Converts seconds to minutes
            if (timersec == 60)
            {
                timermin++;
                timersec = 0;
            }

            timerstring = (timermin.ToString() + ":" + ((timersec > 9) ? timersec.ToString() : "0" + timersec.ToString()) + ":" + ((timermil > 9) ? timermil.ToString() : "0" + timermil.ToString()));

            
        }


        if (playing)
        {
            uiscr.board.text = "";
            whoo.volume = dice.velocity.magnitude / 200;
            whoo.pitch = dice.velocity.magnitude / 100;

            uiscr.laper.text = "LAP " + lap;
            // Creates a time string based off time values
            uiscr.timer.text = (timermin.ToString() + ":" + ((timersec > 9) ? timersec.ToString() : "0" + timersec.ToString()) + ":" + ((timermil > 9) ? timermil.ToString() : "0" + timermil.ToString()));

            finaltime = timer;
            if (showering)
            {
                if (time1 < 150)
                {
                    time1++;
                }
                else
                {
                    meteor1.hurl();
                    time1 = 0;
                }



                if (time2 < 150)
                {
                    time2++;
                }
                else
                {
                    meteor2.hurl();
                    time2 = 0;
                }

                if (time3 < 150)
                {
                    time3++;
                }
                else
                {
                    meteor3.hurl();
                    time3 = 0;
                }

            }
            if (texcount == 1)
            {
                uiscr.setText("");
                uiscr.placetext.text = "";
                uiscr.setSide(winneer);

            }
            if (texcount > 0)
            {
                texcount--;

            }

            if ((boosttimer > 0))
            {
                if (boosttimer > 50)
                {
                    annoyingthing.SetActive(true);
                }
                else
                {
                    annoyingthing.SetActive(false);
                }
                boosttimer--;

            }
            else if (boostready)
            {
                boosttimer = 100;
            }



            player.transform.position = dice.transform.position;
            if (!reverse)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    dice.AddForce(player.transform.forward * force);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    player.transform.Rotate(new Vector3(0, -4, 0), Space.World);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    player.transform.Rotate(new Vector3(0, 4, 0), Space.World);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    dice.AddForce(player.transform.forward * -6f);
                }
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (boostready)
                    {
                        dice.AddForce(player.transform.forward * 3000);
                        boostready = false;
                        trail.Play();
                    }
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.S))
                {
                    dice.AddForce(player.transform.forward * force);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    player.transform.Rotate(new Vector3(0, -4, 0), Space.World);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    player.transform.Rotate(new Vector3(0, 4, 0), Space.World);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    dice.AddForce(player.transform.forward * -6f);
                }
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (boostready)
                    {
                        dice.AddForce(player.transform.forward * 3000);
                        boostready = false;
                        trail.Play();
                    }
                }
            }
            roulette.transform.eulerAngles += new Vector3(0, 0, 1f);

            handlec1++;
            handlec2++;

            handle1.transform.rotation = Quaternion.Euler(-90 + 90 * Mathf.Sin((handlec1 % 200f / 200) * 2 * Mathf.PI), 0, -90);
            handle2.transform.rotation = Quaternion.Euler(-90 + 90 * Mathf.Sin((handlec2 % 200f / 200) * 2 * Mathf.PI), 0, -90);



            cam.fov = 50f + (dice.velocity.magnitude) / 2;
        }

        else
        {
            whoo.volume = 0;
            uiscr.laper.text = "";
            if (lap > 2)
            {
                uiscr.board.text = fin.leadstring;
                uiscr.done.SetActive(true);
                uiscr.inpu.SetActive(true);
            }
            startframes--;

            if(startframes == 152|| startframes == 102|| startframes == 52|| startframes == 2)
            {
                if(startframes == 2)
                {
                    countdown.pitch = 1.5f;
                }
                countdown.Play();
            }

            if (startframes > 240)
            {
                uiscr.tex.text = "";
            }
            if (startframes > 180)
            {
                uiscr.tex.text = "Entropy";
            }
            else if (startframes > 150)
            {
                uiscr.tex.text = "";
            }
            else if (startframes > 100)
            {
                uiscr.tex.text = "3";
            }
            else if (startframes > 50)
            {
                uiscr.tex.text = "2";
            }
            else if (startframes > 0)
            {
                uiscr.tex.text = "1";

                if(startframes == 1)
                {
                    timing = true;
                    playing = true;

                    foreach (aiscr a in ai)
                    {
                        a.playing = true;
                    }
                    startframes = 0;
                    uiscr.tex.text = "";

                }

            }



        }
    }
        


    public void check()
    {
        texcount = 150;
        int counter = 1;
        float height = -100;
        int winner = 0;
        foreach(GameObject side in sides)
        {
            if(side.transform.position.y > height)
            {
                height = side.transform.position.y;
                winner = counter;
            }
            counter++;
        }


        switch (winner)
        {
            case 1:
                reverse = true;

                break;
            case 2:
                spherecollider.radius = 1.7f;
                ball.SetActive(true);
                force = 16.5f;
                break;
            case 3:
                Time.timeScale = 1.6f;
                force = 16.5f;
                break;
            case 4:
                boostready = true;
                break;

            case 5:
                showering = true;
                break;
            case 6:
                dice.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
                break;


        }


        uiscr.setFace(winner - 1);

        winneer = winner - 1;




    }
    public void precheck()
    {
        dice.transform.localScale = new Vector3(1,1,1);
        spherecollider.radius = 1.3f;
        ball.SetActive(false);
        boostready = false;
        reverse = false;
        Time.timeScale = 1;
        showering = false;
        force = 16f;
    }
    






}
