using System;
using DefaultNamespace.Data;
using DefaultNamespace.Factory;
using DefaultNamespace.Logic;
using DefaultNamespace.Logic.Lua;
using DefaultNamespace.Presenter;
using DefaultNamespace.View;
using Lua;
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
        [SerializeField] private OptionViewBase _optionView;
        [SerializeField] private MessageVisualizer _messageVisualizer;
        [SerializeField] private VerticalPlaceOptionRoot _verticalPlaceOptionRoot;
        
        [SerializeField] private bool _useRuby;
        
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

            if (_useRuby)
            {
                // Ruby
                var context = MRubyContext.Create();
                builder.RegisterInstance(context);
                
                builder.Register<MyCommandPreset>(Lifetime.Singleton)
                    .AsSelf();
                
                builder.Register<RubyContextHolder>(Lifetime.Singleton)
                    .AsSelf();
                
                builder.Register<RubyRunner>(Lifetime.Singleton)
                    .AsImplementedInterfaces();
                
                builder.Register<RubySharedStateHandler>(Lifetime.Singleton)
                    .AsImplementedInterfaces();
            }
            else
            {
                // Lua
                var state = LuaState.Create();
                builder.RegisterInstance(state);
                
                builder.Register<LuaStateHolder>(Lifetime.Singleton)
                    .AsSelf();
                
                builder.Register<LuaRunner>(Lifetime.Singleton)
                    .AsImplementedInterfaces();
                
                builder.Register<LuaSharedStateHandler>(Lifetime.Singleton)
                    .AsImplementedInterfaces();
                
                builder.Register<LuaFunctionAdder>(Lifetime.Singleton)
                    .AsSelf();
            }
            
            

            builder.Register<OptionFactory>(Lifetime.Singleton)
                .AsSelf();
            
            builder.Register<OptionReferenceHolder>(Lifetime.Singleton)
                .AsSelf();
            
            builder.Register<OptionController>(Lifetime.Singleton)
                .AsSelf();
        }
    }
}