

namespace ebus.Auditing.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="AuditLogAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class AuditLogPermissions
	{
		/// <summary>
		/// AuditLog权限节点
		///</summary>
		public const string Node = "Pages.AuditLog";

		/// <summary>
		/// AuditLog查询授权
		///</summary>
		public const string Query = "Pages.AuditLog.Query";

		/// <summary>
		/// AuditLog创建权限
		///</summary>
		public const string Create = "Pages.AuditLog.Create";

		/// <summary>
		/// AuditLog修改权限
		///</summary>
		public const string Edit = "Pages.AuditLog.Edit";

		/// <summary>
		/// AuditLog删除权限
		///</summary>
		public const string Delete = "Pages.AuditLog.Delete";

        /// <summary>
		/// AuditLog批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.AuditLog.BatchDelete";

		/// <summary>
		/// AuditLog导出Excel
		///</summary>
		public const string ExportExcel="Pages.AuditLog.ExportExcel";

		 
		 
         
    }

}

