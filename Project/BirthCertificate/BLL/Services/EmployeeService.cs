using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> Get()
        {
            var dbdata = DataAccessFactory.EmployeeDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<EmployeeDTO>>(dbdata);
            return data;
        }

        public static EmployeeDTO Get(string id)
        {
            var dbdata = DataAccessFactory.EmployeeDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<EmployeeDTO>(dbdata);
            return data;

        }

        public static EmployeeDTO Add(EmployeeDTO dto)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<EmployeeDTO, Employee>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<Employee>(dto);
            var result = DataAccessFactory.EmployeeDataAccess().Add(data);
            var redata = mapper.Map<EmployeeDTO>(result);
            return redata;


        }

        public static bool Delete(string id)
        {

            var result = DataAccessFactory.EmployeeDataAccess().Delete(id);
            return result;
        }

        public static bool Update(EmployeeDTO dto)
        {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Employee>(dto);
            var result = DataAccessFactory.EmployeeDataAccess().Update(data);
            return result;

        }
        //public List<EmployeeDTO> Get()
        //{
        //    var dbdata = DataAccessFactory.UserDataAccess().Get();
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeService, EmployeeDTO>());
        //    var mapper = new Mapper(config);
        //    var rdata = mapper.Map<List<EmployeeDTO>>(dbdata);
        //    return rdata;



        //}
        //public static EmployeeDTO Get(int id)
        //{
        //    var dbdata = DataAccessFactory.GroupDataAccess().Get(id);
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeService, EmployeeDTO>());
        //    var mapper = new Mapper(config);
        //    var data = mapper.Map<EmployeeDTO>(dbdata);
        //    return data;

        //}
        //public EmployeeDTO Add(EmployeeDTO dto)
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<EmployeeService, EmployeeDTO>();
        //        cfg.CreateMap<EmployeeDTO, EmployeeService>();
        //    });
        //    var mapper = new Mapper(config);
        //    var data = mapper.Map<EmployeeDTO>(dto);
        //    var result = DataAccessFactory.GroupDataAccess().Add(default);
        //    var rdata = mapper.Map<EmployeeDTO>(result);
        //    return rdata;
        //}


        ////public static EmployeeDTO Delete(EmployeeDTO dto)
        ////{
        ////    var config = new MapperConfiguration(cfg =>
        ////    {
        ////        cfg.CreateMap<EmployeeService, EmployeeDTO>();
        ////        cfg.CreateMap<EmployeeService, EmployeeDTO>();
        ////    });
        ////    var mapper = new Mapper(config);
        ////    var data = mapper.Map<EmployeeDTO>(dto);
        ////    var result = DataAccessFactory.GroupDataAccess().Delete(default);
        ////    var rdata = mapper.Map<EmployeeDTO>(result);
        ////    return rdata;
        ////}

    }
}
