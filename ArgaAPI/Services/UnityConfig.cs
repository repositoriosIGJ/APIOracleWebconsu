﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using ArgaAPI.Business.Contrato;
using ArgaAPI.Business.Implementacion;
using ArgaAPI.Controllers;
using ArgaAPI.Repositorio.Contrato;
using ArgaAPI.Repositorio.Implementacion;
using Microsoft.Practices.Unity;

namespace ArgaAPI.Services
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Registrar dependencias aquí
            container.RegisterType<ITipoSocietarioBusiness, TipoSocietarioBusiness>(new HierarchicalLifetimeManager());
            container.RegisterType<ITipoTramiteBusiness, TipoTramiteBusiness>(new HierarchicalLifetimeManager());
            container.RegisterType<IExpedienteBusiness, ExpedienteBusiness>(new HierarchicalLifetimeManager());
            container.RegisterType<ITramiteBusiness, TramiteBusiness>(new HierarchicalLifetimeManager());
            container.RegisterType<IDestinoBusiness, DestinoBusiness>(new HierarchicalLifetimeManager());
            container.RegisterType<ITipoSocietarioReposity, TipoSocietarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITipoTramiteRepository, TipoTramiteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IExpedienteRepository, ExpedienteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITramiteRepository, TramiteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDestinoRepository, DestinoRepository>(new HierarchicalLifetimeManager());
             
            // Registrar controladores
             container.RegisterType<TipoSocietarioController>();
             container.RegisterType<TipoTramiteController>();
             container.RegisterType<ExpedienteController>();
             container.RegisterType<TramiteController>();
             container.RegisterType<DestinoController>();

            // Configurar DependencyResolver manualmente
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }

    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }

}