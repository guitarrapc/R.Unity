using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RUnity.Generator.Targets
{
    public interface ITarget
    {
        string ClassName { get; }
        string Generate();
    }
}
