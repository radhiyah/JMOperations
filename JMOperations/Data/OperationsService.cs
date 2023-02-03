using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JMOperations.Interface;
using JMOperations.Models;

namespace JMOperations.Data
{
    public class OperationsService
    {
        private readonly IOperations objops;

        public OperationsService(IOperations _objops)
        {
            objops = _objops;
        }

        public Task<List<Operation>> GetOperationList()
        {
            return Task.FromResult(objops.GetAllOperations());
        }

        public void Create(Operation operation)
        {
            objops.AddOperation(operation);
        }
        public Task<Operation> Details(int id)
        {
            return Task.FromResult(objops.GetOperationData(id));
        }

        public void Edit(Operation operation)
        {
            objops.UpdateOperation(operation);
        }

        public void Delete(int id)
        {
            objops.DeleteOperation(id);
        }
        public Task<List<Device>> GetDevices()
        {
            return Task.FromResult(objops.GetDeviceData());
        }
    }
}
