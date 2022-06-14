import { useState, memo } from 'react';
import { cardStyle, imageSectionStyle, titleStyle, descriptionStyle, detailsStyle, detailContainerStyle, paragraphStyle, imageStyle, headerDetailStyle, bodyDetailStyle } from './RecipeCardStyle.module.js';

function RecipeCard(props) {
    const [recipe, setRecipe] = useState(props.recipe);

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