using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Compartilhado.Ioc.cs
{
    public interface IoC
    {
        T Get<T>();
    }
}
