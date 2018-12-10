using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ebus.Auditing.Authorization;
using ebus.Auditing.Mapper;
using ebus.Authorization;

namespace ebus
{
    [DependsOn(
        typeof(ebusCoreModule),
        typeof(AbpAutoMapperModule))]
    public class ebusApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ebusAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<AuditLogAuthorizationProvider>();
            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // XXXMapper.CreateMappers(configuration);
                AuditLogMapper.CreateMappings(configuration);

            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ebusApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
