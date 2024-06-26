﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Infrastructure;
using Swashbuckle.AspNetCore.Annotations;

namespace RoboticsLabManagementSystem.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<EquipmentController> _logger;

        public EquipmentController(ApplicationDbContext dbContext, ILogger<EquipmentController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        // GET: api/v1/Equipment
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Equipment information retrieved successfully", typeof(List<Equipment>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        public async Task<IActionResult> GetAllEquipment()
        {
            try
            {
                var equipment = await _dbContext.Equipment.ToListAsync();
                return Ok(equipment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve equipment data");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET: api/v1/Equipment/{id}
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Equipment information retrieved successfully", typeof(Equipment))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Equipment not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        public async Task<IActionResult> GetEquipmentById(Guid id)
        {
            try
            {
                var equipment = await _dbContext.Equipment.FindAsync(id);

                if (equipment == null)
                {
                    return NotFound();
                }

                return Ok(equipment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve equipment data");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/v1/Equipment
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, "Equipment added successfully", typeof(Equipment))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        //public async Task<IActionResult> AddEquipment(Equipment equipment)
        //{
        //    try
        //    {
        //        _dbContext.Equipment.Add(equipment);
        //        await _dbContext.SaveChangesAsync();

        //        return CreatedAtAction(nameof(GetEquipmentById), new { id = equipment.EquipmentID }, equipment);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Failed to add equipment");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        //    }
        //}
        public async Task<IActionResult> AddEquipment(EquipmentDto equipmentDto)
        {
            try
            {
                // You can perform validation here if needed

                // Map EquipmentDto to Equipment model
                var equipment = new Equipment
                {
                    EquipmentID = equipmentDto.EquipmentID,
                    EquipmentName = equipmentDto.EquipmentName,
                    Description = equipmentDto.Description,
                    Location = equipmentDto.Location,
                    GroupID = equipmentDto.GroupID
                };

                _dbContext.Equipment.Add(equipment);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEquipmentById), new { id = equipment.EquipmentID }, equipment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add equipment");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        // PUT: api/v1/Equipment/{id}
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Equipment updated successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Equipment not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        public async Task<IActionResult> UpdateEquipment(Guid id, Equipment updatedEquipment)
        {
            try
            {
                if (id != updatedEquipment.EquipmentID)
                {
                    return BadRequest();
                }

                _dbContext.Entry(updatedEquipment).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update equipment");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }



        [HttpGet("grouped-equipment")]
        public async Task<IActionResult> GetGroupedEquipment()
        {
            try
            {
                var groupedEquipment = await _dbContext.Groups
                  
                    .ToListAsync();

                return Ok(groupedEquipment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching grouped equipment.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("group-equipment/{groupName}")]
        public async Task<IActionResult> GetEquipmentByGroupName(string groupName)
        {
            try
            {
                var group = await _dbContext.Groups
                    .FirstOrDefaultAsync(g => g.Name == groupName);

                if (group == null)
                {
                    return NotFound();
                }

                var equipmentList = await _dbContext.Equipment
                    .Where(e => e.GroupID == group.Name)
                    .Select(e => new
                    {
                        e.EquipmentID,
                        e.EquipmentName,
                        e.Description,
                        e.Quantity,
                        e.Location
                    })
                    .ToListAsync();

                return Ok(equipmentList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching equipment by group name.");
                return StatusCode(500, "Internal server error");
            }
        }
        // DELETE: api/v1/Equipment/{id}
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Equipment deleted successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Equipment not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        public async Task<IActionResult> DeleteEquipment(Guid id)
        {
            try
            {
                var equipment = await _dbContext.Equipment.FindAsync(id);
                if (equipment == null)
                {
                    return NotFound();
                }

                _dbContext.Equipment.Remove(equipment);
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete equipment");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        private bool EquipmentExists(Guid id)
        {
            return _dbContext.Equipment.Any(e => e.EquipmentID == id);
        }
    }
}
