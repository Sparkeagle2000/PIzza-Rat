﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManMover : MonoBehaviour
{
    //public Transform[] waypoints;
    //int cur = 0;
/*
    public float speed = 0.3f;
    public Node startingpos;
    public int scattertimer1=7, scattertimer2=5, chasetimer1=20;
    private int modechange=1;
    private float modetimer=0;
    public enum Mode {
        Chase,
        Scatter,
        Frightened
    }

    Mode currentMode=Mode.Scatter;
    Mode previousMode;

    private GameObject pizzarat;
    private Node current, target, previous;
    private Vector2 dir, nextdir;

    void Start ()
    {
        pizzarat=GameObject.FindGameObjectWithTag("pizzarat");
        Node node=GetNodeAtPosition(transform.localPosition);
        if(node!=null)
        {
            current=node;
        }
        direction=Vector2.up;
        previous=current;
        Vector2 pizzaratPos=pizzarat.transform.position;
        Vector2 targetTile=new Vector2(Mathf.RoundToInt(pizzaratPos.x),Mathf.RoundToInt(pizzaratPos.y));
        target=GetNodeAtPosition(targetTile);
    }

    void FixedUpdate () {
        // Waypoint not reached yet? then move closer
        if (transform.position != waypoints[cur].position) {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else cur = (cur + 1) % waypoints.Length;

        ModeUpdate();
        Move();

        // Animation
    //    Vector2 dir = waypoints[cur].position - transform.position;
     //   GetComponent<Animator>().SetFloat("DirX", dir.x);
      //  GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "pizzarat")
            Destroy(co.gameObject);
    }

    void Move()
    {
        if(target!=current &&target!=null)
        {
            if(OverShotTarget())
            {
                current=target;
                transform.localPosition=current.transform.position;
                GameObject otherPortal=GetPortal(current.transform.position);
                if(otherPortal!=null)
                {
                    transform.localPosition=otherPortal.transform.position;
                    current=otherPortal.GetComponent<Node>();
                }
                target=ChooseNectNode();
                previous=current;
                current=null;
            }
            else
            {
                transform.localPosition+=(Vector3)direction*speed*Time.deltaTime;
            }
        }
    }
    
    void ChangeMode (Mode m)
    {
        currentMode=m;
    }

    void ModeUpdate ()
    {
        if(currentMode!= Mode.Frightened)
        {
            modetimer+= Time.deltaTime;
            if(modechange==1)
            {
                if(currentMode==Mode.Scatter && modetimer >scattertimer1)
                {
                    ChangeMode (Mode.Chase);
                    modetimer=0;
                }
                if(currentMode==Mode.Chase && modetimer >chasetimer1)
                {
                    modechange=2;
                    ChangeMode (Mode.Scatter);
                    modetimer=0;
                }
            }
            else if(modechange==2)
            {
                if(currentMode==Mode.Scatter && modetimer >scattertimer1)
                {
                    ChangeMode (Mode.Chase);
                    modetimer=0;
                }
                if(currentMode==Mode.Chase && modetimer >chasetimer1)
                {
                    modechange=3;
                    ChangeMode (Mode.Scatter);
                    modetimer=0;
                }
            }
            else if(modechange==3)
            {
                if(currentMode==Mode.Scatter && modetimer >scattertimer2)
                {
                    ChangeMode (Mode.Chase);
                    modetimer=0;
                }
                if(currentMode==Mode.Chase && modetimer >chasetimer1)
                {
                    modechange=4;
                    ChangeMode (Mode.Scatter);
                    modetimer=0;
                }
            }
            else if(modechange==4)
            {
                if(currentMode==Mode.Scatter && modetimer >scattertimer2)
                {
                    ChangeMode (Mode.Chase);
                    modetimer=0;
                }
            }
        }
        else if (currentMode==Mode.Frightened)
        {

        }
    }

    Node ChooseNextNode ()
    {
        Vector2 targetTile=Vector2.zero;
        Vector2 pizzaratPos=pizzarat.transform.position;
        targetTile=new Vector2(Mathf.RoundToInt(pizzaratPos.x),Mathf.RoundToInt(pizzaratPos.y));
        Node moveToNode=null;
        Node[] foundNodes=new Node[4];
        Vector2[] foundNodesDir=new Vector2[4];
        int nodecount=0;
        for(int i=0;i<current.neighbors.Length;i++)
        {
            if(current.validDirections [i]!=direction*-1)
            {
                foundNodes [nodecount]=current.neighbors [i];
                foundNodesDir [nodecount]= current.validDirections [i];
                nodecount++;
            }
        }
        if (foundNodes.Length==1)
        {
            moveToNode=foundNodes[0];
            direction=foundNodesDir[0];
        }
        if (foundNodes.Length>1)
        {
            float leastDis=100000f;
            for (int i=0;i<foundNodes.Length; i++)
            {
                if(foundNodesDir[i]!=Vector2.zero)
                {
                    float distance=GetDistance(foundNodes[i].transform.position, targetTile);
                    if(distance<leastDis)
                    {
                        leastDis=distance;
                        moveToNode=foundNodes[i];
                        distance=foundNodesDir [i];
                    }
                }
            }
        }
        return moveToNode;
    }

    Node GetNodeAtPosition (Vector2 pos)
    {
        GameObject tile= GameObject.Find ("Game").GetComponent<GameBoard> ().board [(int)pos.x, (int)pos.y)];

        if(tile!=null)
        {
            if(tile.GetComponent<Node>[]!=null)
            {
                return tile.GetComponent<Node> ();
            }
        }
        return null;
    }

    GameObject GetPortal (Vector2 pos)
    {
        GameObject tile= GameObject.Find ("Game").GetComponent<GameBoard> ().board [(int)pos.x, (int)pos.y)];

        if(tile!=null)
        {
            if(tile.GetComponent<Tile>().isPortal)
            {
                GameObject otherPortal=tile.GetComponent<Tile>().portalReceiver;
                return otherPortal;
            }
        }
        return null;
    }

    float LengthFromNode (Vector2 targetPosition)
    {
        Vector2 vec=targetPosition-(Vector2)previous.transform.position;
        return vec.sqrMagnitude;
    }

    bool OverShotTarget ()
    {
        float nodeToTarget=LengthFromNode(target.transform.position);
        float nodeToSelf=LengthFromNode(transform.localPosition);
        return nodeToSelf>nodeToTarget;
    }

    float GetDistance (Vector2 posA, Vector2 posB)
    {
        float dx=posA.x - posB.x;
        float dy=posA.y - posB.y;
        float distance=Mathf.Sqrt(dx*dx+dy*dy);
        return distance;
    }
    */
}