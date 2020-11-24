using AntDesign;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.FeatureManagement.Blazor.Components;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Blazor;

namespace MyAbp.Blazor.Pages.tenant
{
    public partial class TenantManagementBase:AntDesignCrudPageBase<ITenantAppService, TenantDto, Guid, GetTenantsInput, TenantCreateDto, TenantUpdateDto>
    {
        protected const string FeatureProviderName = "T";

        protected bool ShouldShowEntityActions;
        protected bool HasManageConnectionStringsPermission;
        protected bool HasManageFeaturesPermission;

        protected FeatureManagementModal FeatureManagementModal;

        protected bool ManageConnectionStringModal;

        protected TenantInfoModel TenantInfo;

        public TenantManagementBase()
        {
            ObjectMapperContext = typeof(AbpTenantManagementBlazorModule);

            CreatePolicyName = TenantManagementPermissions.Tenants.Create;
            UpdatePolicyName = TenantManagementPermissions.Tenants.Update;
            DeletePolicyName = TenantManagementPermissions.Tenants.Delete;

            TenantInfo = new TenantInfoModel();
        }

        protected override async Task SetPermissionsAsync()
        {
            await base.SetPermissionsAsync();

            HasManageConnectionStringsPermission = await AuthorizationService.IsGrantedAsync(TenantManagementPermissions.Tenants.ManageConnectionStrings);
            HasManageFeaturesPermission = await AuthorizationService.IsGrantedAsync(TenantManagementPermissions.Tenants.ManageFeatures);

            ShouldShowEntityActions = HasUpdatePermission ||
                                      HasDeletePermission ||
                                      HasManageConnectionStringsPermission ||
                                      HasManageFeaturesPermission;
        }

        protected virtual async Task OpenEditConnectionStringModalAsync(Guid id)
        {
            var tenantConnectionString = await AppService.GetDefaultConnectionStringAsync(id);

            TenantInfo = new TenantInfoModel
            {
                Id = id,
                DefaultConnectionString = tenantConnectionString,
                UseSharedDatabase = tenantConnectionString.IsNullOrWhiteSpace()
            };

            //ManageConnectionStringModal.Show();
            ManageConnectionStringModal = true;
        }

        protected virtual Task CloseEditConnectionStringModal()
        {
            //ManageConnectionStringModal.Hide();
            ManageConnectionStringModal = false;
            return Task.CompletedTask;
        }

        protected virtual async Task UpdateConnectionStringAsync()
        {
            await CheckPolicyAsync(TenantManagementPermissions.Tenants.ManageConnectionStrings);

            if (TenantInfo.UseSharedDatabase || TenantInfo.DefaultConnectionString.IsNullOrWhiteSpace())
            {
                await AppService.DeleteDefaultConnectionStringAsync(TenantInfo.Id);
            }
            else
            {
                await AppService.UpdateDefaultConnectionStringAsync(TenantInfo.Id, TenantInfo.DefaultConnectionString);
            }

            //ManageConnectionStringModal.Hide();
            ManageConnectionStringModal = false;
        }
    }

    public class TenantInfoModel
    {
        public Guid Id { get; set; }

        public bool UseSharedDatabase { get; set; }

        public string DefaultConnectionString { get; set; }
    }
}
