using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JMOperations.Data;
using JMOperations.Models;
using Microsoft.AspNetCore.Components;


namespace JMOperations.Pages
{
    public class ManageOpsDataModel : ComponentBase
    {
        [Inject]
        protected OperationsService OperationService { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public int opsID { get; set; }

        protected string Title = "Add";
        public Operation ops = new();
        protected List<Device> deviceList = new();

        protected override async Task OnInitializedAsync()
        {
            await GetDeviceList();
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
            UrlNavigationManager.NavigateTo("/fetchoperation");
        }
    }
}
