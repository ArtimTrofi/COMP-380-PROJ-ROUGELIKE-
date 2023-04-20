using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomGenerationScript : MonoBehaviour
{
    public int roomCount = 0; //# of completed rooms. Tracking because after X rooms, next will automatically be a boss room. Might increment it somewhere else. (maybe in master script? or room script? since it'd increment on clearing a room)
    private int floorCount = 1; //level or floor. will increment on moving to next floor (likely on clearing a boss room)

    private Vector3 newPosition; //position the character will be snapped to on generation of a new room. determined by doorEntrance, or "5" in the room arrays

    public GameObject[] tilemapRoomArray;


    void Awake()
    {
        Debug.Log("room generator online");

        //currentRoom = GameObject.Find("CurrentRoom");  from when CurrentRoom was a GameObject in the scene, not a prefab
        newPosition = new Vector3(0, 0, 0);
        //newPosition = currentRoom.transform.position;  from when CurrentRoom was a GameObject in the scene, not a prefab
    }



    public Vector3 getNewPosition()
    {
        return newPosition;
    }


    public GameObject generateRoom()
    {
        //IMPLEMENT SOMETHING SO IT WON'T REPEAT ROOMS, maybe even for a few rooms.

        roomCount++;
        if (roomCount >= 5)
        {
            floorCount++;
            roomCount = 0;
        }

        //random selection of room
        int randRoomNum;
        if (floorCount == 1)
        {
            randRoomNum = Random.Range(0, tilemapRoomArray.Length); //adjust the range for floor 1
        }
        else
        {
            randRoomNum = Random.Range(0, tilemapRoomArray.Length); //adjust the range for floor 2, etc
        }

        //unused Room class. Might use it later for enemy and loot spawn tables. might not.
        //Room newRoom = new Room((roomCount + 1) % 5, 3, randRoomNum, normalRoomSet[randRoomNum]); //lootRarity, lootSize, enemySet, tileSet

        Debug.Log("generating tilemap room " + randRoomNum);

        //instantiating a room prefab
        GameObject currentRoom = Instantiate(tilemapRoomArray[randRoomNum], new Vector3(0, 0, 0), transform.rotation);

        //setting position for player to snap to in new room (near entrance). (actual snapping is done in MasterScript)
        newPosition = currentRoom.transform.GetChild(1).transform.position; //(1) is EntrancePoint, for now

        Debug.Log("finished generating");

        return currentRoom;
    }

}
