using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OnlineExamSystem.Test_Items
{
   public interface IOES_Test_ItemService :
        ICrudAppService< //Defines CRUD methods
            OES_Test_ItemDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOES_Test_ItemDto> //Used to create/update a book
    {

    }
}
