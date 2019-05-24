using System;
using System.Collections.Generic;
using System.Text;

namespace ICS_Project.Bl.Interfaces
{
    interface IRepository<T>
    {
        T GetById(Guid id);
        T Insert(T item);
        void Update(T item);
        void Remove(Guid id);
    }
}
