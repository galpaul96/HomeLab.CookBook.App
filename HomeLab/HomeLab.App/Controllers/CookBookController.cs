using AutoMapper;
using HomeLab.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace HomeLab.App.Controllers
{
    /// <summary>
    /// CookBook controller.
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class CookBookController: ControllerBase
    {
        private readonly ILogger<CookBookController> _logger;
        private readonly IMapper _mapper;

        private static List<RecipeOverviewModel> _recipeOverviewModels = new List<RecipeOverviewModel>()
            {
                new RecipeOverviewModel()
                {
                    Id=Guid.NewGuid(),
                    Title= "Shaorma",
                    Description ="Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing",
                    Difficulty="Medium",
                    Duration="00:30:00",
                    ImageUrl="https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
                    NoOfIngredients = 3,
                    NoOfSteps=2
                },
                new RecipeOverviewModel()
                {
                    Id=Guid.NewGuid(),
                    Title= "Shaorma",
                    Description ="Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing",
                    Difficulty="Medium",
                    Duration="00:30:00",
                    ImageUrl="https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
                    NoOfIngredients = 3,
                    NoOfSteps=2
                },
                new RecipeOverviewModel()
                {
                    Id=Guid.NewGuid(),
                    Title= "Shaorma",
                    Description ="Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing",
                    Difficulty="Medium",
                    Duration="00:30:00",
                    ImageUrl="https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
                    NoOfIngredients = 3,
                    NoOfSteps=2
                },
                new RecipeOverviewModel()
                {
                    Id=Guid.NewGuid(),
                    Title= "Shaorma",
                    Description ="Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing",
                    Difficulty="Medium",
                    Duration="00:30:00",
                    ImageUrl="https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
                    NoOfIngredients = 3,
                    NoOfSteps=2
                },
                new RecipeOverviewModel()
                {
                    Id=Guid.NewGuid(),
                    Title= "Shaorma",
                    Description ="Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing",
                    Difficulty="Medium",
                    Duration="00:30:00",
                    ImageUrl="https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
                    NoOfIngredients = 3,
                    NoOfSteps=2
                }
            };
        private static List<RecipeDetailsModel> recipeDetailsModels = new List<RecipeDetailsModel>()
             {
                 new RecipeDetailsModel()
                {
                    Id=Guid.NewGuid(),
                    Title= "Shaorma",
                    Description ="Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing",
                    Difficulty="Medium",
                    Duration="00:30:00",
                    ImageUrl="https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
                },
                new RecipeDetailsModel()
                {
                    Id=Guid.NewGuid(),
                    Title= "Shaorma",
                    Description ="Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing",
                    Difficulty="Medium",
                    Duration="00:30:00",
                    ImageUrl="https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
                },
                new RecipeDetailsModel()
                {
                    Id=Guid.NewGuid(),
                    Title= "Shaorma",
                    Description ="Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing",
                    Difficulty="Medium",
                    Duration="00:30:00",
                    ImageUrl="https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
                },
                new RecipeDetailsModel()
                {
                    Id=Guid.NewGuid(),
                    Title= "Shaorma",
                    Description ="Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing",
                    Difficulty="Medium",
                    Duration="00:30:00",
                    ImageUrl="https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
                },
                new RecipeDetailsModel()
                {
                    Id=Guid.NewGuid(),
                    Title= "Shaorma",
                    Description ="Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing",
                    Difficulty="Medium",
                    Duration="00:30:00",
                    ImageUrl="https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
                }
             };
        /// <summary>
        /// CookBookController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public CookBookController(ILogger<CookBookController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("recipes")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RecipeOverviewModel))]
        public async Task<IActionResult> AddRecipe(RecipeCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            recipeDetailsModels.Add(new RecipeDetailsModel()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Difficulty = model.Difficulty,
                Duration = "00:25:00",
                ImageUrl = model.ImageUrl
            });
            _recipeOverviewModels.Add(new RecipeOverviewModel()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Difficulty = model.Difficulty,
                Duration = "00:25:00",
                ImageUrl = model.ImageUrl,
                NoOfIngredients = 3,
                NoOfSteps = 2
            });

            return Created("",new RecipeDetailsModel()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Difficulty = model.Difficulty,
                Duration = "00:25:00",
                ImageUrl = model.ImageUrl
            });
        }

        /// <summary>
        /// GetRecipes
        /// </summary>
        /// <returns>RecipeOverviewModel</returns>
        [HttpGet("recipes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecipeOverviewModel[]))]
        public async Task<IActionResult> GetRecipes()
        {
            return Ok(_recipeOverviewModels);
        }
    }
}
