// Copyright (c) Nitrous <n20gaming2000@gmail.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics.Cubism;
using osu.Framework.IO.Stores;

namespace osu.Framework.Live2D.Tests
{
    public class TestGame : Game
    {
        public CubismAssetStore CubismAssets { get; private set; }

        private DependencyContainer dependencies;
        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        [BackgroundDependencyLoader]
        private void load()
        {
            // Make sure to add resources included in the library as it contains necessary shaders to run Live2D assets.
            Resources.AddStore(new NamespacedResourceStore<byte[]>(new DllResourceStore(CubismResources.ResourceAssembly), "Resources"));
            Resources.AddStore(new NamespacedResourceStore<byte[]>(new DllResourceStore(typeof(TestGame).Assembly), "Resources"));

            CubismAssets = new CubismAssetStore(new NamespacedResourceStore<byte[]>(Resources, "Live2D"));
            dependencies.CacheAs(CubismAssets);
        }
    }
}