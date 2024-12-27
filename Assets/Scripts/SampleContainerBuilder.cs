using DefaultNamespace.Data;
using DefaultNamespace.Factory;
using DefaultNamespace.Logic;
using DefaultNamespace.Logic.Lua;
using DefaultNamespace.Presenter;
using DefaultNamespace.View;
using Presenter;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using VitalRouter.MRuby;
using VitalRouter.VContainer;
using XLua;

namespace DefaultNamespace
{
    public class SampleContainerBuilder : LifetimeScope
    {
		[SerializeField] private Transform _parent;
        [SerializeField] private OptionViewBase _optionView;
        [SerializeField] private MessageVisualizer _messageVisualizer;
        [SerializeField] private VerticalPlaceOptionRoot _verticalPlaceOptionRoot;
        
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
            
            builder.RegisterComponent(_messageVisualizer)
                .AsImplementedInterfaces();
            
            builder.RegisterComponent(_verticalPlaceOptionRoot)
                .AsImplementedInterfaces();
            
            // Ruby
            var context = MRubyContext.Create();
            builder.RegisterInstance(context);
            
            builder.Register<MyCommandPreset>(Lifetime.Singleton)
                .As<MRubyCommandPreset>();

            builder.Register<RubyContextHolder>(Lifetime.Singleton)
                .AsSelf();

            builder.Register<RubyRunner>(Lifetime.Singleton)
                .AsImplementedInterfaces();
            
            // Lua
            // var env = new LuaEnv();
            // builder.RegisterInstance(env);
            //
            // builder.Register<LuaEnvHolder>(Lifetime.Singleton)
            //     .AsSelf();
            //




            builder.Register<SharedStateHandler>(Lifetime.Singleton)
                .AsImplementedInterfaces();

            builder.Register<OptionFactory>(Lifetime.Singleton)
                .AsSelf();
            
            builder.Register<OptionReferenceHolder>(Lifetime.Singleton)
                .AsSelf();
            
            builder.Register<OptionController>(Lifetime.Singleton)
                .AsSelf();
        }
    }
}