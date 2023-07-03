using Unity.Entities;
using UnityEngine;

//����һ����Ϊִ�У�Execute���������ռ�
namespace Execute
{
    public class ExecuteAuthoring : MonoBehaviour
    {

        /// <summary>
        /// Class Baker
        /// �����ռ䣺Unity.Entities
        /// �ĵ���https://docs.unity3d.com/Packages/com.unity.entities@1.0/api/Unity.Entities.Baker-1.html
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

