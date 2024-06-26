﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepositories
{
    public interface IAllRepos<T>
    {
        IEnumerable<T> GetAllItems();
        bool CreateItem(T item);
        bool UpdateItem(T item);
        bool DeleteItem(T item);
        T GetByID(Guid id);

    }
}
