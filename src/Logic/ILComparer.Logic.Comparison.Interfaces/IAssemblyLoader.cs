using System;
using System.Collections.Generic;
using ILComparer.Logic.Dtos;

namespace ILComparer.Logic.Comparison.Interfaces
{
    public interface IAssemblyLoader<TAssemblySource>
        where TAssemblySource : IAssemblySource
    {
        IEnumerable<IAssemblyDto> Load(TAssemblySource assemblySource);
    }
}
