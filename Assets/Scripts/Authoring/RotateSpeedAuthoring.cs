using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class RotateSpeedAuthoring : MonoBehaviour
{
    [Range(0, 360)]public float rotateSpeed = 360.0f;

    //�̳���Baker<>
    public class Baker : Baker<RotateSpeedAuthoring>
    {
        public override void Bake(RotateSpeedAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var data = new RotateSpeed
            {
                rotateSpeed = math.radians(authoring.rotateSpeed),
            };
            AddComponent(entity, data); //��ʵ��������
        }
    }
}

struct RotateSpeed : IComponentData
{
    public float rotateSpeed;
}
