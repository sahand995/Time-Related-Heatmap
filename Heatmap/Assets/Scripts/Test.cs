using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Test : MonoBehaviour
{
    private Grid_ grid;

    [SerializeField] private HeatMapVisual heatMapVisual;

    public GameObject floor;

    private float floor_x;
    private float floor_z;
    private Vector3 floor_origin;

    public GameObject player;
    public GameObject player_1;

    Vector3 playerPosition;
    Vector3 playerPosition_1;

    Vector3 position;
    Vector3 position_1;

    int value;
    int value_1;

    //private GameObject[] players;
    //private Vector3[] playerPosition;
    //private Vector3[] position;
    //private int[] value;

    void Start()
    {
        //players = GameObject.FindGameObjectsWithTag("Player");
        //playerPosition = new Vector3[players.Length];
        //position = new Vector3[players.Length];
        //value = new int[players.Length];

        floor_x = floor.GetComponent<Collider>().bounds.size.x;
        floor_z = floor.GetComponent<Collider>().bounds.size.z;
        floor_origin = new Vector3(floor.GetComponent<Transform>().position.x - (floor_x / 2),
                                   floor.GetComponent<Transform>().position.y,
                                   floor.GetComponent<Transform>().position.z - (floor_z / 2));

        grid = new Grid_(Mathf.RoundToInt(floor_x), Mathf.RoundToInt(floor_z), 1, floor_origin);


        heatMapVisual.SetGrid(grid);

    }

    void Update()
    {
        playerPosition = player.GetComponent<Transform>().position;
        playerPosition_1 = player_1.GetComponent<Transform>().position;

        position = new Vector3(playerPosition.x + floor_x / 2, 0, playerPosition.z + floor_z / 2);
        position_1 = new Vector3(playerPosition_1.x + floor_x / 2, 0, playerPosition_1.z + floor_z / 2);

        value = grid.GetValue(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z));
        value_1 = grid.GetValue(Mathf.RoundToInt(position_1.x), Mathf.RoundToInt(position_1.z));

        if (player.GetComponent<Person>().GetMoveDir().x != 0 && player.GetComponent<Person>().GetMoveDir().z != 0)
        {
            grid.SetValue(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z), value + 1);
        }

        if (player_1.GetComponent<Person_1>().GetMoveDir().x != 0 && player_1.GetComponent<Person_1>().GetMoveDir().z != 0)
        {
            grid.SetValue(Mathf.RoundToInt(position_1.x), Mathf.RoundToInt(position_1.z), value_1 + 1);
        }
    }
}


//for (int i = 0; i < players.Length; i++)
//{
//    playerPosition[i] = players[i].GetComponent<Transform>().position;
//    position[i] = new Vector3(playerPosition[i].x + floor_x / 2, 0, playerPosition[i].z + floor_x / 2);
//    value[i] = grid.GetValue(Mathf.RoundToInt(position[i].x), Mathf.RoundToInt(position[i].z));
//    grid.SetValue(Mathf.RoundToInt(position[i].x), Mathf.RoundToInt(position[i].z), value[i] + 1);
//}