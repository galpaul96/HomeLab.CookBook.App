import { useState, memo } from 'react';
import { cardStyle, imageSectionStyle, titleStyle, descriptionStyle, detailsStyle, detailContainerStyle, paragraphStyle, imageStyle, headerDetailStyle, bodyDetailStyle } from './RecipeCardStyle.module.js';

const exempleRecipe = {
    title: "Shaorma",
    description: "Sharoma rapida, gustoasa si sanatoasa. Usor de facut, usor de savurat. Mai multa descriere bing bing bing bing bing bing bing bing bing bing bing bing ",
    preparationTime: "30 min",
    dificulty: "Basic",
    numberOfIngredients: 10,
    url: 'https://t3.ftcdn.net/jpg/01/32/05/84/360_F_132058496_aE136Gt4ZP7MC7pzMgyxImJsp4GVmgID.jpg',
}

function RecipeCard() {
    const [recipe, setRecipe] = useState(exempleRecipe)

    return (
        <div style={cardStyle}
            onClick={(e) => console.log("Redirect the user to the recipe page!")}
        >
            <div style={imageSectionStyle}>
                <img src={recipe.url} alt={recipe.title} style={imageStyle} />
            </div>
            <div>
                <h3 style={titleStyle}>{recipe.title}</h3>
                <p style={descriptionStyle}>{recipe.description}</p>
                <div style={detailsStyle}>
                    <div style={detailContainerStyle}>
                        <p style={{ ...paragraphStyle, ...headerDetailStyle }}>Time</p>
                        <p style={{ ...paragraphStyle, ...bodyDetailStyle }}>{recipe.preparationTime}</p>
                    </div>
                    <div style={detailContainerStyle}>
                        <p style={{ ...paragraphStyle, ...headerDetailStyle }}>Difficulty</p>
                        <p style={{ ...paragraphStyle, ...bodyDetailStyle }}>{recipe.dificulty}</p>
                    </div>
                    <div style={detailContainerStyle}>
                        <p style={{ ...paragraphStyle, ...headerDetailStyle }}>Ingredients</p>
                        <p style={{ ...paragraphStyle, ...bodyDetailStyle }}>{recipe.numberOfIngredients}</p>
                    </div>
                </div>

            </div>
        </div>
    )
}

export default memo(RecipeCard);