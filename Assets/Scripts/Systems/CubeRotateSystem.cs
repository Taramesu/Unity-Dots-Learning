using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;
using Unity.VisualScripting;

public partial struct CubeRotateSystem : ISystem
{
    //BurstCompile���̳���ISystem�ӿڵ�Unmanaged system���Ա�Burst compiled,�����Ⲣ���Ǳ�Ĭ�����ñ����
    //���������Ҫ����[BurstCompile]����������Burst compile
    //�����Ա������ struct �� OnCreate/OnDestroy/OnUpdate �����ϲ�����Ч��
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }

    [BurstCompile]

    public void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    //���� ref SystemState ��һ���������ͣ����ڴ���SystemState����
    //SystemState��һ���ṹ�壬���ڴ洢ϵͳ��״̬��Ϣ������ʱ�䡢ʵ�������ȵȡ�
    //������ű��У�OnUpdate��������ÿһ֡�����ã�ͨ������SystemState���󣬿��Ի�ȡ����ǰ��ʱ����Ϣ��
    public void OnUpdate(ref SystemState state)
    {
        //����SystemAPI��ȡ������һ֡�����ѵ�ʱ��
        var deltaTime = SystemAPI.Time.DeltaTime;
        //foreach����dotsϵͳ��д���ܹ�����world�е�����ʵ��
        //ͨ��SystemAPI.Query���Խ��ж�����ĸ�Ч��ѯ
        //RefRW���ɶ�дread/write                      RefRO���ɶ�read-only
        //LocalTransformΪ�Դ�����������÷������ĵ�Unity.Transforms
        //RotateSpeedΪ���������б�д�����
        foreach (var (transform, speed) in
            SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>())
        {
            //quatenion.RotateX���ڷ�����X����ת����Ԫ��
            //deltaTime * speed.ValueRO.rotateSpeed���ڼ�����ת�Ƕ�
            var spin = quaternion.RotateX(deltaTime * speed.ValueRO.rotateSpeed);

            //����ת�����ԭ�о�����ˣ�ʵ��������ת
            transform.ValueRW.Rotation = math.mul(spin, transform.ValueRO.Rotation);
        }
    }
}
