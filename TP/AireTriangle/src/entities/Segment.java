package entities;

import java.util.ArrayList;
import java.util.List;

/**
* @author Emmanuel Vankerkore
* @date 27/03/2022
* 
* La classe Segment a pour but de d�finir n'importe quel segment dans un plan en deux dimensions.
*
*/

public class Segment {
	
	String name;
	Point2D point1;
	Point2D point2;

	/**
	 * On d�finit notre constructeur de notre classe:
	 * 
	 * @param nom : un nom que l'on donnera � notre segment
	 * @param pointA : un premier point (classe : Point2D)
	 * @param pointB : un second point (classe : Point2D)
	 */
	
	public Segment(String nom, Point2D pointA, Point2D pointB) {
		setName(nom);
		setPoint1(pointA);
		setPoint2(pointB);
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Point2D getPoint1() {
		return point1;
	}

	public void setPoint1(Point2D point1) {
		this.point1 = point1;
	}

	public Point2D getPoint2() {
		return point2;
	}

	public void setPoint2(Point2D point2) {
		this.point2 = point2;
	}
	
	/**
	 * La m�thode affichera toutes les informations assoici�es � l'objet.
	 */
	
	public void afficher() {
		System.out.println(getName() + " ==> [" + getPoint1().getNom() + " ; " + getPoint2().getNom() + "]");
	}
	
	/**
	 * La m�thode renvoie la diff�rence entre l'abcisse du premier point et le second point.
	 * 
	 * @return La valeur correspondant � la diff�rence
	 */
	
	public Double deltaEnX() {
		return getPoint1().getX() - getPoint2().getX();
	}
	
	/**
	 * La m�thode renvoie la diff�rence entre l'ordonn�e du premier point et le second point.
	 * 
	 * @return La valeur correspondant � la diff�rence
	 */
	
	public Double deltaEnY() {
		return getPoint1().getY() - getPoint2().getY();
	}
	
	/**
	 * La m�thode permet de mettre au carr� une valeur.
	 * 
	 * @param valeur
	 * @return valeur�
	 */
	
	public static Double auCarre(Double valeur) {
		return Math.pow(valeur, 2);
	}
	
	/**
	 * La m�thode renvoie la taille du segment.
	 * 
	 * @return une valeur en unit� arbitraire
	 */
	
	public Double getTaille() {
		return Math.sqrt(auCarre(deltaEnX())+auCarre(deltaEnY()));
	}
	
	/**
	 * La m�thode renvoie le positionnement du point "point" par rapport � l'objet au regard des valeurs en abscisse
	 * 
	 * @param point (classe : Point2D)
	 * @return renvoie l'un des 3 positionnements suivants : "gauche", "centre" ou "droite"
	 */
	
	public String getDispositionPointFromSegment(Point2D point) {
		if (point.getX() <= getPoint1().getX() && point.getX() <= getPoint2().getX()) {
			return "gauche";
		} else if (point.getX() >= getPoint1().getX() && point.getX() >= getPoint2().getX()) {
			return "droite";
		} else {
			return "centre";
		}
	}
	
	/**
	 * La m�thode renvoie le point de l'objet qui se trouve le plus � gauche (valeur d'ascisse la plus basse)
	 * 
	 * @return un des deux points (classe : Point2D) du segment
	 */
	
	public Point2D getPointGauche() {
		if (getPoint1().getX() < getPoint2().getX()) {
			return getPoint1();
		} else {
			return getPoint2();
		}
	}
	
	/**
	 * La m�thode renvoie le point de l'objet qui se trouve le plus � gauche (valeur d'ascisse la plus �lev�e)
	 * 
	 * @return un des deux points (classe : Point2D) du segment
	 */
	
	public Point2D getPointDroit() {
		if (getPoint1().getX() > getPoint2().getX()) {
			return getPoint1();
		} else {
			return getPoint2();
		}
	}
	
	/**
	 * La m�thode renvoie une liste contenant les deux points du segments
	 * 
	 * @return une liste de point (classe : Point2D)
	 */
	
	public List<Point2D> getTousLesPoints(){
		List<Point2D> lp = new ArrayList<Point2D>();
		lp.add(getPoint1());
		lp.add(getPoint2());
		return lp;
	}
	
}
