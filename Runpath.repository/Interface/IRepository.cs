using System;
using System.Collections.Generic;
using System.Text;

namespace Runpath.repository.Interface
{
    public interface IRepository<T> where T :class
    {
        List<T> GetAll(string url);

    }
}
