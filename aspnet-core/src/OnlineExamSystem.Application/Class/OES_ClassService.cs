using Microsoft.AspNetCore.Authorization;
using OnlineExamSystem.Permissions;
using OnlineExamSystem.Student;
using OnlineExamSystem.Test;
using OnlineExamSystem.Test_Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OnlineExamSystem.Class
{
    [Authorize]
    public class OES_ClassService :
        CrudAppService< //Defines CRUD methods
            OES_Class,
           OES_ClassDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOES_ClassDto>, //Used to create/update a book
        IOES_ClassService
    //ApplicationService
    {
        public OES_ClassService(IRepository<OES_Class, Guid> repository)
            : base(repository)
        {
            //GetPolicyName = OnlineExamSystemPermissions.Class.Default;
            //GetListPolicyName = OnlineExamSystemPermissions.Class.Default;
            //CreatePolicyName = OnlineExamSystemPermissions.Class.Create;
            //UpdatePolicyName = OnlineExamSystemPermissions.Class.Edit;
            //DeletePolicyName = OnlineExamSystemPermissions.Class.Delete;
        }
        //private readonly IRepository<OES_Class, Guid> _classRepository;
        //private readonly IRepository<OES_Test, Guid> _testRepository;
        //private readonly IRepository<OES_Student, Guid> _studentRepository;
        //private readonly IRepository<OES_Test_Item, Guid> _testItemRepository;
       

        //public OES_ClassService(IRepository<OES_Class, Guid> classRepository, IRepository<OES_Test, Guid> testRepository, IRepository<OES_Student, Guid> studentRepository, IRepository<OES_Test_Item, Guid> testItemRepository)
        //{
        //    _classRepository = classRepository;
        //    _testRepository = testRepository;
        //    _studentRepository = studentRepository;
        //    _testItemRepository = testItemRepository;
        //}

        //public async Task<OES_ClassDto> CreateAsync(CreateUpdateOES_ClassDto input)
        //{
        //    try
        //    {
        //        var Class = new OES_Class
        //        {

        //            Name = input.Name,



        //        };
        //        await _classRepository.InsertAsync(Class);

        //        await UnitOfWorkManager.Current.SaveChangesAsync();
        //        return ObjectMapper.Map<OES_Class, OES_ClassDto>(Class);
        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }
        //}
        //public async Task<PagedResultDto<OES_ClassDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        //{
        //    var Class = await _classRepository.GetListAsync();

        //    var totalCount = await AsyncExecuter.CountAsync(
        //        _classRepository
        //    );

        //    return new PagedResultDto<OES_ClassDto>(
        //        totalCount,
        //        ObjectMapper.Map<List<OES_Class>, List<OES_ClassDto>>(Class)
        //    );
        //}

        //public async Task DeleteAsync(Guid id)
        //{
        //    await _classRepository.DeleteAsync(id);
        //}

        //public async Task<OES_ClassDto> GetAsync(Guid id)
        //{
        //    var source = await _classRepository.GetAsync(id);
        //    return ObjectMapper.Map<OES_Class, OES_ClassDto>(source);
        //}
        //public async Task<OES_ClassDto> UpdateAsync(Guid id, CreateUpdateOES_ClassDto input)
        //{
        //    var test = await _classRepository.GetAsync(id);

        //    test.Name = input.Name;


        //    await _classRepository.UpdateAsync(test);
        //    return ObjectMapper.Map<OES_Class, OES_ClassDto>(test);
        //}


    }
}
