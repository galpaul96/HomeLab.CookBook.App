﻿namespace HomeLab.App.Models
{
    public class RecipeOverviewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string ImageUrl { get; set; }


        public int NoOfSteps { get; set; }
        public int NoOfIngredients { get; set; }

        public string Duration { get; set; }

    }
}
