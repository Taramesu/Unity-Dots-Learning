using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

//BurstCompile���̳���ISystem�ӿڵ�Unmanaged system���Ա�Burst compiled,�����Ⲣ���Ǳ�Ĭ�����ñ����
//���������Ҫ����[BurstCompile]����������Burst compile
//�����Ա������ struct �� OnCreate/OnDestroy/OnUpdate �����ϲ�����Ч��
public partial struct TurretRotationSystem : ISystem
{
   public void OnCreate(ref SystemState state)
    {
        //RequireForUpdate ʹ�õ�������������һ��ʵ�����TurretRotation���ʱ��ϵͳ�Ż����
        state.RequireForUpdate<Execute.TurretRotation>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        //��Y��Ϊ��ת��ÿ����ת180��
        var spin = quaternion.RotateY(SystemAPI.Time.DeltaTime * math.PI);

        //SystemAPI.Query ����ֻ����foreach �� ��Ϊ in �Ӿ����
        //
        foreach (var transform in
            SystemAPI.Query<RefRW<LocalTransform>>()
            .WithAll<TurretAuthoring.Turret>())
        {
            transform.ValueRW.Rotation = math.mul(spin, transform.ValueRO.Rotation);
        }
    }
}
