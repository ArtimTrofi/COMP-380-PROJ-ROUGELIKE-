using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{


    //GameObject currentRoom = GameObject.Find("CurrentRoom") or GameObject.FindWithTag("Room");   

    public RoomGenerationScript roomGenerator;
    public GameObject currentRoom;

    public GameObject playerChar;
    public CharScript playerCharScript;

    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("master script start");

        roomGenerator = GameObject.Find("RoomGenerator").GetComponent<RoomGenerationScript>();
        //playerChar = GameObject.Find("PlayerCharacter");
        playerCharScript = GameObject.Find("PlayerCharacter").GetComponent<CharScript>();


        //TILEMAP ROOMS
        currentRoom = roomGenerator.generateRoom();
        playerChar.transform.position = roomGenerator.getNewPosition(); //could move this into RoomGenerationScript if I give that script access to PlayerChar

    }

    // Update is called once per frame
    void Update()
    {
        /*
        timer += Time.deltaTime;

        if (timer > 3)
        {
            timer = 0;
            moveToNewRoom();
        }
        */
    }


    //deletes current room and generates new room, moving player to appropriate spot.
    public void moveToNewRoom()
    {
        Destroy(currentRoom);
        playerChar.transform.position = new Vector3(-10, -10, 0); //throwaway position, to get char out of way for new room and avoid accidents
        playerCharScript.doingSomething();
        currentRoom = roomGenerator.generateRoom();
        playerChar.transform.position = roomGenerator.getNewPosition();//could move this into RoomGenerationScript if I give that script access to PlayerChar
        playerCharScript.doingSomething();
    }
}
