
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using ebus.Auditing.Dtos;
using ebus.Auditing;

namespace ebus.Auditing
{
    /// <summary>
    /// AuditLog应用层服务的接口方法
    ///</summary>
    public interface IAuditLogAppService : IApplicationService
    {
        /// <summary>
		/// 获取AuditLog的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<AuditLogListDto>> GetPaged(GetAuditLogsInput input);


		/// <summary>
		/// 通过指定id获取AuditLogListDto信息
		/// </summary>
		Task<AuditLogListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetAuditLogForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改AuditLog的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateAuditLogInput input);


        /// <summary>
        /// 删除AuditLog信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除AuditLog
        /// </summary>
        Task BatchDelete(List<long> input);


		/// <summary>
        /// 导出AuditLog为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
