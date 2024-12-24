using VContainer;
using VContainer.Unity;
using VitalRouter.VContainer;

namespace DefaultNamespace
{
    public class SampleContainerBuilder : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterVitalRouter( routing =>
            {
                routing.Map<DebugPresenter>();
            });

            builder.RegisterEntryPoint<EntryPoint>(Lifetime.Singleton);

        }
    }
}