using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JMOperations.Data;
using JMOperations.Models;
using Microsoft.AspNetCore.Components;


namespace JMOperations.Pages
{
    public class OperationsDataModel : ComponentBase
    {
        [Inject]
        protected OperationsService OperationService { get; set; }
        protected List<Operation> opsList = new();
        protected List<Operation> searchOpsData = new();
        public Operation ops = new();
        protected string SearchString { get; set; } = string.Empty;

    
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public int opsID { get; set; }

        protected string Title = "Add";
       
        protected List<Device> deviceList = new();
        protected override async Task OnInitializedAsync()
        {
            await GetOperations();
            await GetDeviceList();
        }

        protected async Task GetOperations()
        {
            opsList = await OperationService.GetOperationList();
            searchOpsData = opsList;
            Cancel();
        }

        protected void FilterOps()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                opsList = searchOpsData.Where(x => x.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                opsList = searchOpsData;
            }
        }

        //protected void DeleteConfirm(int opsID)
        //{
        //    ops = opsList.FirstOrDefault(x => x.OperationId == opsID);
        //}

        protected async Task DeleteOperation(int opsID)
        {
            await Task.Run(() =>
            {
                OperationService.Delete(opsID);
            });
            await GetOperations();
        }

        public void ResetSearch()
        {
            SearchString = string.Empty;
            opsList = searchOpsData;
        }
        protected override async Task OnParametersSetAsync()
        {
            if (opsID != 0)
            {
                Title = "Edit";
                ops = await OperationService.Details(opsID);
            }
        }

        protected async Task GetDeviceList()
        {
            deviceList = await OperationService.GetDevices();
        }

        protected async Task SaveOperation()
        {
            if (ops.OperationId != 0)
            {
                await Task.Run(() =>
                {
                    OperationService.Edit(ops);
                });
            }
            else
            {
                await Task.Run(() =>
                {
                    OperationService.Create(ops);
                });
            }
            Cancel();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/fetchoperations");
        }
    }
}
