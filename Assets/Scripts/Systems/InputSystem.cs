using Unity.Mathematics;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct InputSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach(var move in SystemAPI.Query<RefRW<Move>>())
        {
            if(Input.GetKey(KeyCode.W))
            {
                move.ValueRW.dir = new float3(0,1,0);
                Debug.Log("ио");
            }
            if (Input.GetKey(KeyCode.S))
            {
                move.ValueRW.dir = new float3(0, -1, 0);
                Debug.Log("об");
            }
            if (Input.GetKey(KeyCode.A))
            {
                move.ValueRW.dir = new float3(-1, 0, 0);
                Debug.Log("вС");
            }
            if (Input.GetKey(KeyCode.D))
            {
                move.ValueRW.dir = new float3(1, 0, 0);
                Debug.Log("ср");
            }
            if(!Input.anyKey)
            {
                move.ValueRW.dir = new float3(0, 0, 0);
                Debug.Log("Stop");
            }
        }
    }
}
