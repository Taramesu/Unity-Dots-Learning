using Unity.Entities;
using UnityEngine;

public class TurretAuthoring : MonoBehaviour
{
    public GameObject CannonBallPrefab;
    public Transform CannonBallSpawn;
    //Baker 可以将 authoring MonoBehavious 转换成实体和组件
    class Baker : Baker<TurretAuthoring> 
    {
        public override void Bake(TurretAuthoring authoring)
        {
            //GetEntity 返回一个GameObject 的烘焙好的实体类型
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            //AddComponent 将Turret组件添加进entity，同时为Turret组件中的两个实体类型赋值
            AddComponent(entity, new Turret
            {
                CannonBallPrefab = GetEntity(authoring.CannonBallPrefab,TransformUsageFlags.Dynamic),
                CannonBallSpawn = GetEntity(authoring.CannonBallSpawn,TransformUsageFlags.Dynamic),
            });
            //将Shooting 组件加入entity
            AddComponent<Shooting>(entity);
        }
    }

    //创建Turret组件
    public struct Turret : IComponentData
    {
        public Entity CannonBallPrefab;
        public Entity CannonBallSpawn;
    }

    public struct Shooting : IComponentData,IEnableableComponent
    {

    }
}
