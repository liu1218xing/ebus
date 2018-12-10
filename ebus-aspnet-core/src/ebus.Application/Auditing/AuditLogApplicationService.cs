
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using ebus.Auditing;
using ebus.Auditing.Dtos;
using ebus.Auditing.DomainService;
using ebus.Auditing.Authorization;
using Abp.Auditing;
using ebus.Authorization.Users;

namespace ebus.Auditing
{
    /// <summary>
    /// AuditLog应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class AuditLogAppService : ebusAppServiceBase, IAuditLogAppService
    {
        private readonly IRepository<AuditLog, long> _auditLogRepository;

        private readonly IAuditLogManager _entityManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly INamespaceStripper _namespaceStripper;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public AuditLogAppService(
        IRepository<AuditLog, long> auditLogRepository,
         IRepository<User, long> userRepository,
        IAuditLogManager entityManager,
        INamespaceStripper namespaceStripper
        )
        {
            _auditLogRepository = auditLogRepository; 
             _entityManager=entityManager;
            _userRepository = userRepository;
            _namespaceStripper = namespaceStripper;
        }


        /// <summary>
        /// 获取AuditLog的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(AuditLogPermissions.Query)] 
        public async Task<PagedResultDto<AuditLogListDto>> GetPaged(GetAuditLogsInput input)
		{
            var query = CreateAuditLogAndUsersQuery(input);
            //var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();


            var results = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var auditLogListDtos = ConvertToAuditLogListDtos(results);
            // var entityListDtos = ObjectMapper.Map<List<AuditLogListDto>>(entityList);
            //var entityListDtos =entityList.MapTo<List<AuditLogListDto>>();
            //return new PagedResultDto<AuditLogListDto>(resultCount, auditLogListDtos);
              return new PagedResultDto<AuditLogListDto>(count, auditLogListDtos);
		}

        private List<AuditLogListDto> ConvertToAuditLogListDtos(List<AuditLogAndUser> results)
        {
            var query = results.Select(
                result =>
                {
                    //var auditLogListDto = ObjectMapper.Map<AuditLogListDto>(result.AuditLog);
                    var auditLogListDto = ObjectMapper.Map<AuditLogListDto>(result.AuditLog);
                    auditLogListDto.UserName = result.User?.UserName;
                    auditLogListDto.ServiceName = _namespaceStripper.StripNameSpace(auditLogListDto.ServiceName);
                    return auditLogListDto;
                }).ToList();
            return query;
        }

        private IQueryable<AuditLogAndUser> CreateAuditLogAndUsersQuery(GetAuditLogsInput input)
        {
            var query = from auditLog in _auditLogRepository.GetAll()
                        join user in _userRepository.GetAll() on auditLog.UserId equals user.Id into userJoin
                        from joinedUser in userJoin.DefaultIfEmpty()
                        where auditLog.ExecutionTime >= input.StartDate && auditLog.ExecutionTime <= input.EndDate
                        select new AuditLogAndUser { AuditLog = auditLog, User = joinedUser };
            return query;

            
        }


        /// <summary>
        /// 通过指定id获取AuditLogListDto信息
        /// </summary>
        [AbpAuthorize(AuditLogPermissions.Query)] 
		public async Task<AuditLogListDto> GetById(EntityDto<long> input)
		{
			var entity = await _auditLogRepository.GetAsync(input.Id);

		    return entity.MapTo<AuditLogListDto>();
		}

		/// <summary>
		/// 获取编辑 AuditLog
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(AuditLogPermissions.Create,AuditLogPermissions.Edit)]
		public async Task<GetAuditLogForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetAuditLogForEditOutput();
            AuditLogEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _auditLogRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<AuditLogEditDto>();

				//auditLogEditDto = ObjectMapper.Map<List<auditLogEditDto>>(entity);
			}
			else
			{
				editDto = new AuditLogEditDto();
			}

			output.AuditLog = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改AuditLog的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(AuditLogPermissions.Create,AuditLogPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateAuditLogInput input)
		{

			if (input.AuditLog.Id.HasValue)
			{
				await Update(input.AuditLog);
			}
			else
			{
				await Create(input.AuditLog);
			}
		}


		/// <summary>
		/// 新增AuditLog
		/// </summary>
		[AbpAuthorize(AuditLogPermissions.Create)]
		protected virtual async Task<AuditLogEditDto> Create(AuditLogEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <AuditLog>(input);
            var entity=input.MapTo<AuditLog>();
			

			entity = await _auditLogRepository.InsertAsync(entity);
			return entity.MapTo<AuditLogEditDto>();
		}

		/// <summary>
		/// 编辑AuditLog
		/// </summary>
		[AbpAuthorize(AuditLogPermissions.Edit)]
		protected virtual async Task Update(AuditLogEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _auditLogRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _auditLogRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除AuditLog信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(AuditLogPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _auditLogRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除AuditLog的方法
		/// </summary>
		[AbpAuthorize(AuditLogPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _auditLogRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出AuditLog为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


