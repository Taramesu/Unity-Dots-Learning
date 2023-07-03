using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MoveStateAuthoring : MonoBehaviour
{
    [Range(0, 10)] public float speed = 10.0f;
    public class Baker : Baker<MoveStateAuthoring>
    {
        public override void Bake(MoveStateAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var data = new Move
            {
                dir = new float3(0, 0, 0),
                speed = authoring.speed
            };
            AddComponent(entity, data);
        }
    }
}

public struct Move : IComponentData
{
    public float3 dir;
    public float speed;
}
