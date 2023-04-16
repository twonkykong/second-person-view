using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    [SerializeField] private Player player;
    [SerializeField] private NpcTargetField npcTargetField;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(player).AsSingle().NonLazy();
        Container.Bind<NpcTargetField>().FromInstance(npcTargetField).AsSingle().NonLazy();
    }
}
