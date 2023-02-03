using JMOperations.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JMOperations.Models;
using JMOperations.Interface;

using Microsoft.EntityFrameworkCore;
using JMOperations.Context;

namespace JMOperations.DataContext
{
    public class OperationsDataAccessLayer : IOperations
    {
        private JMOpsDataContext db;

        public OperationsDataAccessLayer(JMOpsDataContext _db)
        {
            db = _db;
        }

        //To Get all employees details     
        public List<Operation> GetAllOperations()
        {
            try
            {
                return db.Operations.AsNoTracking().Select(x=> new Operation { 

                  OperationId=  x.OperationId,
                  Name= x.Name,
                  ImageData=  x.ImageData,
                  OperationOrder=  x.OperationOrder,
                  Device = db.Devices.Where(d => d.DeviceId == x.DeviceId).FirstOrDefault()

                }).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record       
        public void AddOperation(Operation operation)
        {
            try
            {
                db.Operations.Add(operation);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee      
        public void UpdateOperation(Operation operation)
        {
            try
            {
                db.Entry(operation).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee      
        public Operation GetOperationData(int id)
        {
            try
            {
                Operation? operation = db.Operations.Find(id);

                if (operation != null)
                {
                    db.Entry(operation).State = EntityState.Detached;
                    return operation;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee      
        public void DeleteOperation(int id)
        {
            try
            {
                Operation? operation = db.Operations.Find(id);

                if (operation != null)
                {
                    db.Operations.Remove(operation);
                }
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // To get the list of Cities
        public List<Device> GetDeviceData()
        {
            try
            {
                return db.Devices.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
