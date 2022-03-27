package entities;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @author Emmanuel Vankerkore
 * @date 27/03/2022
 * 
 * La classe Triangle a pour but de définir un triangle qu'il soit quelconque, rectangle, isocéle ou équilatéral.
 */

public class Triangle {
	
	String nom;
	Point2D a;
	Point2D b;
	Point2D c;
	List<Segment> listeSegmentEligible;
	
	/**
	 * On définit notre constructeur de notre classe:
	 * 
	 * @param name : nom que l'on donne à notre triangle
	 * @param p1 : un premier point (classe : Point2D)
	 * @param p2 : un second point (classe : Point2D)
	 * @param p3 : un troisième point (classe : Point2D)
	 * 
	 * @attention Le constructeur ne vérifie pas si les 3 points sont bien distincts.
	 */
	
	public Triangle(String name, Point2D p1, Point2D p2, Point2D p3) {
		setNom(name);
		setA(p1);
		setB(p2);
		setC(p3);
	}
	
	public String getNom() {
		return nom;
	}

	public void setNom(String nom) {
		this.nom = nom;
	}

	public Point2D getA() {
		return a;
	}

	public void setA(Point2D a) {
		this.a = a;
	}

	public Point2D getB() {
		return b;
	}

	public void setB(Point2D b) {
		this.b = b;
	}

	public Point2D getC() {
		return c;
	}

	public void setC(Point2D c) {
		this.c = c;
	}
	
	/**
	 * Un segment est éligible seulement si son équivalent en droite affine n'est pas de la forme suivante:
	 * 		y = p
	 * 		x = p'
	 * 
	 * La méthode renvoie la liste des segments éligibles.
	 * 
	 * @return
	 */
	
	public List<Segment> getListeSegmentEligible(){
		return listeSegmentEligible;
	}
	
	/**
	 *  Un segment est éligible seulement si son équivalent en droite affine n'est pas de la forme suivante:
	 * 		y = p
	 * 		x = p'
	 *  
	 *  La méthode initialise la liste des segments éligibles.
	 */
	
	public void setListeSegmentEligible() {
		this.listeSegmentEligible = getListeSegmentsEligibles(getTousLesSegments());
	}
	
	/**
	 * La méthode affichera toutes les informations assoiciées à l'objet.
	 */
	
	public void afficher() {
		System.out.println(getNom() + " est définit par les 3 points suivants:");
		System.out.print("   ");
		getA().afficher();
		System.out.print("   ");
		getB().afficher();
		System.out.print("   ");
		getC().afficher();
		if (getListeSegmentEligible() != null) {
			System.out.println("Les segments éligible du triangle sont les suivant:");
			for (Segment segment : getListeSegmentEligible()) {
				segment.afficher();
			}
		}
	}

	/**
	 * La méthode récupère dans une liste les 3 segments qui définissent le triangle.
	 * 
	 * @return une liste de points (classe : Point2D)
	 */
	
	public List<Segment> getTousLesSegments(){
		List<Segment> listeDeTousLesSegments = new ArrayList<Segment>();
		listeDeTousLesSegments.add(new Segment("S1", a, b));
		listeDeTousLesSegments.add(new Segment("S2", b, c));
		listeDeTousLesSegments.add(new Segment("S3", c, a));
		return listeDeTousLesSegments;
	}
	
	/**
	 * La méthode renvoie une liste contenant les trois points du triangle
	 * 
	 * @return une liste de points (classe : Point2D)
	 */
	
	public List<Point2D> getTousLesPoints(){
		List<Point2D> lp = new ArrayList<Point2D>();
		lp.add(getA());
		lp.add(getB());
		lp.add(getC());
		return lp;
	}
	
	/**
	 * La méthode renvoie le point qui fait parti du triangle mais n'appartient pas au segment "seg".
	 * 
	 * @param seg : un segment (classe : Segment) du triangle
	 * @return un point (classe : Point2D) du triangle
	 */
	
	public Point2D getPointNonAppartenantSegment(Segment seg) {
		for (Point2D p : getTousLesPoints()) {
			if (seg.getTousLesPoints().contains(p) == false) {
				return p;
			}
		}
		return null;
	}
	
	/**
	 * La méthode identifie si le point "point" appartient à l'un des trois qui définissent le triangle
	 * 
	 * @param point : un point (classe : Point2D)
	 * @return true s'il appartient au triangle sinon alors non
	 */
	
	public Boolean estUnPointDuTriangle(Point2D point) {
		for (Point2D p : getTousLesPoints()) {
			if (p.getX().equals(point.getX()) && p.getY().equals(point.getY())) {
				return true;
			}
		}
		return false;
	}
	
	/**
	 * La méthode identifie si le point "point" appartient à l'un des trois qui définissent le triangle et le
	 * 		renvoie.
	 * 
	 * @param point : un point (classe : Point2D)
	 * @return un point (classe : Point2D) du triangle
	 */
	
	public Point2D PointDuTriangle(Point2D point) {
		for (Point2D p : getTousLesPoints()) {
			if (p.getX().equals(point.getX()) && p.getY().equals(point.getY())) {
				return p;
			}
		}
		return null;
	}
	
	/**
	 * La méthode récupère dans une liste les segments qui vont nous servir dans le calcul de l'aire du triangle.
	 * 
	 * @param segmentEligible : segment éligible (classe Segment)
	 * @param intersection : point (classe : Point2D) correspondant à l'intersection du segment éligible et de la
	 * 						droite affine perpendiculaire calculé avec le point du triangle qui ne fait pas partie
	 * 						du segment.
	 * @return liste des segments (classe : Segment)
	 */
	
	public List<Segment> getListSegmentForCalcul(Segment segmentEligible, Point2D intersection){
		List<Segment> listeSeg = new ArrayList<Segment>(3);
		listeSeg.add(new Segment("GaucheIntersection", segmentEligible.getPointGauche(), intersection));
		listeSeg.add(new Segment("DroiteIntersection", segmentEligible.getPointDroit(), intersection));
		listeSeg.add(new Segment("PointNonSegIntersection", getPointNonAppartenantSegment(segmentEligible), intersection));
		return listeSeg;
	}
	
	/**
	 * La méthode calcul l'aire du triangle dans le cas où notre intersection (segment éligible et droite affine 
	 * perpendiculaire) correspond à un point déjà existant du triangle. Donc on dispose déjà de toutes les
	 * informations en terme de distance.
	 * 
	 * @param segmentEligible : segment éligible (classe Segment)
	 * @param intersection : point (classe : Point2D) correspondant à l'intersection du segment éligible et de la
	 * 						droite affine perpendiculaire calculé avec le point du triangle qui ne fait pas partie
	 * 						du segment.
	 * @return une valeur correpondant à l'aire du triangle
	 */
	
	public Double calculAireTriangleRectangle(Segment segmentEligible, Point2D intersection) {
		Segment segmentEligiblePerpendiculaire = new Segment("SegPer", 
															getPointNonAppartenantSegment(segmentEligible), 
															PointDuTriangle(intersection));
		return segmentEligiblePerpendiculaire.getTaille() * segmentEligible.getTaille() / 2;
	}
	
	/**
	 * La méthode calcul l'aire du triangle dans le cas où notre intersection (segment éligible et droite affine 
	 * perpendiculaire) ne correspond pas à un point du triangle. Donc on a trois règles de calcul différentes
	 * selon le positionnement du point "intersection" par rapport au segment "segmentEligible". Les données
	 * sont toutes stockées dans une map "mapSegDis"
	 * 
	 * @param segmentEligible : segment eligible (classe : Segment)
	 * @param intersection : point (classe : Point2D) correspondant à l'intersection du segment éligible et de la
	 * 						 droite affine perpendiculaire calculé avec le point du triangle qui ne fait pas partie
	 * 						 du segment.
	 * @param mapSegDis : map contenant pour chaque segment sa distance
	 * @return une valeur correpondant à l'aire du triangle
	 */
	
	public Double calculAireTriangleNonRectangle(Segment segmentEligible, Point2D intersection, Map<String, Double> mapSegDis) {
		if (segmentEligible.getDispositionPointFromSegment(intersection) == "centre") {
			return calculAireTriangleNonRectangleVarianteCentre(mapSegDis.get("GaucheIntersection"), 
																mapSegDis.get("DroiteIntersection"), 
																mapSegDis.get("PointNonSegIntersection"));
		} else if (segmentEligible.getDispositionPointFromSegment(intersection) == "gauche") {
			return calculAireTriangleNonRectangleVarianteGauche(mapSegDis.get("GaucheIntersection"), 
																mapSegDis.get("DroiteIntersection"), 
																mapSegDis.get("PointNonSegIntersection"));
		} else if(segmentEligible.getDispositionPointFromSegment(intersection) == "droite") {
			return calculAireTriangleNonRectangleVarianteDroite(mapSegDis.get("GaucheIntersection"), 
																mapSegDis.get("DroiteIntersection"), 
																mapSegDis.get("PointNonSegIntersection"));
		}
		return 0.0;
	}
	
	public Double getAire(Segment segmentEligible, Point2D intersection) {
		if (estUnPointDuTriangle(intersection) == true) { // triangle rectangle
			return calculAireTriangleRectangle(segmentEligible, intersection); 
		} else {
			List<Segment> ls = getListSegmentForCalcul(segmentEligible, intersection);
			Map<String, Double> md = getMapSegmentDistancePourCalcul(ls);
			return calculAireTriangleNonRectangle(segmentEligible, intersection, md);	
		}
	}
	
	public static Boolean estSegmentEligible(Segment segment) {
		if (segment.getPoint1().getX() - segment.getPoint2().getX() != 0.0 &&
				segment.getPoint1().getY() - segment.getPoint2().getY() != 0.0) {
			return true;
		} else {
			return false;
		}
	}
	
	public static List<Segment> getListeSegmentsEligibles(List<Segment> listSeg){
		List<Segment> ls = new ArrayList<Segment>();
		for (Segment segment : listSeg) {
			if (estSegmentEligible(segment)) {
				ls.add(segment);
			}
		}
		return ls;
	}
	
	public static Map<String, Double> getMapSegmentDistancePourCalcul(List<Segment> listeSegments){
		Map<String, Double> mapSegDis = new HashMap<String, Double>();
		for (Segment segment : listeSegments) {
			mapSegDis.put(segment.getName(), segment.getTaille());
		}
		return mapSegDis;
	}
	
	public static Double calculSousRectangle(Double tailleCoteIntersection, 
											Double tailleNonSegIntersection) {
		return (tailleCoteIntersection * tailleNonSegIntersection) / 2;
	}

	public static Double calculAireTriangleNonRectangleVarianteCentre(Double gaucheInter, 
																	Double droiteInter, 
																	Double nonSegInter) {
		return calculSousRectangle(gaucheInter, nonSegInter) + calculSousRectangle(droiteInter, nonSegInter);
	}
	
	public static Double calculAireTriangleNonRectangleVarianteGauche(Double gaucheInter, 
																		Double droiteInter, 
																		Double nonSegInter) {
		return calculSousRectangle(droiteInter, nonSegInter) - calculSousRectangle(gaucheInter, nonSegInter);
	}
	
	public static Double calculAireTriangleNonRectangleVarianteDroite(Double gaucheInter, 
																		Double droiteInter, 
																		Double nonSegInter) {
		return calculSousRectangle(gaucheInter, nonSegInter) - calculSousRectangle(droiteInter, nonSegInter);
	}
}
