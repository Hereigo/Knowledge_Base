﻿using Autofac;

namespace SQL_EF_Autofac_Net462
{
    public static class AutofacConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();



            //      builder.RegisterType<BaseRepository<T>>().As<IBaseRepository<T>>();
            //      
            //      builder.RegisterType<DataAccess>().As<IDataAccess>();



            // Possible to load dependencies from another assemblies :

            // builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("nameof(LoadingAssemblyName)"))
            //     .Where(t => t.Namespace.Contains("LookingForSpecificPath"))
            //     .As(t => System.Array.Find(t.GetInterfaces(), i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
