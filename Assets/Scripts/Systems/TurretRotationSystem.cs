using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

//BurstCompile：继承于ISystem接口的Unmanaged system可以被Burst compiled,但是这并不是被默认设置编译的
//因此我们需要加上[BurstCompile]特性来开启Burst compile
//此特性被添加于 struct 和 OnCreate/OnDestroy/OnUpdate 函数上才是有效的
public partial struct TurretRotationSystem : ISystem
{
   public void OnCreate(ref SystemState state)
    {
        //RequireForUpdate 使得当场景中至少有一个实体具有TurretRotation组件时，系统才会更新
        state.RequireForUpdate<Execute.TurretRotation>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        //以Y轴为旋转轴每秒旋转180°
        var spin = quaternion.RotateY(SystemAPI.Time.DeltaTime * math.PI);

        //SystemAPI.Query 方法只能在foreach 中 作为 in 子句调用
        //
        foreach (var transform in
            SystemAPI.Query<RefRW<LocalTransform>>()
            .WithAll<TurretAuthoring.Turret>())
        {
            transform.ValueRW.Rotation = math.mul(spin, transform.ValueRO.Rotation);
        }
    }
}
