using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class KundeFactory : IFactory<KundeView>
    {
        private readonly IKundeModel _ViewModel;
        public KundeFactory(IKundeModel ViewModel)
        {
            if (ViewModel == null)
                throw new ArgumentNullException("ViewModel");

            _ViewModel = ViewModel;
        }

        public KundeView create()
        {
            return new KundeView { DataContext = _ViewModel };

        }
    }
}
