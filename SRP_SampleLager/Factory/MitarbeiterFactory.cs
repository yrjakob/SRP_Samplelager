using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_SampleLager
{
    public class MitarbeiterFactory : IFactory<MitarbeiterView>
    {
        private readonly IMitarbeiterModel _ViewModel;
        public MitarbeiterFactory(IMitarbeiterModel ViewModel)
        {
            if (ViewModel == null)
                throw new ArgumentNullException("ViewModel");

            _ViewModel = ViewModel;
        }

        public MitarbeiterView create()
        {
            return new MitarbeiterView { DataContext = _ViewModel };

        }
    }
}
