using AutoMapper;
using OnlineExamSystem.Class;
using OnlineExamSystem.Student;
using OnlineExamSystem.Test;
using OnlineExamSystem.Test_Item;
using OnlineExamSystem.Test_Items;

namespace OnlineExamSystem
{
    public class OnlineExamSystemApplicationAutoMapperProfile : Profile
    {
        public OnlineExamSystemApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<OES_Class, OES_ClassDto>();
            CreateMap<CreateUpdateOES_ClassDto, OES_Class>();

            CreateMap<OES_Student, OES_StudentDto>();
            CreateMap<CreateUpdateOES_StudentDto, OES_Student>();
            CreateMap<OES_Test, OES_TestDto>();
            CreateMap<CreateUpdateOES_TestDto, OES_Test>();
            CreateMap<OES_Test_Item, OES_Test_ItemDto>();
            CreateMap<CreateUpdateOES_Test_ItemDto, OES_Test_Item>();
        }
    }
}
