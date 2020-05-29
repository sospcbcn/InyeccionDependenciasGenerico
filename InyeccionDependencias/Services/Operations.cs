using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InyeccionDependencias.Services
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }

    public class Operation : IOperationScoped, IOperationSingleton, IOperationSingletonInstance, IOperationTransient
    {
        public Operation()
        {
            _guid = Guid.NewGuid();
        }
        public Operation(Guid guid)
        {
            _guid = guid;
        }

        private Guid _guid;
        public Guid OperationId { get { return _guid; } }
    }

   
    public interface IOperationTransient : IOperation
    {
    }
    public interface IOperationScoped : IOperation
    {
    }
    public interface IOperationSingleton : IOperation
    {
    }
    public interface IOperationSingletonInstance : IOperation
    {
    }

}
