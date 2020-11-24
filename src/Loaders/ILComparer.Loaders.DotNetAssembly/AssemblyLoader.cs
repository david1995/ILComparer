using System;
using System.Collections.Generic;
using System.Reflection;
using ILComparer.Logic.Comparison.Interfaces;
using ILComparer.Logic.Dtos;

namespace ILComparer.Loaders.DotNetAssembly
{
    public class AssemblyLoader
        : IAssemblyLoader<FileAssemblySource>
    {
        public IEnumerable<IAssemblyDto> Load(FileAssemblySource assemblySource)
        {
            string assemblySourcePath = assemblySource.SourcePath;

            using var metadataLoadContext = new MetadataLoadContext(new PathAssemblyResolver());

            metadataLoadContext.LoadFromAssemblyPath(assemblySourcePath);


            throw new NotImplementedException();
        }
    }
}
