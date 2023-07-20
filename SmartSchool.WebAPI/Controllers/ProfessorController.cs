using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        // api/Professor/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _repo.GetProfessorById(id, false);
            if (Professor == null) return BadRequest("O Professor não foi encontrado");

            return Ok(Professor);
        }

        // api/Professor
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado");
        }

        // api/Professor
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não Atualizado");

            // api/Professor
            [HttpPatch("{id}")]

            public IActionResult Patch(int id, Professor professor)
            {
                var prof = _repo.GetProfessorById(id, false);
                if (prof == null) return BadRequest("Professor não encontrado");

                _repo.Update(professor);
                if (_repo.SaveChanges())
                {
                    return Ok(professor);
                }

                return BadRequest("Professor não Atualizado");
            }

            [HttpDelete("{id}")]

            public IActionResult Delete(int id)
            {
                var Prof = _repo.GetProfessorById(id, false);
                if (Prof == null) return BadRequest("Professor não encontrado");

                _repo.Delete(prof);
                if (_repo.SaveChanges())
                {
                    return Ok("Professor deletado");
                }

                return BadRequest("Professor não deletado");
            }

        }
    }
}