using AutoMapper;
using School.Application.Mappers;
using School.Domain.ModelsDto;
using School.Presentaion.Models;

namespace School.Unit.Tests.School.Application.Mappers
{
    public class SchoolMapper_Tests
    {
        MapperConfiguration mapperConfiguration;

        public SchoolMapper_Tests()
        {
            mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<SchoolMapper>());
        }

        [Fact]
        public void SchoolMapperProfileIsValid()
        {
            mapperConfiguration.AssertConfigurationIsValid();
        }

        [Fact]
        public void CanMapFromUserDtoToUser()
        {
            UserDto userDto = new UserDto()
            {
                Name = "Joe",
                Surname = "Black"
            };
            var mapper = mapperConfiguration.CreateMapper();
            var result = mapper.Map<User>(userDto);
            Assert.Equal("Joe Black", result.FullName);
        }
    }
}
