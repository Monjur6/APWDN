using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class HospitalService
    {
        public static List<HospitalDTO> Get()
        {
            var dbdata = DataAccessFactory.HospitalDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Hosital_information, HospitalDTO>());
            var mapper = new Mapper(config);
            var groups = mapper.Map<List<HospitalDTO>>(dbdata);
            return groups;


        }
        public static HospitalDTO Get(int id)
        {
            var dbdata = DataAccessFactory.HospitalDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Hosital_information, HospitalDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<HospitalDTO>(dbdata);
            return data;

        }
        public static bool Add(HospitalDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HospitalDTO, Hosital_information>();
                cfg.CreateMap<Hosital_information, HospitalDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Hosital_information>(dto);
            var result = DataAccessFactory.HospitalDataAccess().Add(data);
            return result;
        }



        public static bool Delete(int id)
        {

            var result = DataAccessFactory.HospitalDataAccess().Delete(id);
            return result;
        }


        public static bool Update(HospitalDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HospitalDTO, Hosital_information>();
                cfg.CreateMap<Hosital_information, HospitalDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Hosital_information>(dto);
            var result = DataAccessFactory.HospitalDataAccess().Update(data);
            return result;




        }
    }
}

