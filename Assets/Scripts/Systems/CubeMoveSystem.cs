using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct CubeMoveSystem : ISystem
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
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (transform, move) in
            SystemAPI.Query<RefRW<LocalTransform>, RefRO<Move>>())
        {
            transform.ValueRW.Position += move.ValueRO.dir * move.ValueRO.speed * deltaTime;
        }
    }
}
