

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using ebus.Authorization;

namespace ebus.Auditing.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="AuditLogPermissions" /> for all permission names. AuditLog
    ///</summary>
    public class AuditLogAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public AuditLogAuthorizationProvider()
		{

		}

        public AuditLogAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public AuditLogAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了AuditLog 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(AuditLogPermissions.Node , L("AuditLog"));
			entityPermission.CreateChildPermission(AuditLogPermissions.Query, L("QueryAuditLog"));
			entityPermission.CreateChildPermission(AuditLogPermissions.Create, L("CreateAuditLog"));
			entityPermission.CreateChildPermission(AuditLogPermissions.Edit, L("EditAuditLog"));
			entityPermission.CreateChildPermission(AuditLogPermissions.Delete, L("DeleteAuditLog"));
			entityPermission.CreateChildPermission(AuditLogPermissions.BatchDelete, L("BatchDeleteAuditLog"));
			entityPermission.CreateChildPermission(AuditLogPermissions.ExportExcel, L("ExportExcelAuditLog"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ebusConsts.LocalizationSourceName);
		}
    }
}