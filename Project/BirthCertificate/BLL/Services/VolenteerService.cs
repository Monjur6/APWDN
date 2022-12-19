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
    public class VolenteerService
    {
        public static List<VolenteerDTO> Get()
        {
            var dbdata = DataAccessFactory.VolenteerDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VolInfo, VolenteerDTO>());
            var mapper = new Mapper(config);
            var rdata = mapper.Map<List<VolenteerDTO>>(dbdata);
            return rdata;


        }
        public static VolenteerDTO Get(int id)
        {
            var dbdata = DataAccessFactory.VolenteerDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VolInfo, VolenteerDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<VolenteerDTO>(dbdata);
            return data;

        }
        public static bool Add(VolenteerDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VolenteerDTO, VolInfo>();
                cfg.CreateMap<VolInfo, VolenteerDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<VolInfo>(dto);
            var result = DataAccessFactory.VolenteerDataAccess().Add(data);
            return result;
        }
        public static bool Delete(int id)
        {

            var result = DataAccessFactory.VolenteerDataAccess().Delete(id);
            return result;
        }
        public static bool Update(VolenteerDTO dto)
        {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<VolenteerDTO, VolInfo>();
                cfg.CreateMap<VolInfo, VolenteerDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<VolInfo>(dto);
            var result = DataAccessFactory.VolenteerDataAccess().Update(data);
            return result;

        }
    }
}
