using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public check[] checks;
    public Player player;
    public int finalplace;
    public uiscr ui;
    public string leadstring = "";


    private void Start()
    {
        finalplace = 1;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dice"))
        {
            bool notcheating = true;
            switch (player.lap)
            {
                case 1:
                    foreach (check c in checks)
                    {
                        if (!c.hit1)
                        {
                            notcheating = false;
                        }
                    }
                    if (notcheating)
                    {
                        player.lap = 2;
                    }
                    break;
                case 2:
                    foreach (check c in checks)
                    {
                        if (!c.hit2)
                        {
                            notcheating = false;
                        }
                    }
                    if (notcheating)
                    {
                        player.lap = 3;
                    }
                    break;
                case 3:
                    foreach (check c in checks)
                    {
                        if (!c.hit3)
                        {
                            notcheating = false;
                        }
                    }
                    if (notcheating)
                    {
                        Debug.Log("UHMMMM");
                        player.playing = false;
                        
                        ui.setPlaceText("");

                        switch (finalplace % 100)
                        {
                            case 11:
                            case 12:
                            case 13:
                                ui.setText(finalplace + "th");
                                break;
                        }

                        if(finalplace< 10)
                        {
                            switch (finalplace % 10)
                            {
                                case 1:
                                    ui.setText(finalplace + "st");
                                    break;
                                case 2:
                                    ui.setText(finalplace + "nd");
                                    break;
                                case 3:
                                    ui.setText(finalplace + "rd");
                                    break;
                                default:
                                    ui.setText(finalplace + "th");
                                    break;
                            }
                        }

                        ui.currentFace.color = new Color(0, 0, 0, 0);
                        ui.currentLogo.transform.localScale = new Vector3(0, 0, 0);

                        leadstring += finalplace + ". player " + player.timerstring + "\n";
                        finalplace++;

                        checks[0].hit3 = false;

                    }
                    break;
            }
        }

        if (other.CompareTag("enemy"))
        {
            aiscr e = other.GetComponent<aiscr>();

            if (e.obvnotcheating)
            {
                e.lap += 1;
                e.obvnotcheating = false;
                if (e.lap == 4)
                {
                    leadstring += finalplace + ". " + e.color + " " + player.timerstring + "\n";


                    finalplace++;
                    e.playing = false;



                }
            }



        }


    }




}
