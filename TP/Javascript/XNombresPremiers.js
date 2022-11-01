/**
 * On affiche dans la console la liste des {quantite} premiers nombres premiers
 * @param {*} quantite : un entier naturel
 */

 const renvoyerXNombresPremiers = (quantite) => {
    let listeNombresPremiers = [];
    let valeur = 1;
    while(!laListeContientNElements(quantite, listeNombresPremiers)){
        if (estUnNombrePremier(compteNombreMultiple(valeur))){
            listeNombresPremiers.push(valeur); 
        }
        valeur++
    }
    console.log(listeNombresPremiers);
};

/**
 * On renvoie le nombre de multiple associé à {valeurEntiere}
 * @param {*} valeurEntiere : Une entier naturel
 */

const compteNombreMultiple = (valeurEntiere) => {
    let compteur = 0;
    for (let i = 1; i<= valeurEntiere; i++){
        if (valeurEntiere%i === 0){
            compteur++;
        }
    }
    return compteur;
}

/**
 * Si {nombreMultiple} = 2 alors renvoie true, false sinon
 * @param {*} nombreMultiple : nombre correspondant à un nombre de multiples
 */

const estUnNombrePremier = (nombreMultiple) => {
    let resultat = false;
    if (nombreMultiple === 2){
        resultat = true;
    }
    return resultat;
}

/**
 * La fonction renvoie true si {liste} contient exactement {valeur} élements, false sinon
 * @param {*} valeur : nombre correspond à un nombre d'éléments de tableau
 * @param {*} liste : nom d'une liste qui contiendra des éléments
 */

const laListeContientNElements = (valeur, liste) => {
    let resultat = false;
    if (liste.length === valeur){
        resultat = true;
    }
    return resultat;
}

renvoyerXNombresPremiers(21);