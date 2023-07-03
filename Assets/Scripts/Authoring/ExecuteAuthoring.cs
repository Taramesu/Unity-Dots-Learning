using Unity.Entities;
using UnityEngine;

//建立一个名为执行（Execute）的命名空间
namespace Execute
{
    public class ExecuteAuthoring : MonoBehaviour
    {

        /// <summary>
        /// Class Baker
        /// 命名空间：Unity.Entities
        /// 文档：https://docs.unity3d.com/Packages/com.unity.entities@1.0/api/Unity.Entities.Baker-1.html
        /// </summary>
        class Baker : Baker<ExecuteAuthoring>
        {
            public override void Bake(ExecuteAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);

                AddComponent<TurretRotation>(entity);
            }
        }
    }

    public struct TurretRotation : IComponentData
    {
    }
}

