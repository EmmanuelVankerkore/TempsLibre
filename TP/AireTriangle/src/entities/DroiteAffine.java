package entities;

/**
 * @author Emmanuel Vankerkore
 * @date 27/03/2022
 * 
 * La classe DroitAffine a pour but de définir une droite affine pour rappel, se définit de la façon suivante:
 * y = ax + b
 * tel que a et b appartiennent à l'ensemble des réels.
 * 
 * Pour des raisons de simplicités nous définirons a et b
 * comme des entiers relatifs.
 *
 */

public class DroiteAffine {
	
	String name;
	Double coef;
	Double constante;
	
	/**
	 * On définit un premier constructeur de notre classe:
	 * 
	 * @param nom : un nom que l'on donnera à notre droite affine
	 * @param a : l'entier correspondant au coefficient de la droite affine
	 * @param b : l'entier correspondant à la constante de la droite affine
	 */
	
	public DroiteAffine(String nom, Double a, Double b) {
		setName(nom);
		setCoef(a);
		setConstante(b);
	}
	
	/**
	 * On définit un second constructeur de notre classe:
	 * 
	 * On utilisera les coordonnées de deux points afin d'y calculer le coefficient et la constante.
	 * 
	 * @param nom : un nom que l'on donnera à notre droite affine
	 * @param a : premier objet appartenant à la classePoint2D
	 * @param b : second objet appartenant à la classe Point2D
	 */
	
	public DroiteAffine(String nom, Point2D a, Point2D b) {
		setName(nom);
		if (a.getX() < b.getX()) {
			setCoef((b.getY()-a.getY())/(b.getX()-a.getX()));
			setConstante(a.getY()-(a.getX()*(b.getY()-a.getY())/(b.getX()-a.getX())));
		} else if (a.getX() > b.getX()){
			setCoef((a.getY()-b.getY())/(a.getX()-b.getX()));
			setConstante(a.getY()-(a.getX()*(a.getY()-b.getY())/(a.getX()-b.getX())));
		}
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Double getCoef() {
		return coef;
	}

	public void setCoef(Double coef) {
		this.coef = coef;
	}

	public Double getConstante() {
		return constante;
	}

	public void setConstante(Double constante) {
		this.constante = constante;
	}

	/**
	 * La méthode affichera toutes les informations assoiciées à l'objet.
	 */
	
	public void afficher() {
		if (getConstante() >= 0.0) { // Deux affichages différents selon la valeur de la constante
			System.out.println("(" + getName() + ") : y = " + getCoef() + " x + " + getConstante());
		} else {
			System.out.println("(" + getName() + ") : y = " + getCoef() + " x - " + (-getConstante()));
		}	
	}
	
	/**
	 * La méthode renvoie une droite affine correspondant à la projection orthogonale par rapport à un point.
	 * 
	 * @param point : un point (classe : Point2D)
	 * @return une droite (classe : DroiteAffine)
	 */
	
	public DroiteAffine getDroiteAffinePerpendiculaireFromPoint(Point2D point) {
		return new DroiteAffine(getName().concat("_2"), -1/getCoef(), point.getY() + (1/getCoef())*point.getX());
	}
	
	/**
	 * La méthode renvoie une chaine de caractère correspondant au nom que l'on donnera au point correspondant
	 * à l'intersection deux droites.
	 * 
	 * @param d : une droite (classe : DroiteAffine)
	 * @return un nom pour le point d'intersection
	 */
	
	public String getNameIntersection(DroiteAffine d) {
		return "Intersection-".concat(getName()).concat("-").concat(d.getName());
	}
	
	/**
	 * La méthode renvoie la valeur de l'abscisse correspondant au point d'intersection des deux droites affines.
	 * 
	 * @param d : une droite (classe : DroiteAffine) que l'on croise avec notre objet
	 * @return l'abcisse du point d'intersection
	 */
	
	public Double getDimXOfIntersectionAvec(DroiteAffine d) {
		return (getConstante() - d.getConstante())/(d.getCoef() - getCoef());
	}
	
	/**
	 * La méthode renvoie la valeur de la coordonnée correspondant au point d'intersection des deux droites affines.
	 * 
	 * @param d : une droite (classe : DroiteAffine) que l'on croise avec notre objet
	 * @return la coordonnée du point d'intersection
	 */
	
	public Double getDimYOfIntersectionAvec(DroiteAffine d) {
		return (d.getCoef()*getConstante() - getCoef()*d.getConstante()) / (d.getCoef() - getCoef());
	}
	
	/**
	 * La méthode renvoie un point correspondant à l'intersection de notre objet et de la droite affine d
	 * 
	 * @param d : une droite (classe : DroiteAffine) que l'on croise avec notre objet
	 * @return un nouveau point (classe : Point2D)
	 */
	
	public Point2D getPointIntersection(DroiteAffine d) {
		return new Point2D(getNameIntersection(d), getDimXOfIntersectionAvec(d), getDimYOfIntersectionAvec(d));
	}
}
