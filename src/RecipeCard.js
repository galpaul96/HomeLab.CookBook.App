import {useState} from 'react';
import {cardStyle,imageSectionStyle,titleStyle,descriptionStyle,detailsStyle,detailElementStyle,paragraphStyle} from './RecipeCardStyle.module.js';

const exempleRecipe={
    title: "Shaorma",
    description: "Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat.",
    preparationTime: 30,
    dificulty: "Basic",
    numberOfIngredients: 10,
    url:'./images/shaorma.jpg'
    //https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg
}

function RecipeCard(){
    const [recipe,setRecipe]= useState(exempleRecipe)

    return (
        <div style={cardStyle}
            onClick={(e)=> console.log("Redirect the user to the recipe page!")}
        >
            <div style={imageSectionStyle}>
                <img src={recipe.url} alt={recipe.title} />
            </div>
            <div>
                <h3 style={titleStyle}>{recipe.title}</h3>
                <p style={descriptionStyle}>{recipe.description}</p>
                <div style={detailsStyle}>
                    <div style={detailElementStyle}>
                        <p style={paragraphStyle}>Time</p>
                        <p style={paragraphStyle}>{recipe.preparationTime}</p>
                    </div>
                    <div style={detailElementStyle}>
                        <p style={paragraphStyle}>Difficulty</p>
                        <p style={paragraphStyle}>{recipe.dificulty}</p>
                    </div>
                    <div style={detailElementStyle}>
                        <p style={paragraphStyle}>Ingredients</p>
                        <p style={paragraphStyle}>{recipe.numberOfIngredients}</p>
                    </div>
                </div>
                
            </div>
        </div>
    )
}

export default RecipeCard;