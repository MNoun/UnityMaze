using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // initializing
        int w;
        int h;
        int rowNumb;
        int v1;
        int v2;
        int oldG;
        int newG;
        int edgeID2;
        int x1 = 0;
        int x2 = 0;
        int x3 = 0;
        int x4 = 0;
        int x5 = 0;
        int x6 = 0;
        int y = 0;
        int z = 0;
        int z1 = 0;
        int z2 = 0;
        int z3 = 0;
        int z4 = 0;
        int z5 = 0;

        // Randomized Kruskal's Algorithm

        w = 6; // # of columns
        h = 6; // # of rows

        int[,] mazeRep = new int[w*h,4]; // 2d array for maze representation

        int[] groupID = new int[w*h]; // groupID array 0 - w*h
        for (int i = 0; i < groupID.Length; i++)
        {
            groupID[i] = i; // populating groupID with 0 - 35
        }

        int numberOfEdges = (w-1)*h+w*(h-1); // # of edges in the maze
        int[] edgeList = new int[numberOfEdges]; // edgeList array with 0 - numberOfEdges
        for (int i = 0; i < edgeList.Length; i++)
        {
            edgeList[i] = i; // populating edgeList with 0 - 59
        }
        for (int i = edgeList.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0,i+1); // shuffling edgList
            int tmp = edgeList[i];
            edgeList[i] = edgeList[r];
            edgeList[r] = tmp;
        }

        foreach(int edgeID in edgeList) // start of for loop
        {
            if (edgeID < (w-1)*h) // if edgeID is horizontal
            {
                rowNumb = edgeID/(w-1);
                v1 = edgeID + rowNumb;
                v2 = v1 + 1;
                if (groupID[v1] != groupID[v2])
                {
                    mazeRep[v1,3] = 1;
                    mazeRep[v2,1] = 1;
                    oldG = groupID[v1];
                    newG = groupID[v2];
                    for(int i = 0; i < w*h; i++)
                    {
                        if (groupID[i] == oldG)
                        {
                            groupID[i] = newG;
                        }
                    }
                }
            }
            else // if edgeID is vertical
            {
                //edgeID -= (w-1)*h;
                edgeID2 = edgeID - (w-1)*h;
                v1 = edgeID2;
                v2 = v1 + w;
                if (groupID[v1] != groupID[v2])
                {
                    mazeRep[v1,2] = 1;
                    mazeRep[v2,0] = 1;
                    oldG = groupID[v1];
                    newG = groupID[v2];
                    for(int i = 0; i < w*h; i++)
                    {
                        if (groupID[i] == oldG)
                        {
                            groupID[i] = newG;
                        }
                    }
                }
            }
        }

        int[] mazeCellArray = new int[w*h]; // creating mazeCellArray
        
        // comparing mazeRep to tileIDs
        for (int i = 0; i < 36; i++)
        {
            if(mazeRep[i,0] == 0)
            {
                if(mazeRep[i,1] == 0)
                {
                    if(mazeRep[i,2] == 0)
                    {
                        if(mazeRep[i,3] == 0)
                        {
                            mazeCellArray[i] = 16; // 0000
                        }
                        else // if mazeRep[i,3] == 1
                        {
                            mazeCellArray[i] = 10; // 0001
                        }
                    }
                    else // if mazeRep[i,2] == 1
                    {
                        if(mazeRep[i,3] == 0)
                        {
                            mazeCellArray[i] = 1; // 0010
                        }
                        else // if mazeRep[i,3] == 1
                        {
                            mazeCellArray[i] = 9; // 0011
                        }
                    }
                }
                else // if mazeRep[i,1] == 1
                {
                    if(mazeRep[i,2] == 0)
                    {
                        if(mazeRep[i,3] == 0)
                        {
                            mazeCellArray[i] = 6; // 0100
                        }
                        else // if mazeRep[i,3] == 1
                        {
                            mazeCellArray[i] = 4; // 0101
                        }
                    }
                    else // if mazeRep[i,2] == 1
                    {
                        if(mazeRep[i,3] == 0)
                        {
                            mazeCellArray[i] = 5; // 0110
                        }
                        else // if mazeRep[i,3] == 1
                        {
                            mazeCellArray[i] = 2; // 0111
                        }
                    }
                }
            }
            else // if mazeRep[i,0] == 1
            {
                if(mazeRep[i,1] == 0)
                {
                    if(mazeRep[i,2] == 0)
                    {
                        if(mazeRep[i,3] == 0)
                        {
                            mazeCellArray[i] = 13; // 1000
                        }
                        else // if mazeRep[i,3] == 1
                        {
                            mazeCellArray[i] = 11; // 1001
                        }
                    }
                    else //if mazeRep[i,2] == 1
                    {
                        if(mazeRep[i,3] == 0)
                        {
                            mazeCellArray[i] = 15; // 1010
                        }
                        else // if mazeRep[i,3] == 1
                        {
                            mazeCellArray[i] = 12; // 1011
                        }
                    }
                }
                else // if mazeRep[i,1] == 1
                {
                    if(mazeRep[i,2] == 0)
                    {
                        if(mazeRep[i,3] == 0)
                        {
                            mazeCellArray[i] = 7; // 1100
                        }
                        else // if mazeRep[i,3] == 1
                        {
                            mazeCellArray[i] = 14; // 1101
                        }
                    }
                    else // if mazeRep[i,2] == 1
                    {
                        if(mazeRep[i,3] == 0)
                        {
                            mazeCellArray[i] = 8; // 1110
                        }
                        else // if mazeRep[i,3] == 1
                        {
                            mazeCellArray[i] = 3; // 1111
                        }
                    }
                }
            }
        }

        // Initialize all maze tiles
        GameObject BotTile = Resources.Load("BotTile", typeof(GameObject)) as GameObject;
        GameObject BotTTile = Resources.Load("BotTTile", typeof(GameObject)) as GameObject;
        GameObject CrossTile = Resources.Load("CrossTile", typeof(GameObject)) as GameObject;
        GameObject HStraightTile = Resources.Load("HStraightTile", typeof(GameObject)) as GameObject;
        GameObject LeftBotTile = Resources.Load("LeftBotTile", typeof(GameObject)) as GameObject;
        GameObject LeftTile = Resources.Load("LeftTile", typeof(GameObject)) as GameObject;
        GameObject LeftTopTile = Resources.Load("LeftTopTile", typeof(GameObject)) as GameObject;
        GameObject LeftTTile = Resources.Load("LeftTTile", typeof(GameObject)) as GameObject;
        GameObject RightBotTile = Resources.Load("RightBotTile", typeof(GameObject)) as GameObject;
        GameObject RightTile = Resources.Load("RightTile", typeof(GameObject)) as GameObject;
        GameObject RightTopTile = Resources.Load("RightTopTile", typeof(GameObject)) as GameObject;
        GameObject RightTTile = Resources.Load("RightTTile", typeof(GameObject)) as GameObject;
        GameObject TopTile = Resources.Load("TopTile", typeof(GameObject)) as GameObject;
        GameObject TopTTile = Resources.Load("TopTTile", typeof(GameObject)) as GameObject;
        GameObject VStraightTile = Resources.Load("VStraightTile", typeof(GameObject)) as GameObject;
        GameObject BlankTile = Resources.Load("BlankTile", typeof(GameObject)) as GameObject;
        
        // method to create tiles based on ID from mazeCellArray and cooridinates
        void CreateTile(int ID, int x, int y, int z)
        {
            if(ID == 1)
            {
                Instantiate(BotTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 2)
            {
                Instantiate(BotTTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 3)
            {
                Instantiate(CrossTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 4)
            {
                Instantiate(HStraightTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 5)
            {
                Instantiate(LeftBotTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 6)
            {
                Instantiate(LeftTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 7)
            {
                Instantiate(LeftTopTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 8)
            {
                Instantiate(LeftTTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 9)
            {
                Instantiate(RightBotTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 10)
            {
                Instantiate(RightTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 11)
            {
                Instantiate(RightTopTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 12)
            {
                Instantiate(RightTTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 13)
            {
                Instantiate(TopTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 14)
            {
                Instantiate(TopTTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 15)
            {
                Instantiate(VStraightTile, new Vector3(x,y,z), Quaternion.identity);
            }
            else if(ID == 16)
            {
                Instantiate(BlankTile, new Vector3(x,y,z), Quaternion.identity);
            }
        }


        // assigning mazeCell IDs to a tile and constructing the maze
        for (int i = 0; i < 6; i++) // first row
        {
            CreateTile(mazeCellArray[i],x1,y,z);
            x1 += 10;
        }
        for (int i = 6; i < 12; i++) // second row
        {
            z1 = -10;
            CreateTile(mazeCellArray[i],x2,y,z1);
            x2 += 10;
        }
        for (int i = 12; i < 18; i++) // third row
        {
            z2 = -20;
            CreateTile(mazeCellArray[i],x3,y,z2);
            x3 += 10;
        }
        for (int i = 18; i < 24; i++) // fourth row
        {
            z3 = -30;
            CreateTile(mazeCellArray[i],x4,y,z3);
            x4 += 10;
        }
        for (int i = 24; i < 30; i++) // fifth row
        {
            z4 = -40;
            CreateTile(mazeCellArray[i],x5,y,z4);
            x5 += 10;
        }
        for (int i = 30; i < 36; i++) // sixth row
        {
            z5 = -50;
            CreateTile(mazeCellArray[i],x6,y,z5);
            x6 += 10;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
