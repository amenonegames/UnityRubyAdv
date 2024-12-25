using amenone.VcontainerExtensions.Identifier;
using amenone.VcontainerExtensions.Utils;
using DefaultNamespace.Data;
using DefaultNamespace.Factory;
using DefaultNamespace.Logic;
using DefaultNamespace.Presenter;
using DefaultNamespace.View;
using Presenter;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using VitalRouter.MRuby;
using VitalRouter.VContainer;

namespace DefaultNamespace
{
    public class SampleContainerBuilder : LifetimeScope
    {
		[SerializeField] private Transform _parent;
        [SerializeField] private OptionView _optionView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterVitalRouter( routing =>
            {
                routing.Map<DebugPresenter>();
                routing.Map<TalkPresenter>();
                routing.Map<OptionPresenter>();
            });

            builder.RegisterEntryPoint<EntryPoint>(Lifetime.Singleton);
            builder.RegisterComponent(_optionView);

            var registerables =_parent.GetComponentsInChildren<IRegisterMarker>(true);

            builder.RegisterComponentOrNullObFromArray<IMessageVisualizable, IMessageVisualizableAsNullObj>(registerables,true,true);
            builder.RegisterComponentOrNullObFromArray<IOptionRoot, IOptionRootAsNullObj>(registerables,true,true);
            
            var context = MRubyContext.Create();
            builder.RegisterInstance(context);

            builder.Register<MyCommandPreset>(Lifetime.Singleton)
                .As<MRubyCommandPreset>();

            builder.Register<RubyContextHolder>(Lifetime.Singleton)
                .AsSelf();

            builder.Register<RubyRunner>(Lifetime.Singleton)
                .AsSelf();

            builder.Register<SharedStateHandler>(Lifetime.Singleton)
                .AsSelf();

            builder.Register<OptionFactory>(Lifetime.Singleton)
                .AsSelf();
        }
    }
}