using GymLog.API.Data;
using GymLog.API.Models.Domain;
using GymLog.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly GymLogDbContext dbContext;

        public ExercisesController(GymLogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddExerciseRequestDto addExerciseRequestDto)
        {
            var exerciseDomainModel = new Exercise
            {
                Name = addExerciseRequestDto.Name,
                MuscleGroup = addExerciseRequestDto.MuscleGroup,
                DifficulityLevel = addExerciseRequestDto.DifficulityLevel
            };
            dbContext.Exercises.Add(exerciseDomainModel);
            dbContext.SaveChanges();
            var exerciseDto = new ExerciseDto
            {
                Id = exerciseDomainModel.Id,
                Name = exerciseDomainModel.Name,
                MuscleGroup = exerciseDomainModel.MuscleGroup,
                DifficulityLevel = exerciseDomainModel.DifficulityLevel

            };
            return Ok(exerciseDto);
        }

        [HttpGet]
            public IActionResult GetAll()
            {
                var exercises = dbContext.Exercises.ToList();
                var exercisesDto = new List<ExerciseDto>();
                foreach (var exercise in exercises)
                {
                    exercisesDto.Add(new ExerciseDto()
                        {
                            Id = exercise.Id,
                            Name = exercise.Name,
                            MuscleGroup = exercise.MuscleGroup,
                            DifficulityLevel = exercise.DifficulityLevel
                        }
                    );
                }
                return Ok(exercisesDto);
            }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var exerciseDomain=dbContext.Exercises.FirstOrDefault(x=>x.Id==id);
            if (exerciseDomain == null)
            {
                return NotFound();
            }

            var exerciseDto = new ExerciseDto()
            {
                Id = exerciseDomain.Id,
                Name = exerciseDomain.Name,
                MuscleGroup = exerciseDomain.MuscleGroup,
                DifficulityLevel = exerciseDomain.DifficulityLevel
            };
            return Ok(exerciseDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var exerciseDomainModel=dbContext.Exercises.FirstOrDefault(x=>x.Id==id);
            if (exerciseDomainModel==null)
            {
                return NotFound();
            }

            dbContext.Exercises.Remove(exerciseDomainModel);
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateExerciseRequestDto updateExerciseRequestDto)
        {
            var exerciseDomainModel=dbContext.Exercises.FirstOrDefault(x=>x.Id==id);
            if(exerciseDomainModel==null)
                {
                return NotFound();
                }
            exerciseDomainModel.Name=updateExerciseRequestDto.Name;
            exerciseDomainModel.MuscleGroup=updateExerciseRequestDto.MuscleGroup;
            exerciseDomainModel.DifficulityLevel=updateExerciseRequestDto.DifficulityLevel;
            dbContext.SaveChanges();

            var exerciseDto = new ExerciseDto
            {
                Id = exerciseDomainModel.Id,
                Name = exerciseDomainModel.Name,
                MuscleGroup = exerciseDomainModel.MuscleGroup,
                DifficulityLevel = exerciseDomainModel.DifficulityLevel
            };
            return Ok(exerciseDto);
        }
        
        }
        
    }

