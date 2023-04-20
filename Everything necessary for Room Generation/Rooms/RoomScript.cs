using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    //might go in RoomScript, which would manage clearing of a room and stuff.
    //loot table, enemy table, and tile set
    public class Room
    {
        private int lootRarity;
        private int lootSize;
        private int[][] enemySetArray;
        private int[] tileIntArray;

        //will change what is given when making a room. for now just placeholder data types
        public Room(int givenLootRarity, int givenLootSize, int givenEnemyPool, int[] tiles)
        {
            tileIntArray = tiles;

            lootRarity = givenLootRarity;
            lootSize = givenLootSize;

            //will almost certainly change this whole enemySpawnPool set-up.
            enemySetArray = setEnemies(givenEnemyPool);
        }

        //called when room is cleared.
        public void getLoot()
        {
            int count = lootSize;

            while (count > 0)
            {
                dropItem(); //will need to set up items to push away from each other when they spawn/are dropped. or spawn/drop them adjacent to each other
                count--;
            }
        }

        //drops a random item based on given rarity possibility
        private void dropItem()
        {
            if (lootRarity == 1)
            {
                //common-rare loot
            }
            else if (lootRarity == 2)
            {
                //rare loot
            }
            else if (lootRarity == 3)
            {
                //common-legendary loot
            }
            else if (lootRarity == 4)
            {
                //rare-legendary loot
            }
            else if (lootRarity >= 5)
            {
                //legendary loot
            }
            else
            {
                //something. dirt. idk.
            }

        }

        //might change parameter type.
        //will almost certainly change this whole enemySpawnPool set-up.
        private int[][] setEnemies(int enemyPool)
        {
            int[][] enemySet; //{ {type, spawnXcoordinate, spawnYcoordinate}, {type, spawnXcoordinate, spawnYcoordinate}, ... }
            if (enemyPool == 1)
            {
                enemySet = new int[][] { new int[] { 1, 0, 0 }, new int[] { 2, 1, -1 } };
            }
            else
            {
                enemySet = new int[][] { new int[] { 1, 0, 0 }, new int[] { 1, 1, 1 } };
            }
            return enemySet;

        }

        public int getLootRarity()
        {
            return lootRarity;
        }
        public int getLootSize()
        {
            return lootSize;
        }
        public string getEnemySet()
        {
            return enemySetArray.ToString(); //maybe
        }
        public int[] getTileSet()
        {
            return tileIntArray;
        }

    }

    void Start()
    {

    }

    void Update()
    {

    }
}
