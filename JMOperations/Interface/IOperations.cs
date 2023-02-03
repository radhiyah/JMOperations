using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JMOperations.Models;

namespace JMOperations.Interface
{
    public interface IOperations
    {
        public List<Operation> GetAllOperations();
        public void AddOperation(Operation employee);
        public void UpdateOperation(Operation employee);
        public Operation GetOperationData(int id);
        public void DeleteOperation(int id);
        public List<Device> GetDeviceData();
    }
}
