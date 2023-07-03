using Unity.Entities;
using UnityEngine;

public class TurretAuthoring : MonoBehaviour
{
    public GameObject CannonBallPrefab;
    public Transform CannonBallSpawn;
    //Baker ���Խ� authoring MonoBehavious ת����ʵ������
    class Baker : Baker<TurretAuthoring> 
    {
        public override void Bake(TurretAuthoring authoring)
        {
            //GetEntity ����һ��GameObject �ĺ決�õ�ʵ������
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            //AddComponent ��Turret�����ӽ�entity��ͬʱΪTurret����е�����ʵ�����͸�ֵ
            AddComponent(entity, new Turret
            {
                CannonBallPrefab = GetEntity(authoring.CannonBallPrefab,TransformUsageFlags.Dynamic),
                CannonBallSpawn = GetEntity(authoring.CannonBallSpawn,TransformUsageFlags.Dynamic),
            });
            //��Shooting �������entity
            AddComponent<Shooting>(entity);
        }
    }

    //����Turret���
    public struct Turret : IComponentData
    {
        public Entity CannonBallPrefab;
        public Entity CannonBallSpawn;
    }

    public struct Shooting : IComponentData,IEnableableComponent
    {

    }
}
