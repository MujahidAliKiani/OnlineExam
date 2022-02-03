using Abp.Authorization.Users;
using Abp.UI;
using Microsoft.AspNetCore.Authorization;
using OnlineExamSystem.Class;
using OnlineExamSystem.Permissions;
using OnlineExamSystem.Student;
using OnlineExamSystem.Test;
using OnlineExamSystem.Test_Item;
using OnlineExamSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace OnlineExamSystem
{
    [Authorize(OnlineExamSystemPermissions.Student.Default)]
    public class OES_StudentService :
        //CrudAppService< //Defines CRUD methods
        //    OES_Student,
        //   OES_StudentDto, //Used to show books
        //    Guid, //Primary key of the book entity
        //    PagedAndSortedResultRequestDto, //Used for paging/sorting
        //    CreateUpdateOES_StudentDto>, //Used to create/update a book
        //IOES_StudentService
        ApplicationService
    {
        //public OES_StudentService(IRepository<OES_Student, Guid> repository)
        //    : base(repository)
        //{

        //}

       
          
           
        private readonly IRepository<OES_Class, Guid> _classRepository;
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly IRepository<OES_Test, Guid> _testRepository;
        private readonly IRepository<OES_Student, Guid> _studentRepository;
        private readonly IRepository<OES_Test_Item, Guid> _testItemRepository;
        //public OES_TestService(IRepository<OES_Test, Guid> repository)
        //    : base(repository)
        //{

        //}

        public OES_StudentService(IRepository<OES_Class, Guid> classRepository, IRepository<OES_Test, Guid> testRepository, IRepository<OES_Student, Guid> studentRepository, IRepository<OES_Test_Item, Guid> testItemRepository, IRepository<IdentityUser, Guid> userRepository)
        {
            _classRepository = classRepository;
            _testRepository = testRepository;
            _studentRepository = studentRepository;
            _testItemRepository = testItemRepository;
            _userRepository = userRepository;
        }
        [Authorize(OnlineExamSystemPermissions.Student.Create)]
        public async Task<OES_StudentDto> CreateAsync(CreateUpdateOES_StudentDto input)
        {
            try
            {
                var users = _userRepository.Where(x=>x.Email==input.Email).FirstOrDefault();
                if (users == null)
                {
                    throw new UserFriendlyException( "First Create User!" );

                }
                var check = _studentRepository.Where(x => x.Email == input.Email).FirstOrDefault();
                if (check != null)
                {
                    throw new UserFriendlyException("Student All Ready Exist!");

                }
                var student = new OES_Student
                {

                  
                    Email = input.Email,
                    RegistriationNumber = input.RegistriationNumber,
                    ClassId = input.ClassId,
                    UserId=users.Id
              

                };
                await _studentRepository.InsertAsync(student);

                await UnitOfWorkManager.Current.SaveChangesAsync();
                return ObjectMapper.Map<OES_Student, OES_StudentDto>(student);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<PagedResultDto<OES_StudentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            List<OES_StudentDto> Students = new List<OES_StudentDto>();
            var source = await _studentRepository.GetListAsync(true);
            foreach(var itm in source)
            {
                OES_StudentDto student = new OES_StudentDto();
                var users = _userRepository.Where(x => x.Id == itm.UserId).FirstOrDefault();
                student.FirstName = users.Name;
                student.Id = itm.Id;
                student.LastName = users.Surname;
                
                student.Email = itm.Email;
                student.RegistriationNumber = itm.RegistriationNumber;
                student.Contact = users.PhoneNumber;
                student.ClassId = itm.ClassId;
                student.UserId = itm.UserId;

                Students.Add(student);

            }

            var totalCount = await AsyncExecuter.CountAsync(
                    _studentRepository
                );

            return new PagedResultDto<OES_StudentDto>(
                totalCount,
             Students
            );
        }
        [Authorize(OnlineExamSystemPermissions.Student.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        public async Task<OES_StudentDto> GetAsync(Guid id)
        {
            var source = await _studentRepository.GetAsync(id);
            return ObjectMapper.Map<OES_Student, OES_StudentDto>(source);
        }
        [Authorize(OnlineExamSystemPermissions.Student.Edit)]
        public async Task<OES_StudentDto> UpdateAsync(Guid id, CreateUpdateOES_StudentDto input)
        {
            var test = await _studentRepository.GetAsync(id);
            test.RegistriationNumber = input.RegistriationNumber;
          
            test.ClassId = input.ClassId;

            await _studentRepository.UpdateAsync(test);
            return ObjectMapper.Map<OES_Student, OES_StudentDto>(test);
        }

    }
}
