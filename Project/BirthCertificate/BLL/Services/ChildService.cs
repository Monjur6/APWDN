using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class ChildService
    {
        public static List<ChildinfoDTO> Get()
        {
            var data = DataAccessFactory.ChildDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Children_information, ChildinfoDTO>());
            var mapper = new Mapper(config);
            var groups = mapper.Map<List<ChildinfoDTO>>(data);
            return groups;

        }

        public static ChildinfoDTO Get(int id)
        {
            var data = DataAccessFactory.ChildDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Children_information, ChildinfoDTO>());
            var mapper = new Mapper(config);
            var group = mapper.Map<ChildinfoDTO>(data);
            return group;

        }

        public static ChildinfoDTO Add(ChildinfoDTO dto)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Children_information, ChildinfoDTO>();
                cfg.CreateMap<ChildinfoDTO, Children_information>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<Children_information>(dto);
            var result = DataAccessFactory.ChildDataAccess().Add(data);
            var redata = mapper.Map<ChildinfoDTO>(result);
            return redata;

        }



        public static bool Delete(int id)
        {
            var result = DataAccessFactory.ChildDataAccess().Delete(id);
            return result;
        }



        public static bool Update(ChildinfoDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ChildinfoDTO, Children_information>();
                cfg.CreateMap<Children_information, ChildinfoDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Children_information>(dto);
            var result = DataAccessFactory.ChildDataAccess().Update(data);
            return result;
        }

    }


     
    }


