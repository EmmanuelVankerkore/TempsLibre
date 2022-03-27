package entities;

/**
* @author Emmanuel Vankerkore
* @date 27/03/2022
* 
* La classe Point2D a pour but de d�finir n'importe quel point de deux dimensions.
*
*/

public class Point2D {
	
	String nom;
	Double x;
	Double y;
	
	/**
	 * On d�finit notre constructeur de notre classe:
	 * 
	 * @param nom : un nom que l'on donnera � notre point.
	 * @param abscisse : l'entier correspondant � l'abscisse de notre point.
	 * @param ordonnee : l'entier correspondant � l'ordonn�e de la droite affine
	 */
	
	public Point2D(String nom, Double abscisse, Double ordonnee) {
		setNom(nom);
		setX(abscisse);
		setY(ordonnee);
	}

	public String getNom() {
		return nom;
	}

	public void setNom(String nom) {
		this.nom = nom;
	}

	public Double getX() {
		return x;
	}

	public void setX(Double x) {
		this.x = x;
	}

	public Double getY() {
		return y;
	}

	public void setY(Double y) {
		this.y = y;
	}

	/**
	 * La m�thode affichera toutes les informations assoici�es � l'objet.
	 */
	
	public void afficher() {
		System.out.println(getNom() + " --> (" + getX() + " ; " + getY() + ")");
	}
}
