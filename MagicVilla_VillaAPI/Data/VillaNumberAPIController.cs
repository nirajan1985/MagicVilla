﻿using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Data
{
    [ApiController]
    [Route("api/VillaNumberAPI")]
    public class VillaNumberAPIController:ControllerBase
    {
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public VillaNumberAPIController(IVillaNumberRepository dbVillaNumber, IMapper mapper)
        {
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            this._response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers() 
        {
            try
            { 
            IEnumerable<VillaNumber> villaList=await _dbVillaNumber.GetAllAsync();
            _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaList);
            _response.StatusCode=HttpStatusCode.OK;
            return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetVillaNumber")]

        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            { 
            if (id == 0)
            {
                return BadRequest();
            }
            var villaNumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);

            if (villaNumber == null)
            {
                return NotFound();
            }
            _response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost(Name = "CreateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO createDTO)
        {
            try
            { 
            if (await _dbVillaNumber.GetAsync(u => u.VillaNo == createDTO.VillaNo) != null)
            {
                ModelState.AddModelError("CustomError", "Villa Number already exists");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }
            VillaNumber villaNumber = _mapper.Map<VillaNumber>(createDTO);

            await _dbVillaNumber.CreateAsync(villaNumber);
            _response.Result = _mapper.Map<VillaNumberCreateDTO>(villaNumber);
            _response.StatusCode = HttpStatusCode.Created;


            return CreatedAtRoute("CreateVillaNumber", new { id = villaNumber.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updateDTO)
        {
            try
            { 
            if (updateDTO == null || id != updateDTO.VillaNo)
            {
                return BadRequest();
            }
            VillaNumber villaNumber = _mapper.Map<VillaNumber>(updateDTO);
            await _dbVillaNumber.UpdateAsync(villaNumber);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villaNumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);

            if (villaNumber == null)
            {
                return Ok();
            }
            await _dbVillaNumber.RemoveAsync(villaNumber);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
