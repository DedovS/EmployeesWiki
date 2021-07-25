using AutoMapper;
using employeesWiki.Contracts;
using employeesWiki.Contracts.Services;
using employeesWiki.DtoModels.WikiDto;
using employeesWiki.Models;
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
        private readonly IMapper _mapper;
        public WikiController(IWikiService wikiService, IMapper mapper)
        {
            _wikiService = wikiService;
            _mapper = mapper;
        }

        [Route("getList")]
        [HttpPost]
        public async Task<List<WikiDto>> GetList(PageParams pageParam)
        {
            var wikiList = await _wikiService.GetListAsync(pageParam);
            return _mapper.Map<List<WikiDto>>(wikiList);
        }

        [HttpPost]
        public async Task<WikiDto> Create(WikiDto wikiDto)
        { 
            var wiki = await _wikiService.CreateAsync(_mapper.Map<Wiki>(wikiDto));
            return _mapper.Map<WikiDto>(wiki); 
        }

        [HttpPut]
        public async Task<WikiDto> Update(WikiDto wikiDto)
        {
            var wiki = await _wikiService.UpdateAsync(_mapper.Map<Wiki>(wikiDto));
            return _mapper.Map<WikiDto>(wiki);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<WikiDto> GetById(int id)
        {
            var wiki = await _wikiService.GetByIdAsync(id);
            return _mapper.Map<WikiDto>(wiki);
        }

        [Route("delete/{id}")]
        [HttpGet]
        public async Task<bool> Delete(int id)
        {
            return await _wikiService.DeleteAsync(id);
        }
    }
}