using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace SRP_SampleLager
{
    public interface IFactory<T> where T : class
    {
        T create();
        T create(object param);
    }
}
