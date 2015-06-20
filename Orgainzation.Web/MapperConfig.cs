using AutoMapper;
using Organization.Core;
using Orgainzation.Web.Models;

namespace Orgainzation.Web
{
    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Department, DepartmentViewModel>();
            Mapper.CreateMap<DepartmentViewModel, Department>();
            Mapper.CreateMap<EmployeeViewModel, Employee>();
            Mapper.CreateMap<Employee, EmployeeViewModel>();
            Mapper.CreateMap<CustomerViewModel, Customer>();
            Mapper.CreateMap<Customer, CustomerViewModel>();
            Mapper.CreateMap<Contract, ContractViewModel>();
            Mapper.CreateMap<ContractViewModel, Contract>();
            Mapper.CreateMap<Equipment, EquipmentViewModel>();
            Mapper.CreateMap<EquipmentViewModel, Equipment>();
            Mapper.CreateMap<EquipmentContractViewModel, EquipmentContract>();
            Mapper.CreateMap<EquipmentContract, EquipmentContractViewModel>();
        }
    }
}