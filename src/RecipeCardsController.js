import { useState, memo } from "react";
import RecipeCard from "./RecipeCard";
import { controllerStyle } from "./RecipeCardsControllerStyle.module";

const recipeList = [
  {
    title: "Shaorma",
    description:
      "Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing ",
    preparationTime: "30 min",
    dificulty: "Basic",
    numberOfIngredients: 10,
    url: "https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
  },
  {
    title: "Shaorma",
    description:
      "Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing ",
    preparationTime: "30 min",
    dificulty: "Basic",
    numberOfIngredients: 10,
    url: "https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
  },
  {
    title: "Shaorma",
    description:
      "Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing ",
    preparationTime: "30 min",
    dificulty: "Basic",
    numberOfIngredients: 10,
    url: "https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
  },
  {
    title: "Shaorma",
    description:
      "Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing ",
    preparationTime: "30 min",
    dificulty: "Basic",
    numberOfIngredients: 10,
    url: "https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
  },
  {
    title: "Shaorma",
    description:
      "Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing ",
    preparationTime: "30 min",
    dificulty: "Basic",
    numberOfIngredients: 10,
    url: "https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
  },
  {
    title: "Shaorma",
    description:
      "Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing ",
    preparationTime: "30 min",
    dificulty: "Basic",
    numberOfIngredients: 10,
    url: "https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg",
  },
];

function RecipeCardsController() {
  const [recipes, setRecipes] = useState(recipeList);

  const cardsRender = () => {
    if (recipes.length === 0) return;

    return recipes.map((recipe,index) => {
      return <RecipeCard key={index} recipe={recipe} />;
    });
  };

  return (
        <div style={controllerStyle}>
            {cardsRender()}
        </div>
  );
}

export default memo(RecipeCardsController);
