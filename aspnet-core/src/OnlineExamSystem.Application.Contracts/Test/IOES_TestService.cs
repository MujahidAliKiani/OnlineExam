using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OnlineExamSystem.Test
{
   public interface IOES_TestService :
        ICrudAppService< //Defines CRUD methods
            OES_TestDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOES_TestDto> //Used to create/update a book
                                     //IApplicationService
    {
        //Task<OES_TestDto> CreateAsync(CreateUpdateOES_TestDto input);
        //Task<PagedResultDto<OES_TestDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        //Task DeleteAsync(Guid id);
        //Task<OES_TestDto> GetAsync(Guid id);
        //Task<OES_TestDto> UpdateAsync(Guid id, CreateUpdateOES_TestDto input);
    }
}
