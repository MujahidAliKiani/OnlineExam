using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OnlineExamSystem.Class
{
   public interface IOES_ClassService :
        ICrudAppService< //Defines CRUD methods
           OES_ClassDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOES_ClassDto> //Used to create/update a book
    {

    }
}
