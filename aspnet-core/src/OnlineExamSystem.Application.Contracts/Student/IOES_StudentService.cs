using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OnlineExamSystem.Student
{
   public interface IOES_StudentService :
        ICrudAppService< //Defines CRUD methods
            OES_StudentDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOES_StudentDto> //Used to create/update a book
    {

    }
}
