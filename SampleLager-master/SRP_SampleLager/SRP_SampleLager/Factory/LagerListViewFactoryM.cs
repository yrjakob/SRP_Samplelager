using System;

namespace SRP_SampleLager
{
    public class LagerListViewFactoryM : IFactory<ILagerListViewModel>
    {
        public ILagerListViewModel create()
        {
            return new LagerListViewModel();
        }
        public ILagerListViewModel create(object param)
        {
            return new LagerListViewModel() { RaumId = int.Parse(param.ToString()) };
        }
    }
}
