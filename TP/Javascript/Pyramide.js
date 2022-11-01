/**
 * Afficher dans la console une (moitié de) pyramide ascendante
 * @param {*} hauteurPyramide : Hauteur maximale de la pyramide
 */

 const erigerPyramideAsc = (hauteurPyramide) => {
    let brique = "*"
    for(let i = 1; i<=hauteurPyramide; i++){
        console.log(brique);
        brique += "*"
    }
}

/**
 * Afficher dans la console une (moitié de) pyramide descendante
 * @param {*} hauteurPyramide : Hauteur maximale de la pyramide
 */

const erigerPyramideDesc = (hauteurPyramide) => {
    for(let i = hauteurPyramide; i>=1; i--){
        let brique = construireEtage(i);
        console.log(brique);
    }
}

/**
 * Renvoie une hauteur égale à {nombre}
 * @param {*} nombre : Hauteur maximale de la pyramide
 */

const construireEtage = (nombre) => {
    let etage = "";
    for (let i = 1; i <= nombre; i++){
        etage += "*";
    }
    return etage;
}

/**
 * Afficher dans la console une pyramide dans son intégralité
 * @param {*} nombre : Hauteur maximale de la pyramide
 */

const ConstrGrandePyramide = (valeur) => {
    erigerPyramideAsc(valeur);
    erigerPyramideDesc(valeur-1);
}

ConstrGrandePyramide(12);