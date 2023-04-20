using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExitScript : MonoBehaviour
{
    private bool isOpen;
    public MasterScript master;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = true;
        master = GameObject.Find("Master").GetComponent<MasterScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //called on clearing a room
    public void Open()
    {
        //maybe play an animation of the door opening. or just swap out the door sprite for an open door
        isOpen = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hitting exit door");
        if (isOpen)
        {
            master.moveToNewRoom();
        }
    }


}

