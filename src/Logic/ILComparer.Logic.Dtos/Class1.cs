using System;
using System.Collections.Immutable;
using System.Reflection;

namespace ILComparer.Logic.Dtos
{
    public interface IAssemblySource
    {
    }

    public class FileAssemblySource
        : IAssemblySource
    {
        public FileAssemblySource(string sourcePath)
        {
            SourcePath = sourcePath;
        }

        public string SourcePath { get; }
    }

    public interface IAssemblyDto
    {
        AssemblyName AssemblyName { get; }

        IAssemblySource Source { get; }

        IImmutableList<INamespace> Namespaces { get; }
    }

    public class AssemblyDto
        : IAssemblyDto
    {
        public AssemblyDto
        (
            IAssemblySource source,
            AssemblyName assemblyName,
            IImmutableList<INamespace> namespaces
        )
        {
            Source = source;
            AssemblyName = assemblyName;
            Namespaces = namespaces;
        }

        public AssemblyName AssemblyName { get; }

        public IAssemblySource Source { get; }

        public IImmutableList<INamespace> Namespaces { get; }
    }

    public interface INamespace
    {
        IImmutableList<NamespaceSegment> Segments { get; }

        IImmutableList<ITypeDto> Types { get; }
    }

    public class Namespace
        : INamespace
    {
        public Namespace(IImmutableList<NamespaceSegment> segments, IImmutableList<ITypeDto> types)
        {
            Segments = segments;
            Types = types;
        }

        public IImmutableList<NamespaceSegment> Segments { get; }

        public IImmutableList<ITypeDto> Types { get; }
    }

    public class NamespaceSegment
    {
        public NamespaceSegment(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public interface ITypeDto
    {
        string Name { get; }
    }

    public class ClassDto
        : ITypeDto
    {
        public ClassDto
        (
            string name,
            IImmutableList<ITypeDto> subTypes,
            IImmutableList<IMemberDto> members,
            IImmutableList<InterfaceDto> implementedInterfaces,
            ClassDto baseType
        )
        {
            Name = name;
            SubTypes = subTypes;
            Members = members;
            ImplementedInterfaces = implementedInterfaces;
            BaseType = baseType;
        }

        public string Name { get; }

        public IImmutableList<ITypeDto> SubTypes { get; }

        public IImmutableList<IMemberDto> Members { get; }

        public IImmutableList<InterfaceDto> ImplementedInterfaces { get; }

        public ClassDto BaseType { get; }
    }

    public class InterfaceDto
        : ITypeDto
    {
        public InterfaceDto(string name, IImmutableList<IMemberDto> members)
        {
            Name = name;
            Members = members;
        }

        public string Name { get; }

        public IImmutableList<IMemberDto> Members { get; }
    }

    public class StructDto
        : ITypeDto
    {
        public StructDto(string name, IImmutableList<IMemberDto> members)
        {
            Name = name;
            Members = members;
        }

        public string Name { get; }

        public IImmutableList<IMemberDto> Members { get; }
    }

    public class EnumDto
        : ITypeDto
    {
        public EnumDto(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public interface IMemberDto
    {
        ITypeDto Owner { get; }

        ITypeDto ReturnType { get; }

        string Name { get; }

        bool IsPublic { get; }

        bool IsInternal { get; }

        bool IsProtected { get; }

        bool IsPrivate { get; }

        bool IsStatic { get; }
    }

    public abstract class MemberDto
        : IMemberDto
    {
        protected MemberDto
        (
            ITypeDto owner,
            ITypeDto returnType,
            string name,
            bool isPublic,
            bool isInternal,
            bool isProtected,
            bool isPrivate,
            bool isStatic
        )
        {
            Owner = owner;
            ReturnType = returnType;
            Name = name;
            IsPublic = isPublic;
            IsInternal = isInternal;
            IsProtected = isProtected;
            IsPrivate = isPrivate;
            IsStatic = isStatic;
        }

        public ITypeDto Owner { get; }

        public ITypeDto ReturnType { get; }

        public string Name { get; }

        public bool IsPublic { get; }

        public bool IsInternal { get; }

        public bool IsProtected { get; }

        public bool IsPrivate { get; }

        public bool IsStatic { get; }
    }

    public class MethodDto
        : MemberDto
    {
        public MethodDto(ITypeDto owner, ITypeDto returnType,
                 string name,
                 bool isPublic,
                 bool isInternal,
                 bool isProtected,
                 bool isPrivate,
                 bool isStatic
        ) : base(owner, returnType,
                 name,
                 isPublic,
                 isInternal,
                 isProtected,
                 isPrivate,
                 isStatic
        )
        {
        }
    }

    public interface IParameterDto
    {
        ITypeDto ParameterType { get; }

        string Name { get; }
    }

    public class PropertyDto
        : MemberDto
    {
        public PropertyDto
        (
            ITypeDto owner,
            ITypeDto returnType,
            string name,
            bool isPublic,
            bool isInternal,
            bool isProtected,
            bool isPrivate,
            bool isStatic,
            bool hasGetter,
            bool hasSetter
        )
            : base
        (
            owner,
            returnType,
            name,
            isPublic,
            isInternal,
            isProtected,
            isPrivate,
            isStatic
        )
        {
            HasGetter = hasGetter;
            HasSetter = hasSetter;
        }

        public bool HasGetter { get; }

        public bool HasSetter { get; }
    }
}
