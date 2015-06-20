using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using Organization.BusinessLogic;
using Organization.BusinessLogic.Validators;
using Organization.Contract.BusinessLogic;
using Organization.Contract.DAL;
using Organization.Core;
using Organization.DAL;

namespace Organization.CastleWindsor
{
    public class AdminInstaller : IWindsorInstaller
    {
        private const string WebAssemblyName = "Orgainzation.Web";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(WebAssemblyName)
                .BasedOn<IController>()
                .LifestyleTransient()
                .Configure(x => x.Named(x.Implementation.Name)));

            container.Register(
                Component.For<IWindsorContainer>().Instance(container),
                Component.For<WindsorControllerFactory>());

            container.Register(
                Component.For(typeof(IDataAccessLayer<Department>))
                .ImplementedBy(typeof(DepartmentDal))
                .LifestyleTransient());
            container.Register(
                Component.For(typeof(IDataAccessLayer<Employee>))
                .ImplementedBy(typeof(EmployeeDal))
                .LifestyleTransient());
            container.Register(
                 Component.For(typeof(IDataAccessLayer<Customer>))
                 .ImplementedBy(typeof(CustomerDal))
                 .LifestyleTransient());
            container.Register(
                Component.For(typeof(IDataAccessLayer<Equipment>))
                .ImplementedBy(typeof(EquipmentDal))
                .LifestyleTransient());
            container.Register(
                Component.For(typeof(IDataAccessLayer<Core.Contract>))
                .ImplementedBy(typeof(ContractDal))
                .LifestyleTransient());
            container.Register(
                Component.For(typeof(IDataAccessLayer<EquipmentContract>))
                .ImplementedBy(typeof(EquipmentContractDal))
                .LifestyleTransient());

            container.Register(Component.For(typeof(IManager<>)).ImplementedBy(typeof(Manager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IValidator<Department>))
                    .ImplementedBy(typeof(DepartmentValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<Employee>))
                    .ImplementedBy(typeof(EmployeeValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<Customer>))
                    .ImplementedBy(typeof(CustomerValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<Core.Contract>))
                    .ImplementedBy(typeof(ContractValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<Equipment>))
                    .ImplementedBy(typeof(EquipmentValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<EquipmentContract>))
                    .ImplementedBy(typeof(EquipmentContractValidator))
                    .LifestylePerWebRequest());
             
            container.Register(
                 Component.For(typeof(ILogic))
                    .ImplementedBy(typeof(Logic))
                    .LifestylePerWebRequest());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }
    }
}
