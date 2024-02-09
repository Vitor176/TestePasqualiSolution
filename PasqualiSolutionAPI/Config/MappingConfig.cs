using AutoMapper;
using ToDoListAPI.Data.ValueObjects;
using ToDoListAPI.Model;

namespace ToDoListAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<RegisterPFVO, RegisterPF>();
                config.CreateMap<RegisterPF, RegisterPFVO>();
            });
            return mappingConfig;
        }
    }
}
