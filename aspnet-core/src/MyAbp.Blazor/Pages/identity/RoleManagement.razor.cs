using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MyAbp.Blazor.Pages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.PermissionManagement.Blazor.Components;

namespace MyAbp.Blazor.Pages.identity
{
    public partial class RoleManagementBase : AntDesignCrudPageBase<IIdentityRoleAppService, IdentityRoleDto, Guid, PagedAndSortedResultRequestDto, IdentityRoleCreateDto, IdentityRoleUpdateDto>
    {
        protected const string PermissionProviderName = "R";

        protected PermissionManagementModal PermissionManagementModal;

        protected bool HasManagePermissionsPermission { get; set; }

        protected bool ShouldShowEntityActions { get; set; }

        public RoleManagementBase()
        {
            ObjectMapperContext = typeof(AbpIdentityBlazorModule);

            CreatePolicyName = IdentityPermissions.Roles.Create;
            UpdatePolicyName = IdentityPermissions.Roles.Update;
            DeletePolicyName = IdentityPermissions.Roles.Delete;
        }
        protected override async Task SetPermissionsAsync()
        {
            await base.SetPermissionsAsync();

            HasManagePermissionsPermission = await AuthorizationService.IsGrantedAsync(
                IdentityPermissions.Roles.ManagePermissions
            );

            ShouldShowEntityActions = HasUpdatePermission ||
                                      HasDeletePermission ||
                                      HasManagePermissionsPermission;
        }
    }
}
