using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sane.Semantics
{
    public class BaseType
    {
        public string Name { get; protected set; }
        public IList<BaseType> Parameters { get; protected set; }
        
        public BaseType(string name, params BaseType[] types)
        {
            Name = name;
            Parameters =  new List<BaseType>(types);
        }        
        
        public override string ToString()
        {
            var pars = string.Join(", ", Parameters.Select(par => par.ToString()));
            return $"{Name}({pars})";
        }
    }


    public class ArrayType : BaseType
    {
        public ArrayType(BaseType t) : base("Array", t)
        {
        }

        public override string ToString()
        {            
            return $"[{Parameters.First()}]";
        }
    }

    public class FunctionType : BaseType
    {
        public FunctionType(string name, BaseType arg, BaseType result) : base(name, arg, result)
        {
        }
        
        public override string ToString()
        {            
            return $"{Parameters.First()} -> {Parameters[1]}]";
        }
    }
}