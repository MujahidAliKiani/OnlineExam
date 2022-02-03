using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Class;
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
using Volo.Abp.Users;

namespace OnlineExamSystem.Test_Items
{
    [Authorize]
    public class OES_Test_ItemService :
        //CrudAppService< //Defines CRUD methods
        //    OES_Test_Item,
        //   OES_Test_ItemDto, //Used to show books
        //    Guid, //Primary key of the book entity
        //    PagedAndSortedResultRequestDto, //Used for paging/sorting
        //    CreateUpdateOES_Test_ItemDto>, //Used to create/update a book
        //IOES_Test_ItemService
        ApplicationService
    {
        //public OES_Test_ItemService(IRepository<OES_Test_Item, Guid> repository)
        //    : base(repository)
        //{

        //}

        private readonly IRepository<OES_Class, Guid> _classRepository;
        private readonly IRepository<OES_Test, Guid> _testRepository;
        private readonly IRepository<OES_Student, Guid> _studentRepository;
        private readonly IRepository<OES_Test_Item, Guid> _testItemRepository;
        private readonly ICurrentUser _currentUser;
        //public OES_TestService(IRepository<OES_Test, Guid> repository)
        //    : base(repository)
        //{

        //}

        public OES_Test_ItemService(ICurrentUser currentUser, IRepository<OES_Class, Guid> classRepository, IRepository<OES_Test, Guid> testRepository, IRepository<OES_Student, Guid> studentRepository, IRepository<OES_Test_Item, Guid> testItemRepository)
        {
            _classRepository = classRepository;
            _testRepository = testRepository;
            _studentRepository = studentRepository;
            _testItemRepository = testItemRepository;
            _currentUser = currentUser;
        }

        public async Task<OES_Test_ItemDto> CreateAsync(CreateUpdateOES_Test_ItemDto input)
        {
            try
            {
                var test = new OES_Test_Item
                {

                    TestId = input.TestId,
                    Question=input.Question,
                    Answer=input.Answer,
                    Duration=input.Duration
                


                };
                await _testItemRepository.InsertAsync(test);

                await UnitOfWorkManager.Current.SaveChangesAsync();
                return ObjectMapper.Map<OES_Test_Item, OES_Test_ItemDto>(test);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<PagedResultDto<OES_Test_ItemDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var source = await _testItemRepository.GetListAsync(true);

            var totalCount = await AsyncExecuter.CountAsync(
                    _testItemRepository
                );

            return new PagedResultDto<OES_Test_ItemDto>(
                totalCount,
                ObjectMapper.Map<List<OES_Test_Item>, List<OES_Test_ItemDto>>(source)
            );
        }
        public async Task<PagedResultDto<OES_Test_ItemDto>> GetSelectedListAsync(Guid id)
        {
            var source =  _testItemRepository.Where(x=>x.TestId==id).ToList();

            var totalCount = await AsyncExecuter.CountAsync(
                    _testItemRepository
                );

            return new PagedResultDto<OES_Test_ItemDto>(
                totalCount,
                ObjectMapper.Map<List<OES_Test_Item>, List<OES_Test_ItemDto>>(source)
            );
        }


        public async Task<OES_Test_ItemDto> GetStudentTestListAsync(Guid id)
        {
            try
            {
                Guid? userId = _currentUser.Id;

             

                var StudentId = _studentRepository.Where(x => x.UserId == userId).Select(x => x.Id).FirstOrDefault();


                IQueryable<OES_Student> Qureable = await _studentRepository.GetQueryableAsync();
                
                var ClassId = Qureable.Where(x => x.Id == id).Select(x => x.ClassId).FirstOrDefault();
                
                IQueryable<OES_Test> Qureable1 = await _testRepository.GetQueryableAsync();
                var test = Qureable1.Where(x => x.Id == id).Select(x => x).FirstOrDefault();



                IQueryable<OES_Test_Item> Qureable2 = await _testItemRepository.GetQueryableAsync();

                OES_Test_Item studenttest_Item = Qureable2.Where(x => x.TestId == id && x.Test.StudentId == StudentId && x.Answer == "").Select(x => x).OrderBy(r => Guid.NewGuid()).FirstOrDefault();

                OES_Test_Item studenttest_Item1 = Qureable2.Where(x => x.TestId == id && x.Test.StudentId == StudentId).Select(x => x).FirstOrDefault();

                OES_Test_Item studenttest_Item2 = Qureable2.Where(x => x.TestId == id && x.Answer == "").Select(x => x).OrderBy(r => Guid.NewGuid()).FirstOrDefault();

                OES_Test_ItemDto testitem = new OES_Test_ItemDto();
                testitem.Id = studenttest_Item.Id;
                testitem.Question = studenttest_Item.Question;
                testitem.Answer = studenttest_Item.Answer;
                testitem.Duration = studenttest_Item.Duration * 60;
                testitem.TestId = studenttest_Item.TestId;

                return testitem;
                
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _testItemRepository.DeleteAsync(id);
        }

        public async Task<OES_Test_ItemDto> GetAsync(Guid id)
        {
            var source = await _testItemRepository.GetAsync(id);
            return ObjectMapper.Map<OES_Test_Item, OES_Test_ItemDto>(source);
        }
        public async Task<OES_Test_ItemDto> UpdateAsync(Guid id, CreateUpdateOES_Test_ItemDto input)
        {
            var test = await _testItemRepository.GetAsync(id);

            test.TestId = input.TestId;
            test.Question = input.Question;
            test.Answer = input.Answer;
            test.Duration = input.Duration;
            
            await _testItemRepository.UpdateAsync(test);
            return ObjectMapper.Map<OES_Test_Item, OES_Test_ItemDto>(test);
        }

        [HttpPost]
        public async Task<OES_Test_ItemDto> UpdateStudentAnswer(Guid id, string answer)
        {
            var test = _testItemRepository.Where(x => x.Id == id).Select(x => x).FirstOrDefault();

            test.Answer = answer.IsNullOrWhiteSpace() ? "Empty" : answer;
            await _testItemRepository.UpdateAsync(test);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            var testItem1 = _testItemRepository.Where(x => x.TestId == test.TestId).Select(x => x).ToList();
            var testItem = _testItemRepository.Where(x => x.TestId == test.TestId && x.Answer == "").Select(x => x).FirstOrDefault();

            

            OES_Test_ItemDto testitem = new OES_Test_ItemDto();
            if (testItem != null)
            {
                testitem.Id = testItem.Id;
                testitem.Question = testItem.Question;
                testitem.Answer = testItem.Answer;
                testitem.Duration = testItem.Duration * 60;
                testitem.TestId = testItem.TestId;
            }

            return testitem;
        }

        public async Task<int> CreateStudentTestAsync(Guid id, List<CreateStudentTestDto> input)
        {
            var test = await _testRepository.GetAsync(id);
            var newtest = new OES_Test()
            {
               StudentId = input.Select(x => x.StudentId).FirstOrDefault(),
               TestName=test.TestName,
               ClassId=test.ClassId,
               Date=test.Date,
               Max_Question=test.Max_Question,
               Duration=test.Duration

        };
            await _testRepository.InsertAsync(newtest);
        
            foreach (var itm in input)
            {
                var testItem = new OES_Test_Item()
                {
                    TestId = newtest.Id,
                    Question = itm.Question,
                    Answer=itm.Answer,
                    Duration=itm.Duration


                };

                await _testItemRepository.InsertAsync(testItem);

            }



            await UnitOfWorkManager.Current.SaveChangesAsync();
         
            return 1;
        }

    }
}
