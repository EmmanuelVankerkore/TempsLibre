package entites;

import run.Manipulation;

public class Equation {
	
	double a;
	double b;
	double c;
	
	public Equation(double A, double B, double C) throws Exception {
		setA(A);
		setB(B);
		setC(C);
	}
	
	public double getA() {
		return a;
	}
	public void setA(double a) throws Exception {
		if (a == 0) {
			throw new Exception("Si la valeur de A est nulle alors ce n'est pas une équation du second degrés.");
		} else {
			this.a = a;
		}
	}
	public double getB() {
		return b;
	}
	public void setB(double b) {
		this.b = b;
	}
	public double getC() {
		return c;
	}
	public void setC(double c) {
		this.c = c;
	}
	
	public String getFormule() {
		return "Y = " + Manipulation.getSigne2(getA()) 
				+ " X² " + Manipulation.getSigne(getB()) 
				+ " X " + Manipulation.getSigne(getC());
	}
	

}
