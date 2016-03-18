using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRP_SampleLager
{
    public interface IRepository<T>
    {
        void Select(T viewModel);
        void Insert(T viewModel);
        void Update(T viewModel);
        void Delete(T viewModel);
        void findById(T viewModel);
    }
}
