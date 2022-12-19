using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepositoryy<T, ID>
    {
        void Add(T e);
        List<T> Get();
        T Get(ID id);
        void Edit(T e);
        void Delete(ID id);
    }
}
