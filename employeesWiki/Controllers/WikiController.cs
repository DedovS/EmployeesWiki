using employeesWiki.Contracts;
using employeesWiki.DtoModels.WikiDto;
using employeesWiki.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employeesWiki.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WikiController : ControllerBase
    {
        private readonly IWikiService _wikiService;

        public WikiController(IWikiService wikiService)
        {
            _wikiService = wikiService;
        }

        [Route("getList")]
        [HttpPost]
        public async Task<List<WikiDto>> GetList(PageParams pageParam)
        {
            return await _wikiService.GetListAsync(pageParam);
        }

        [HttpPost]
        public async Task<WikiDto> Create(WikiDto wikiDto)
        {
            return await _wikiService.CreateAsync(wikiDto);
        }

        [HttpPut]
        public async Task<WikiDto> Update(WikiDto wikiDto)
        {
            return await _wikiService.UpdateAsync(wikiDto);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<WikiDto> GetById(int id)
        {
            return await _wikiService.GetByIdAsync(id);
        }

        [Route("delete/{id}")]
        [HttpGet]
        public async Task<WikiDto> Delete(int id)
        {
            return await _wikiService.DeleteAsync(id);
        }
    }
}