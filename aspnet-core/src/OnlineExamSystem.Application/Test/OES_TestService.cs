using Microsoft.AspNetCore.Authorization;

using OnlineExamSystem.Class;
using OnlineExamSystem.Student;
using OnlineExamSystem.Test_Item;
using OnlineExamSystem.Test_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;
using Volo.Abp.Identity;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace OnlineExamSystem.Test
{
    //[Authorize]
    public class OES_TestService :
        //CrudAppService< //Defines CRUD methods
        //    OES_Test,
        //   OES_TestDto, //Used to show books
        //    Guid, //Primary key of the book entity
        //    PagedAndSortedResultRequestDto, //Used for paging/sorting
        //    CreateUpdateOES_TestDto>, //Used to create/update a book
        ApplicationService
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly IRepository<OES_Class, Guid> _classRepository;
        private readonly IRepository<OES_Test, Guid> _testRepository;
        private readonly IRepository<OES_Student, Guid> _studentRepository;
        private readonly IRepository<OES_Test_Item, Guid> _testItemRepository;
        private readonly IHostingEnvironment _hostingEnvironment;


        private readonly ICurrentUser _currentUser;
        //public OES_TestService(IRepository<OES_Test, Guid> repository)
        //    : base(repository)
        //{

        //}

        public OES_TestService(ICurrentUser currentUser, IRepository<OES_Class, Guid> classRepository, IRepository<OES_Test, Guid> testRepository, IRepository<OES_Student, Guid> studentRepository, IRepository<OES_Test_Item, Guid> testItemRepository, IRepository<IdentityUser, Guid> userRepository, IHostingEnvironment hostingEnvironment)
        {
            _classRepository = classRepository;
            _testRepository = testRepository;
            _studentRepository = studentRepository;
            _testItemRepository = testItemRepository;
            _currentUser = currentUser;
            _userRepository = userRepository;
            _hostingEnvironment = hostingEnvironment;


        }

        public async Task<OES_TestDto> CreateAsync(CreateUpdateOES_TestDto input)
        {
            try
            {
                var test = new OES_Test
                {

                    TestName = input.TestName,
                    Date = input.Date,
                    Duration = input.Duration,
                    Max_Question = input.Max_Question,
                    ClassId = input.ClassId,
                    StudentId = input.StudentId


                };
                await _testRepository.InsertAsync(test);

                await UnitOfWorkManager.Current.SaveChangesAsync();
                return ObjectMapper.Map<OES_Test, OES_TestDto>(test);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public static List<List<OES_Test_Item>> Split(List<OES_Test_Item> source)
        {
            var data = (List<List<OES_Test_Item>>)source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 3)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();

            return data;
        }
        public async Task<OES_Test_ItemDto> AddStudentTest(Guid id)
        {
            try
            {
                Guid? userId = _currentUser.Id;

                OES_Test_ItemDto testitem = new OES_Test_ItemDto();



                var StudentId = _studentRepository.Where(x => x.UserId == userId).Select(x => x.Id).FirstOrDefault();


                /// this query is checking if student is in exam rightnow
                var alreadyInTest = _testRepository.Where(x => x.StudentId == StudentId && x.TemplateId == id).FirstOrDefault();

                if (alreadyInTest != null)
                {
                    var remainingTime = DateTime.Now.Subtract(alreadyInTest.CreationTime).TotalMinutes;
                    if (remainingTime < alreadyInTest.Duration)
                    {

                        var testItemSavedList = _testItemRepository.Where(x => x.TestId == alreadyInTest.Id && x.Answer == "").Select(x => x).FirstOrDefault();
                        if (testItemSavedList != null)
                        {
                            testitem.Id = testItemSavedList.Id;
                            testitem.Question = testItemSavedList.Question;
                            testitem.Answer = testItemSavedList.Answer;
                            testitem.Duration = testItemSavedList.Duration * 60;
                            testitem.TestId = testItemSavedList.TestId;
                        }
                    }

                }
                else
                {
                    // This query check if the test is duplicate or not
                    //var duplicateTest = _testRepository.Where(x => x.StudentId == StudentId && x.TemplateId == id).Any();
                    if (true)
                    {
                        IQueryable<OES_Test> Qureable1 = await _testRepository.GetQueryableAsync();
                        var mainTest = Qureable1.Where(x => x.Id == id).Select(x => x).FirstOrDefault();

                        var test = new OES_Test
                        {

                            TestName = mainTest.TestName,
                            Date = mainTest.Date,
                            Duration = mainTest.Duration,
                            Max_Question = mainTest.Max_Question,
                            ClassId = mainTest.ClassId,
                            StudentId = StudentId,
                            TemplateId = id
                        };
                        await _testRepository.InsertAsync(test);



                        var testItemList1 = _testItemRepository.Where(x => x.TestId == id).Select(x => x).ToList();

                        var groupOfThreeList = Split(testItemList1);
                        var maxQuestionList = groupOfThreeList.OrderBy(r => Guid.NewGuid()).Take(test.Max_Question).ToList();
                        foreach (var item in maxQuestionList)
                        {
                            var row = item.OrderBy(r => Guid.NewGuid()).Take(1).SingleOrDefault();
                            var testItem = new OES_Test_Item
                            {
                                TestId = test.Id,
                                Question = row.Question,
                                Answer = row.Answer,
                                Duration = row.Duration
                            };
                            await _testItemRepository.InsertAsync(testItem);
                        }


                        //var testItemList = _testItemRepository.Where(x => x.TestId == id).Select(x => x).OrderBy(r => Guid.NewGuid()).Take(test.Max_Question).ToList();
                        //foreach (var item in testItemList)
                        //{
                        //    var testItem = new OES_Test_Item
                        //    {
                        //        TestId = test.Id,
                        //        Question = item.Question,
                        //        Answer = item.Answer,
                        //        Duration = item.Duration
                        //    };
                        //    await _testItemRepository.InsertAsync(testItem);
                        //}
                        await UnitOfWorkManager.Current.SaveChangesAsync();

                        var testItemSavedList = _testItemRepository.Where(x => x.TestId == test.Id).Select(x => x).FirstOrDefault();

                        if (testItemSavedList != null)
                        {
                            testitem.Id = testItemSavedList.Id;
                            testitem.Question = testItemSavedList.Question;
                            testitem.Answer = testItemSavedList.Answer;
                            testitem.Duration = testItemSavedList.Duration * 60;
                            testitem.TestId = testItemSavedList.TestId;
                        }
                    }
                }




                return testitem;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<PagedResultDto<OES_TestDto>> GetResultListAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var totalCount = 0;
                List<OES_TestDto> result = new List<OES_TestDto>();

                var source1 = _testRepository.WithDetails(x => x.Student).Where(x => x.StudentId != null && x.ClassId != null).Select(x => x).Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
                foreach (var itm in source1)
                {
                    OES_TestDto test = new OES_TestDto();
                    test.TestName = itm.TestName;
                    test.Date = itm.Date;
                    test.Duration = itm.Duration;
                    var users = _userRepository.Where(x => x.Id == itm.Student.UserId).FirstOrDefault();
                    test.StudentName = users.Name;
                    test.Id = itm.Id;
                    test.StudentId = itm.StudentId;
                    test.ClassId = itm.ClassId;
                    result.Add(test);


                }

                totalCount = _testRepository.WithDetails(x => x.Student).Where(x => x.StudentId != null && x.ClassId != null).Count();

                return new PagedResultDto<OES_TestDto>(
                    totalCount,
                   result
                );


            }
            catch (Exception e)
            {

                throw;
            }


        }

        public async Task<PagedResultDto<OES_TestDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            List<OES_TestDto> result = new List<OES_TestDto>();
            var totalCount = 0;
            Guid? userId = _currentUser.Id;
            var studentClass = _studentRepository.Where(x => x.UserId == userId).Select(x => x.ClassId).FirstOrDefault();
            bool Check = _studentRepository.Where(x => x.UserId == userId).Select(x => x.ClassId).Any();
            if (!Check)
            {
                var source1 = _testRepository.WithDetails(x => x.OES_Class).Where(x => x.StudentId == null).Select(x => x).Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
                foreach (var itm in source1)
                {
                    OES_TestDto test = new OES_TestDto();
                    test.Id = itm.Id;
                    test.TestName = itm.TestName;
                    test.Date = itm.Date;
                    test.Duration = itm.Duration;
                    test.ClassName = itm.OES_Class.Name;

                    test.StudentId = itm.StudentId;
                    test.ClassId = itm.ClassId;
                    result.Add(test);


                }

                totalCount = await AsyncExecuter.CountAsync(
                        _testRepository.Where(x => x.StudentId == null)
                    );

                return new PagedResultDto<OES_TestDto>(
                    totalCount,
                   result
                );
            }
            else
            {

                var source = _testRepository.WithDetails(x => x.OES_Class).Where(x => x.Student == null && x.ClassId == studentClass).Skip(input.SkipCount).Take(input.MaxResultCount).Select(x => x).ToList();
                foreach (var itm in source)
                {
                    OES_TestDto test = new OES_TestDto();
                    test.Id = itm.Id;
                    test.TestName = itm.TestName;
                    test.Date = itm.Date;
                    test.Duration = itm.Duration;
                    test.ClassName = itm.OES_Class.Name;

                    test.StudentId = itm.StudentId;
                    test.ClassId = itm.ClassId;
                    result.Add(test);


                }

                totalCount = await AsyncExecuter.CountAsync(
                        _testRepository.Where(x => x.Student == null && x.ClassId == studentClass)
                    );

                return new PagedResultDto<OES_TestDto>(
                    totalCount,
                    result
                );
            }



        }

        public async Task DeleteAsync(Guid id)
        {
            await _testRepository.DeleteAsync(id);
        }

        public async Task<OES_TestDto> GetAsync(Guid id)
        {
            var source = await _testRepository.GetAsync(id);
            return ObjectMapper.Map<OES_Test, OES_TestDto>(source);
        }
        public async Task<OES_TestDto> UpdateAsync(Guid id, CreateUpdateOES_TestDto input)
        {
            var test = await _testRepository.GetAsync(id);

            test.TestName = input.TestName;
            test.Date = input.Date;
            test.Duration = input.Duration;
            test.Max_Question = input.Max_Question;
            test.ClassId = input.ClassId;

            await _testRepository.UpdateAsync(test);
            return ObjectMapper.Map<OES_Test, OES_TestDto>(test);
        }



        [HttpPost]
        public FileStreamResult DownloadResult(Guid id)
        {
            try
            {

                var result = _testItemRepository.WithDetails(x => x.Test.Student).Where(x => x.TestId == id).Select(x => x).ToList();
                var test = new Guid();
                string filePath = _hostingEnvironment.ContentRootPath + "\\Downloads\\";
                filePath += Guid.NewGuid().ToString() + ".docx";
                if (result != null)
                {
                    var data = result[0];
                    var users = _userRepository.Where(x => x.Id == data.Test.Student.UserId).FirstOrDefault();

                    // Open an existing word processing document


                    using (WordprocessingDocument doc = WordprocessingDocument.Create(filePath, 0, true))
                    {
                        // Add a main document part. 
                        MainDocumentPart mainPart = doc.AddMainDocumentPart();
                        // Add a paragraph with a run and some text.
                        mainPart.Document = new Document(
                                                 new Body(
                                                    new Paragraph(
                                                       new Run(
                                                          new Text("Test Name :"+data.Test.TestName)))));
                        Paragraph p =
                            new Paragraph(
                                new Run(
                                    new Text("")));

                        // Add the paragraph as a child element of the w:body element.
                        doc.MainDocumentPart.Document.Body.AppendChild(p);

                        // Add a paragraph with a run and some text.
                        Paragraph p1 =
                            new Paragraph(
                                new Run(
                                    new Text("Student Name :"+users.Name)));

                        // Add the paragraph as a child element of the w:body element.
                        doc.MainDocumentPart.Document.Body.AppendChild(p1);
                        Paragraph p2 =
                         new Paragraph(
                             new Run(
                                 new Text("" )));

                        // Add the paragraph as a child element of the w:body element.
                        doc.MainDocumentPart.Document.Body.AppendChild(p2);
                       
                        foreach (var item in result)
                        {


                            doc.MainDocumentPart.Document.Body.AppendChild(
                            new Paragraph(
                                 new Run(
                                     new Text("Question :" + item.Question))));

                            // Add the paragraph as a child element of the w:body element.


                            doc.MainDocumentPart.Document.Body.AppendChild(
                            new Paragraph(
                             new Run(
                                 new Text("Answer :" + item.Answer))));
                          

                        }
                    };

                       
       

           

                    //using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Create(output, 0))
                    //{


                    //    Body body = wordprocessingDocument.MainDocumentPart.Document.Body;
                    //    // Add paragraph
                    //    Paragraph para = body.AppendChild(new Paragraph());
                    //    Run run = para.AppendChild(new Run());
                    //    run.AppendChild(new Text(users.UserName));


                    //    string filePath = "your file path";
                    //    string fileName = "your file name";
                    //    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                    //    // return File(fileBytes, "application/force-download", fileName);


                    //}



                }
                //var output = new MemoryStream();
                //using (FileStream file = new FileStream("C:\\Users\\hc\\Documents\\demo.docx", FileMode.Open, FileAccess.Read))
                //    file.CopyTo(output);

                //var fileName = "StudentResult.docx";
                //var mimeType = "application/octet-stream";


                //return new FileStreamResult(output, mimeType)
                //{
                //    FileDownloadName = fileName
                //};



                var stream = File.OpenRead(filePath);
                return new FileStreamResult(stream, "application/octet-stream") { FileDownloadName = "test.docx" };
            }
            catch (Exception e)
            {

                throw;
            }
            //return ResponseMessage(new HttpResponseMessage
            //{
            //    Content = new StreamContent(stream)
            //    {
            //        Headers =
            //    {
            //        ContentType = new MediaTypeHeaderValue("application/pdf"),
            //        ContentDisposition = new ContentDispositionHeaderValue("attachment")
            //        {
            //            FileName = "myfile.pdf"
            //        }
            //    }
            //    },
            //    StatusCode = HttpStatusCode.OK
            //});

            //options.ExportFormatType = ExportFormatType.WordForWindows;

            //options.FormatOptions = new PdfRtfWordFormatOptions();

            //ExportRequestContext req_word = new ExportRequestContext();

            //req_word.ExportInfo = options;

            //Stream word_stream = report.FormatEngine.ExportToStream(req_word);

            //return ResponseMessage(new HttpResponseMessage
            //{
            //    Content = new StreamContent(word_stream)
            //    {
            //        Headers =
            //                {
            //                    ContentType = new MediaTypeHeaderValue("application/msword"),
            //                    ContentDisposition = new ContentDispositionHeaderValue("attachment")
            //                    {
            //                        FileName = "AnnexureEReport.doc"
            //                    }
            //                }
            //    },
            //    StatusCode = HttpStatusCode.OK
            //});
        }
    }
}
