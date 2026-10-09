let ingredientIndex = 1;

const container = document.getElementById("ingredienten-container");
const toevoegenKnop = document.getElementById("btn-ingredient");

toevoegenKnop.addEventListener("click", function() {

    const rij = document.createElement("div");
    rij.className = "ingredient-rij";

    rij.innerHTML = `
        <input name="ReceptIngredienten[${ingredientIndex}].Ingredient.Naam"
               type="text"
               placeholder="Bijvoorbeeld: kipfilet">

        <input name="ReceptIngredienten[${ingredientIndex}].Hoeveelheid"
               type="text"
               placeholder="Hoeveelheid">

        <button type="button" class="btn-verwijder">
            Verwijderen
        </button>
    `;

    container.appendChild(rij);

    ingredientIndex++;
});

container.addEventListener("click", function(event) {

    if (event.target.classList.contains("btn-verwijder")) {

        event.target.closest(".ingredient-rij").remove();

        const rijen = container.querySelectorAll(".ingredient-rij");

        rijen.forEach(function(rij, index) {

            const inputs = rij.querySelectorAll("input");

            inputs[0].name = `ReceptIngredienten[${index}].Ingredient.Naam`;
            inputs[1].name = `ReceptIngredienten[${index}].Hoeveelheid`;
        });

        ingredientIndex = rijen.length;
    }
});