
using Abp.Auditing;
using AutoMapper;
using ebus.Auditing;
using ebus.Auditing.Dtos;

namespace ebus.Auditing.Mapper
{

	/// <summary>
    /// 配置AuditLog的AutoMapper
    /// </summary>
	internal static class AuditLogMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <AuditLog,AuditLogListDto>();
            configuration.CreateMap<AuditLogListDto, AuditLog>();

            //configuration.CreateMap <AuditLogEditDto,AuditLog>();
            //configuration.CreateMap <AuditLog,AuditLogEditDto>();

        }
	}
}
