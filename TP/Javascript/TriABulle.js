let listeNumber = [31, 50, 2, 10, 48, 14, 6, 88, 20, 99, 47, 4, 7];

/**
 * Renvoie une liste dans laquelle on alterne deux valeurs
 * @param {*} liste 
 * @param {*} indice0 
 * @param {*} indice1 
 */

const modifierListeNumber = (liste, indice0, indice1) => {
    let temp = liste[indice0]
    liste[indice0] = liste[indice1];
    liste[indice1] = temp;
    return liste;
}

/**
 * Renvoie le nom de la liste et le nombre de tri réalisé (tri 2 par 2)
 * @param {*} liste 
 */

const realiserSequence = (liste) => {
    let compteur = 0;
    for (let i=0; i<=liste.length-1; i++){
        if (liste[i]>liste[i+1]){
            modifierListeNumber(liste, i, i+1)
            compteur++;
        }
    }
    return [liste, compteur];
}

/**
 * Affiche la liste tri selon la méthode du tri à bulle par séquence 
 * tant qu'il y a eu au moins un changement de réalisé
 * @param {*} listehybride 
 */

const triABulle = (listehybride) => {
    let compteurTotal = 1;
    while (compteurTotal !=0){
        compteurTotal = 0;
        compteurTotal = realiserSequence(listehybride)[1];
    }
    console.log(realiserSequence(listehybride)[0]);
}

triABulle(listeNumber);