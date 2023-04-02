using System;
using Cysharp.Threading.Tasks;
using Framework.framework.repository;
using UnityEngine;

namespace Framework.framework.context
{
    public static class GameContextExtension
    {
        public static void UseDataConfigLoader(this GameContext gameContext)
        {
            var config = Resources.Load<LoaderDataConfig>("ConfigData");
            if (config != null)
            {
                switch (config.ConfigLoaderMode)
                {
                    case ConfigLoaderMode.Remote:
                        gameContext.injectionBinder.Bind<IConfigLoader>().To<RemoteConfigLoader>().ToSingleton();
                        break;
                    case ConfigLoaderMode.Local:
                        gameContext.injectionBinder.Bind<IConfigLoader>().To<ResourcesConfigLoader>().ToSingleton();
                        break;
                    case ConfigLoaderMode.Db:
                        gameContext.injectionBinder.Bind<IConfigLoader>().To<DbConfigLoader>().ToSingleton();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}