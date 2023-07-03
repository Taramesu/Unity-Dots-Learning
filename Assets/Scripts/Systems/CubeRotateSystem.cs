using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;
using Unity.VisualScripting;

public partial struct CubeRotateSystem : ISystem
{
    //BurstCompile：继承于ISystem接口的Unmanaged system可以被Burst compiled,但是这并不是被默认设置编译的
    //因此我们需要加上[BurstCompile]特性来开启Burst compile
    //此特性被添加于 struct 和 OnCreate/OnDestroy/OnUpdate 函数上才是有效的
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }

    [BurstCompile]

    public void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    //参数 ref SystemState 是一个引用类型，用于传递SystemState对象。
    //SystemState是一个结构体，用于存储系统的状态信息，包括时间、实体数量等等。
    //在这个脚本中，OnUpdate方法会在每一帧被调用，通过传递SystemState对象，可以获取到当前的时间信息。
    public void OnUpdate(ref SystemState state)
    {
        //调用SystemAPI获取距离上一帧所花费的时间
        var deltaTime = SystemAPI.Time.DeltaTime;
        //foreach经过dots系统重写，能够遍历world中的所有实体
        //通过SystemAPI.Query可以进行对组件的高效查询
        //RefRW：可读写read/write                      RefRO：可读read-only
        //LocalTransform为自带组件，具体用法查阅文档Unity.Transforms
        //RotateSpeed为开发者自行编写的组件
        foreach (var (transform, speed) in
            SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>())
        {
            //quatenion.RotateX用于返回绕X轴旋转的四元数
            //deltaTime * speed.ValueRO.rotateSpeed用于计算旋转角度
            var spin = quaternion.RotateX(deltaTime * speed.ValueRO.rotateSpeed);

            //将旋转矩阵和原有矩阵相乘，实现物体旋转
            transform.ValueRW.Rotation = math.mul(spin, transform.ValueRO.Rotation);
        }
    }
}
