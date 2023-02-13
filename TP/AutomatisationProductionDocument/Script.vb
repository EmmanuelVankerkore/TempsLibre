Option Explicit

Public Const chemin = "\\ad.univ-lille.fr\personnels\users\20530\Bureau\Déménagement\Avant mon départ ODiF\RECHERCHE - ecriture de fichier (log)\"

'======================
' Procédure principale
'======================

'Procédure qui va produire un document txt contenant une base agrégé

Public Sub redige_base_agregee()

    'Déclaration des collections
    Dim collec_etu As Collection

    'Déclaration des objets
    Dim instance_etudiant As C_etudiants
    Dim instance_parcours As C_parcours

    'déclaration des feuilles
    Dim f_para As Worksheet
    Dim f_base As Worksheet
    Dim f_cond As Worksheet

    'Déclaration des tableaux
    Dim tab_source_base() As Variant
    Dim tab_source_tdc() As Variant
    Dim tab_var_quanti() As String
    Dim tab_code_val() As String
    Dim tab_parcours() As String
    Dim tab_base_agr() As Variant
    
    'déclaration des entiers
    Dim i, j, k As Integer
    
    Dim nb_etudiants As Integer
    Dim nb_var_quanti As Integer
    
    Dim num_der_col_base As Integer
    Dim num_der_ligne_base As Integer
    Dim num_col_var_agr As Integer
    Dim num_der_ligne_cond As Integer
    
    Dim taille_tab_code_val As Integer
    Dim taille_tab_parcours As Integer
    
    Dim numfich As Integer
    
    'déclaration des chaines de caractères
    Dim nom_variable_agr As String
    Dim moda_variable_agr As String
    Dim nom_lettre_der_col_base As String
    
    'déclaration des variables issues de la base de données
    
    '======================================================
    '=== Partie 1 : Déclaration des variables individus ===
    '======================================================
    
        '<!> Début <!>

    Dim Situation As String
    Dim q6_7 As String
    Dim repondant As String
    Dim FIFC As String
    Dim dip_sup As String
    Dim contrat As String
    Dim niveau As String
    Dim employeur As String
    Dim revenu As Variant
    Dim lieu_emp As String
    Dim tps_acces1 As Variant
    Dim satis_LP As String
    Dim Poursuite_quand As String
    Dim lieu_poursuite As String
    
        '<!> Fin <!>

    Application.ScreenUpdating = False
    Application.Calculation = xlCalculationManual
    
    'Allocation de l'espace mémoire
    Set f_para = Worksheets("Paramètre")
    Set f_base = Worksheets("Base de données")
    Set f_cond = Worksheets("Test_des_conditions")
    
    'On récupère l'heure qu'il est avant exécution de la macro créant la base agrégée
    f_cond.Range("K16").Value = TempsAvecCentiemesDeSeconde
    
    'On stock dans un tableau la base de données sources
    num_der_ligne_base = f_base.Range("A1").End(xlDown).Row
    nb_etudiants = num_der_ligne_base - 1
    num_der_col_base = f_base.Range("A1").End(xlToRight).Column
    nom_lettre_der_col_base = Fonctions.LettreColonne(num_der_col_base)
    ReDim tab_source_base(num_der_ligne_base, num_der_col_base)
    tab_source_base = f_base.Range("A1:" & nom_lettre_der_col_base & CStr(num_der_ligne_base)).Value
    
    'On stock dans un tableau les conditions de calcul
    num_der_ligne_cond = f_cond.Range("A1").End(xlDown).Row
    ReDim tab_source_tdc(num_der_ligne_cond, 4)
    tab_source_tdc = f_cond.Range("A1:D" & CStr(num_der_ligne_cond)).Value
    
    'On stock dans un tableau les codes valeurs
    taille_tab_code_val = 1
    ReDim tab_code_val(0)
    tab_code_val(0) = tab_source_tdc(2, 1)
    i = 3
    Do While i <> num_der_ligne_cond + 1
        If tab_source_tdc(i - 1, 1) <> tab_source_tdc(i, 1) Then
            taille_tab_code_val = taille_tab_code_val + 1
            ReDim Preserve tab_code_val(taille_tab_code_val - 1)
            tab_code_val(taille_tab_code_val - 1) = tab_source_tdc(i, 1)
        End If
        i = i + 1
    Loop

    'On stock dans un tableau les parcours
    nom_variable_agr = f_para.Range("B1").Value
    For i = 1 To num_der_col_base Step 1
        If tab_source_base(1, i) = nom_variable_agr Then
            num_col_var_agr = i
            Exit For
        End If
    Next i
    taille_tab_parcours = 1
    ReDim tab_parcours(0)
    tab_parcours(0) = tab_source_base(2, num_col_var_agr)
    i = 3
    Do While i <> num_der_ligne_base + 1
        If tab_source_base(i - 1, num_col_var_agr) <> tab_source_base(i, num_col_var_agr) Then
            taille_tab_parcours = taille_tab_parcours + 1
            ReDim Preserve tab_parcours(taille_tab_parcours - 1)
            tab_parcours(taille_tab_parcours - 1) = tab_source_base(i, num_col_var_agr)
        End If
        i = i + 1
    Loop

    'On stock dans un tableau qui contiendra la base agrégée des résultats agrégés
    ReDim tab_base_agr(taille_tab_parcours + 1, taille_tab_code_val + 1)
    For i = 1 To taille_tab_parcours Step 1
        tab_base_agr(i + 1, 1) = tab_parcours(i - 1)
    Next i
    For i = 1 To taille_tab_code_val Step 1
        tab_base_agr(1, i + 1) = tab_code_val(i - 1)
    Next i
    
    i = 1 'indice de l'individu
    k = 1 'indice du parcours
    
    Do While i <> nb_etudiants + 1
    
		'On crée une instance parcours
        Set instance_parcours = New C_parcours
        instance_parcours.nom_parcours = tab_source_base(i + 1, 15)
        Set collec_etu = New Collection
        j = 1
        
        Do
        
            '=======================================================
            '=== Partie 2 : attribution des propriétés individus ===
            '=======================================================
            
                '<!> Début <!>
                
			'On crée une instance étudiant
            Set instance_etudiant = New C_etudiants
            
            instance_etudiant.Situation = tab_source_base(i + 1, 1)
            instance_etudiant.q6_7 = tab_source_base(i + 1, 2)
            instance_etudiant.repondant = tab_source_base(i + 1, 3)
            instance_etudiant.FIFC = tab_source_base(i + 1, 4)
            instance_etudiant.dip_sup = tab_source_base(i + 1, 5)
            instance_etudiant.contrat = tab_source_base(i + 1, 6)
            instance_etudiant.niveau = tab_source_base(i + 1, 7)
            instance_etudiant.employeur = tab_source_base(i + 1, 8)
            instance_etudiant.revenu = tab_source_base(i + 1, 9)
            instance_etudiant.lieu_emp = tab_source_base(i + 1, 10)
            instance_etudiant.tps_acces1 = tab_source_base(i + 1, 11)
            instance_etudiant.satis_LP = tab_source_base(i + 1, 12)
            instance_etudiant.Poursuite_quand = tab_source_base(i + 1, 13)
            instance_etudiant.lieu_poursuite = tab_source_base(i + 1, 14)
            instance_etudiant.diplome_repertoire = tab_source_base(i + 1, 15)
            
                '<!> Fin <!>
            
			'On alimente une liste d'instance d'étudiants
            collec_etu.Add Item:=instance_etudiant, Key:=CStr(j)
            j = j + 1
            i = i + 1
            
            If i = nb_etudiants + 1 Then
                Exit Do
            End If
            
        Loop While tab_source_base(i + 1, 15) = instance_parcours.nom_parcours
        
        Set instance_parcours.collec_etu = collec_etu
        
        '==================================================
        '=== Partie 3 : Alimentation de la base agrégée ===
        '==================================================
        
            '<!> Début <!>
        
        tab_base_agr(k + 1, 2) = instance_parcours.valeur_cd_V1()
        tab_base_agr(k + 1, 3) = instance_parcours.valeur_cd_V2()
        tab_base_agr(k + 1, 4) = instance_parcours.valeur_cd_V3()
        tab_base_agr(k + 1, 5) = instance_parcours.valeur_cd_V4()
        tab_base_agr(k + 1, 6) = instance_parcours.valeur_cd_V5()
        tab_base_agr(k + 1, 7) = instance_parcours.valeur_cd_V6()
        tab_base_agr(k + 1, 8) = instance_parcours.valeur_cd_V7()
        tab_base_agr(k + 1, 9) = instance_parcours.valeur_cd_V8()
        tab_base_agr(k + 1, 10) = instance_parcours.valeur_cd_V9()
        tab_base_agr(k + 1, 11) = instance_parcours.valeur_cd_V10()
        tab_base_agr(k + 1, 12) = instance_parcours.valeur_cd_V11()
        tab_base_agr(k + 1, 13) = instance_parcours.valeur_cd_V12()
        tab_base_agr(k + 1, 14) = instance_parcours.valeur_cd_V13()
        tab_base_agr(k + 1, 15) = instance_parcours.valeur_cd_V14()
        tab_base_agr(k + 1, 16) = instance_parcours.valeur_cd_V15()
        tab_base_agr(k + 1, 17) = instance_parcours.valeur_cd_V16()
        tab_base_agr(k + 1, 18) = instance_parcours.valeur_cd_V17()
        tab_base_agr(k + 1, 19) = instance_parcours.valeur_cd_V18()
        tab_base_agr(k + 1, 20) = instance_parcours.valeur_cd_V19()
        tab_base_agr(k + 1, 21) = instance_parcours.valeur_cd_V22()
        tab_base_agr(k + 1, 22) = instance_parcours.valeur_cd_V23()
        tab_base_agr(k + 1, 23) = instance_parcours.valeur_cd_V24()
        tab_base_agr(k + 1, 24) = instance_parcours.valeur_cd_V25()
        tab_base_agr(k + 1, 25) = instance_parcours.valeur_cd_V26()
        tab_base_agr(k + 1, 26) = instance_parcours.valeur_cd_V27()
        tab_base_agr(k + 1, 27) = instance_parcours.valeur_cd_V28()
        
            '<!> Fin <!>
        
        k = k + 1
    
    Loop
	
	'=====================================================================
	'=== Partie 4 : Création d'un fichier contenant cette base agrégée ===
	'=====================================================================
    
    numfich = FreeFile
    
    Open chemin & "IP_LP_base_agrégée_générée.csv" For Output As numfich
    
    For i = 1 To taille_tab_parcours + 1 Step 1
        For j = 1 To taille_tab_code_val + 1 Step 1
            If j = 1 Then
                Print #numfich, tab_base_agr(i, j);
            Else
                Print #numfich, ";" & tab_base_agr(i, j);
            End If
        Next j
        Print #numfich, vbCrLf;
    Next i
    
    Close numfich
    
    f_cond.Range("K17").Value = TempsAvecCentiemesDeSeconde

    'désallocation de l'espace mémoire
    Set f_para = Nothing
    Set f_base = Nothing
    Set f_cond = Nothing

    Application.ScreenUpdating = True
    Application.Calculation = xlCalculationAutomatic
	
End Sub

'===================
' Instance étudiant
'===================

'Déclaration des attributs de l'objet étudiant

Private CSituation As String
Private Cq6_7 As String
Private Crepondant As String
Private CFIFC As String
Private Cdip_sup As String
Private Ccontrat As String
Private Cniveau As String
Private Cemployeur As String
Private Crevenu As Variant
Private Clieu_emp As String
Private Ctps_acces1 As Variant
Private Csatis_LP As String
Private CPoursuite_quand As String
Private Clieu_poursuite As String
Private Cdiplome_repertoire As String

'Propriété en écriture

Property Let Situation(Situation As String)
    CSituation = Situation
End Property

Property Let q6_7(q6_7 As String)
    Cq6_7 = q6_7
End Property

Property Let repondant(repondant As String)
    Crepondant = repondant
End Property

Property Let FIFC(FIFC As String)
    CFIFC = FIFC
End Property

Property Let dip_sup(dip_sup As String)
    Cdip_sup = dip_sup
End Property

Property Let contrat(contrat As String)
    Ccontrat = contrat
End Property

Property Let niveau(niveau As String)
    Cniveau = niveau
End Property

Property Let employeur(employeur As String)
    Cemployeur = employeur
End Property

Property Let revenu(revenu As Variant)
    Crevenu = revenu
End Property

Property Let lieu_emp(lieu_emp As String)
    lieu_empC = lieu_emp
End Property

Property Let tps_acces1(tps_acces1 As Variant)
    Ctps_acces1 = tps_acces1
End Property

Property Let satis_LP(satis_LP As String)
    Csatis_LP = satis_LP
End Property

Property Let Poursuite_quand(Poursuite_quand As String)
    CPoursuite_quand = Poursuite_quand
End Property

Property Let lieu_poursuite(lieu_poursuite As String)
    Clieu_poursuite = lieu_poursuite
End Property

Property Let diplome_repertoire(diplome_repertoire As String)
    Cdiplome_repertoire = diplome_repertoire
End Property

'Propriété en lecture

Property Get Situation() As String
    Situation = CSituation
End Property

Property Get q6_7() As String
    q6_7 = Cq6_7
End Property

Property Get repondant() As String
    repondant = Crepondant
End Property

Property Get FIFC() As String
    FIFC = CFIFC
End Property

Property Get dip_sup() As String
    dip_sup = Cdip_sup
End Property

Property Get contrat() As String
    contrat = Ccontrat
End Property

Property Get niveau() As String
    niveau = Cniveau
End Property

Property Get employeur() As String
    employeur = Cemployeur
End Property

Property Get revenu() As Variant
    revenu = Crevenu
End Property

Property Get lieu_emp() As String
    lieu_empC = Clieu_emp
End Property

Property Get tps_acces1() As Variant
    tps_acces1 = Ctps_acces1
End Property

Property Get satis_LP() As String
    satis_LP = Csatis_LP
End Property

Property Get Poursuite_quand() As String
    Poursuite_quand = CPoursuite_quand
End Property

Property Get lieu_poursuite() As String
    lieu_poursuite = Clieu_poursuite
End Property

Property Get diplome_repertoire() As String
    diplome_repertoire = Cdiplome_repertoire
End Property

'Les fonctions de calcul relative aux propriétés

Public Function est_valide_cd_V1() As Boolean
    est_valide_cd_V1 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" Then
            est_valide_cd_V1 = True
    End If
End Function

Public Function est_valide_cd_V2() As Boolean
    est_valide_cd_V2 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En recherche d'emploi" Then
            est_valide_cd_V2 = True
    End If
End Function

Public Function est_valide_cd_V3() As Boolean
    est_valide_cd_V3 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En études" Then
            est_valide_cd_V3 = True
    End If
End Function

Public Function est_valide_cd_V4() As Boolean
    est_valide_cd_V4 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "Autre situation" Then
            est_valide_cd_V4 = True
    End If
End Function

Public Function est_valide_cd_V5() As Boolean
    est_valide_cd_V5 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" Then
            est_valide_cd_V5 = True
    End If
End Function

Public Function est_valide_cd_V6() As Boolean
    est_valide_cd_V6 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And (Situation = "En emploi" _
            Or Situation = "En recherche d'emploi") Then
                est_valide_cd_V6 = True
    End If
End Function

Public Function est_valide_cd_V7() As Boolean
    est_valide_cd_V7 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And contrat = "Emploi stable" Then
            est_valide_cd_V7 = True
    End If
End Function

Public Function est_valide_cd_V8() As Boolean
    est_valide_cd_V8 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And niveau = "Cadre" Then
            est_valide_cd_V8 = True
    End If
End Function

Public Function est_valide_cd_V9() As Boolean
    est_valide_cd_V9 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And niveau = "Profession intermédiaire" Then
            est_valide_cd_V9 = True
    End If
End Function

Public Function est_valide_cd_V10() As Boolean
    est_valide_cd_V10 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And q6_7 = "Temps plein" Then
            est_valide_cd_V10 = True
    End If
End Function

Public Function est_valide_cd_V11() As Boolean
    est_valide_cd_V11 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And q6_7 = "Temps plein" _
        And revenu <> "NUL" Then
            est_valide_cd_V11 = True
    End If
End Function

Public Function est_valide_cd_V12() As Boolean
    est_valide_cd_V12 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And employeur = "Secteur privé" Then
            est_valide_cd_V12 = True
    End If
End Function

Public Function est_valide_cd_V13() As Boolean
    est_valide_cd_V13 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And employeur = "Secteur public" Then
            est_valide_cd_V13 = True
    End If
End Function

Public Function est_valide_cd_V14() As Boolean
    est_valide_cd_V14 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And employeur = "Secteur associatif" Then
            est_valide_cd_V14 = True
    End If
End Function

Public Function est_valide_cd_V15() As Boolean
    est_valide_cd_V15 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And lieu_emp = "Métropole Européenne de Lille" Then
            est_valide_cd_V15 = True
    End If
End Function

Public Function est_valide_cd_V16() As Boolean
    est_valide_cd_V16 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And lieu_emp = "Nord sans précision" Then
            est_valide_cd_V16 = True
    End If
End Function

Public Function est_valide_cd_V17() As Boolean
    est_valide_cd_V17 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And (lieu_emp = "Picardie" _
            Or lieu_emp = "Pas-de-Calais" _
            Or lieu_emp = "Autre Nord") Then
                est_valide_cd_V17 = True
    End If
End Function

Public Function est_valide_cd_V18() As Boolean
    est_valide_cd_V18 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And lieu_emp = "Autre France" Then
            est_valide_cd_V18 = True
    End If
End Function

Public Function est_valide_cd_V19() As Boolean
    est_valide_cd_V19 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And lieu_emp = "Autre France" Then
            est_valide_cd_V19 = True
    End If
End Function

Public Function est_valide_cd_V22() As Boolean
    est_valide_cd_V22 = False
    If FIFC = "Formation initiale" _
        And repondant = "oui" _
        And satis_LP = "Oui" Then
            est_valide_cd_V22 = True
    End If
End Function

Public Function est_valide_cd_V23() As Boolean
    est_valide_cd_V23 = False
    If FIFC = "Formation initiale" _
        And repondant = "oui" _
        And satis_LP = "Non" Then
            est_valide_cd_V23 = True
    End If
End Function

Public Function est_valide_cd_V24() As Boolean
    est_valide_cd_V24 = False
    If FIFC = "Formation initiale" _
        And repondant = "oui" Then
            est_valide_cd_V24 = True
    End If
End Function

Public Function est_valide_cd_V25() As Boolean
    est_valide_cd_V25 = False
    If FIFC = "Formation initiale" _
        And repondant = "oui" _
        And Poursuite_quand = "Immédiate" Then
            est_valide_cd_V25 = True
    End If
End Function

Public Function est_valide_cd_V26() As Boolean
    est_valide_cd_V26 = False
    If FIFC = "Formation initiale" _
        And repondant = "oui" _
        And lieu_poursuite = "Immédiate" Then
            est_valide_cd_V26 = True
    End If
End Function

Public Function est_valide_cd_V27() As Boolean
    est_valide_cd_V27 = False
    If FIFC = "Formation initiale" _
        And dip_sup = "non" _
        And repondant = "oui" _
        And Situation = "En emploi" _
        And Poursuite_quand = "Pas de poursuite" _
        And tps_acces1 <> "NUL" Then
                est_valide_cd_V27 = True
    End If
End Function

Public Function est_valide_cd_V28() As Boolean
    est_valide_cd_V28 = False
    If FIFC <> "Formation continue" Then
        est_valide_cd_V28 = True
    End If
End Function

'Création de tous les objets parcours
Public Sub informations_données_sources()
    MsgBox "   *** Individu " & ID & " ***" & vbCrLf & vbCrLf & vbCrLf & _
            "FIFC : " & FIFC & vbCrLf & _
            "Repondant : " & repondant & vbCrLf & _
            "dip_sup : " & dip_sup & vbCrLf & _
            "Situation : " & Situation & vbCrLf & _
            "niveau : " & niveau & vbCrLf & vbCrLf & _
            "cd_v8 est " & cd_V8 & vbCrLf & _
            "cd_v9 est " & cd_V9
End Sub

'===================
' Instance parcours
'===================

'Déclaration des attributs

Private Cnom_parcours As String
Private Ccollec_etu As Collection

'propriété en écriture

Property Let nom_parcours(nom_parcours As String)
    Cnom_parcours = nom_parcours
End Property

Property Set collec_etu(ByRef collec_etu As Collection)
    Set Ccollec_etu = collec_etu
End Property

'Propriété en lecture

Property Get nom_parcours() As String
    nom_parcours = Cnom_parcours
End Property

Property Get collec_etu() As Collection
    Set collec_etu = Ccollec_etu
End Property

'Fonction et procédure

Public Function valeur_cd_V1() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V1 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V1 = compteur
End Function

Public Function valeur_cd_V2() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V2 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V2 = compteur
End Function

Public Function valeur_cd_V3() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V3 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V3 = compteur
End Function

Public Function valeur_cd_V4() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V4 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V4 = compteur
End Function

Public Function valeur_cd_V5() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V5 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V5 = compteur
End Function

Public Function valeur_cd_V6() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V6 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V6 = compteur
End Function

Public Function valeur_cd_V7() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V7 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V7 = compteur
End Function

Public Function valeur_cd_V8() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V8 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V8 = compteur
End Function

Public Function valeur_cd_V9() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V9 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V9 = compteur
End Function

Public Function valeur_cd_V10() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V10 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V10 = compteur
End Function

Public Function valeur_cd_V11() As Variant
    Dim o As Object
    Dim tab_stat() As Single
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V11 Then
            compteur = compteur + 1
            ReDim Preserve tab_stat(compteur - 1)
            tab_stat(compteur - 1) = o.revenu
        End If
    Next o
    
    Set o = Nothing
    
    If compteur <> 0 Then
        valeur_cd_V11 = Application.Median(tab_stat)
    Else
        valeur_cd_V11 = "NR"
    End If
End Function

Public Function valeur_cd_V12() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V12 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V12 = compteur
End Function

Public Function valeur_cd_V13() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V13 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V13 = compteur
End Function

Public Function valeur_cd_V14() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V14 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V14 = compteur
End Function

Public Function valeur_cd_V15() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V15 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V15 = compteur
End Function

Public Function valeur_cd_V16() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V16 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V16 = compteur
End Function

Public Function valeur_cd_V17() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V7 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V17 = compteur
End Function

Public Function valeur_cd_V18() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V18 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V18 = compteur
End Function

Public Function valeur_cd_V19() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V19 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V19 = compteur
End Function

Public Function valeur_cd_V22() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V22 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V22 = compteur
End Function

Public Function valeur_cd_V23() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V23 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V23 = compteur
End Function

Public Function valeur_cd_V24() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V24 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V24 = compteur
End Function

Public Function valeur_cd_V25() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V25 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V25 = compteur
End Function

Public Function valeur_cd_V26() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V26 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V26 = compteur
End Function

Public Function valeur_cd_V27() As Variant
    Dim o As Object
    Dim tab_stat() As Single
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V27 Then
            compteur = compteur + 1
            ReDim Preserve tab_stat(compteur - 1)
            tab_stat(compteur - 1) = o.tps_acces1
        End If
    Next o
    
    Set o = Nothing
    
    If compteur <> 0 Then
        valeur_cd_V27 = Application.Average(tab_stat)
    Else
        valeur_cd_V27 = "NR"
    End If
    
End Function

Public Function valeur_cd_V28() As Integer
    Dim o As Object
    Dim compteur As Integer
    
    compteur = 0
    
    For Each o In collec_etu
        If o.est_valide_cd_V28 Then
            compteur = compteur + 1
        End If
    Next o
    
    Set o = Nothing
    
    valeur_cd_V28 = compteur
End Function

__S1__

'======================================================
'Source : https://warin.developpez.com/access/fichiers/
'======================================================

Public Sub read_first_line()
    Dim intFic As Integer
    Dim strLigne As String
    
    intFic = FreeFile
    
    Open "\\ad.univ-lille.fr\personnels\users\20530\Bureau\Déménagement\Avant mon départ ODiF\RECHERCHE - ecriture de fichier (log)\test_base.csv" For Input As intFic
    Line Input #intFic, strLigne
    
    MsgBox strLigne
    
    Close intFic
End Sub

Public Sub read_all_line()
    Dim intFic As Integer
    Dim strLigne As String
    
    intFic = FreeFile
    
    Open "\\ad.univ-lille.fr\personnels\users\20530\Bureau\Déménagement\Avant mon départ ODiF\RECHERCHE - ecriture de fichier (log)\test_base.csv" For Input As intFic
    While Not EOF(intFic)
        Line Input #intFic, strLigne
        MsgBox strLigne
    Wend
    
    Close intFic
End Sub

Public Sub write_file_empty()
    Dim intFic As Integer

    intFic = FreeFile
    
    Open "D:\essai\monfichier.txt" For Output As intFic
    
    Print #intFic, "Une ligne"
    
    Close intFic
End Sub

Public Sub write_file_not_empty()
    Dim intFic As Integer

    intFic = FreeFile
    
    Open "D:\essai\monfichier.txt" For Append As intFic
    
    Print #intFic, "Une ligne"
    
    Close intFic
End Sub

Public Sub internet_from()
    Dim MyIndex, FileNumber
    For MyIndex = 1 To 5    ' Loop 5 times.
        FileNumber = FreeFile    ' Get unused file
            ' number.
        Open "TEST" & MyIndex For Output As #FileNumber    ' Create file name.
        Write #FileNumber, "This is a sample."    ' Output text.
        Close #FileNumber    ' Close file.
End Sub

Public Sub internet_from2()
    Dim numfich As Long, c As Range
    numfich = FreeFile
    Open "C:\Users\Eric\Desktop\" & [A1] & ".txt" For Output As #numfich
    For Each c In [A1:A4]
        Print #numfich, c.Value & vbCrLf;
        ' ou
        'Print #numfich, c.Text & vbCrLf;
        'si tu as des arrondis à l'affichage que tu désires conserver
        'par exemple 7.786 affiché 7.79 mais dans le fichier ça sera : "7.79"
    Next c
    Close #numfich
End Sub

Public Sub custom_log_build()
    Dim i As Long
    Dim numfich As Long
    Dim tab_log(4000000, 1) As String
    
    i = 1
    
    'Création d'un tableau quelconque
    For i = 1 To 4000000 Step 1
        tab_log(i, 1) = "Aléatoire " & i & " : " & CStr(Round(Rnd, 2))
    Next i
    
    'On affecte à la variable numfich une valeur numérique correspondant à un numéro de fichier non utilisé (libre)
    numfich = FreeFile
    
    'Si le fichier n'existe pas encore il le crée sinon il le modifie
    Open "D:\Professionnel\Fiches\Journal.txt" For Output As #numfich
    
    'Pour chaque valeur du tableau quelconque on le rédige dans le fichier en allant à la ligne à chaque fois
    For i = 1 To 4000000 Step 1
        Print #numfich, tab_log(i, 1) & vbCrLf;
    Next i
    
    'Il semblerai que pour appeler le fichier il faut procéder ainsi :
    '       #[nom de la variable qui renvoie à la valeur du FreeFile]
    Close #numfich
End Sub

Public Sub Produire_log_from_tab(ByVal chemin As String, _
                                 ByVal tableau As Variant)
    Dim i As Long
    Dim mini As Byte, maxi As Long
    Dim numfich As Long
    
    mini = LBound(tableau, 1)
    maxi = UBound(tableau, 1)
    numfich = FreeFile
    
    Open chemin For Output As #numfich
    
    For i = mini To maxi Step 1
        Print #numfich, tableau(i, 1) & vbCrLf;
    Next i
    
    Close #numfich
End Sub

Public Sub Produire_tab_txt(ByVal fichier As String, _
                            ByVal tableau As Variant)
    Dim i, j As Long
    Dim mini_i, mini_j As Byte
    Dim maxi_i, maxi_j As Long
    Dim numfich As Long
    
    mini_i = LBound(tableau, 1)
    maxi_i = UBound(tableau, 1)
    mini_j = LBound(tableau, 2)
    maxi_j = UBound(tableau, 2)
    
    numfich = FreeFile
    
    Open fichier For Output As #numfich
    
    For i = mini_i To maxi_i Step 1
        For j = mini_j To maxi_j Step 1
            Print #numfich, tableau(i, j) & " ";
        Next j
        Print #numfich, vbCrLf;
    Next i
    
    Close #numfich
    
End Sub

__S2__

'================================================================================
'Source : https://excel-malin.com/faq/vba-faq/obtenir-temps-en-millisecondes-vba/
'================================================================================

Public Function TempsAvecCentiemesDeSeconde() As String
    'par Excel-Malin.com ( https://excel-malin.com )

    On Error GoTo Erreur

    Dim Maintenant As Date
    Maintenant = Now()

    TempsAvecCentiemesDeSeconde = Format(Maintenant, "hh:mm:ss:") & Right(Format(Timer, "#0.00"), 2)
    Exit Function

    Erreur:
    TempsAvecCentiemesDeSeconde = ""
End Function

__C1__

'===============================
' module : Chaine de caractères
'===============================

'Fonction qui renvois une chaine de caractère mais sans ces espaces

Public Function retire_les_espaces(ByVal cdc As String) As String
    Dim comp_espace As Integer
    Dim esp_suppr As Integer
    Dim i As Integer
    
    comp_espace = 0
    esp_suppr = 0

    'on récupere le nombre d'espace présent dans la chaine de caractère
    For i = 1 To Len(cdc) Step 1
        If Mid(cdc, i, 1) = " " Then
            comp_espace = comp_espace + 1
        End If
    Next i
    
    i = 1
    'on va faire une boucle qui va supprimer les espaces
    Do While esp_suppr <> comp_espace
        If Mid(cdc, i, 1) = " " Then
            If i = 1 Then
                cdc = Mid(cdc, 2)
            ElseIf i = Len(cdc) Then
                cdc = Mid(cdc, 1, Len(cdc) - 1)
            Else
                cdc = Mid(cdc, 1, i - 1) + Mid(cdc, i + 1)
            End If
            esp_suppr = esp_suppr + 1
        End If
        i = i + 1
    Loop
    
    retire_les_espaces = cdc
End Function

'Fonction qui renvoie la position du premier chiffre à partir d'une cellule

Public Function indice_first_chiffre(ByVal cellule As String) As Integer
    Dim i As Integer
    For i = 1 To Len(cellule) Step 1
        lettre = Mid(cellule, i, 1)
        If Asc(lettre) <= 57 And Asc(lettre) >= 48 Then
            indice_first_chiffre = i
            Exit For
        End If
    Next i
End Function

'Fonction qui renvoie le nombre de caractères alphabétiques consécutifs en debut de chaine

Public Function nb_lettre_debut(ByVal cellule As String) As Integer
    Dim i, compteur As Integer
    
    compteur = 0
    
    For i = 1 To Len(cellule) Step 1
        lettre = Mid(cellule, i, 1)
        If Asc(lettre) <= 90 And Asc(lettre) >= 65 Then
            compteur = compteur + 1
        Else
            nb_lettre_debut = compteur
            Exit For
        End If
    Next i
End Function

'Fonction qui retourne une plage de donnée éligible au tri

Public Function transforme_en_cellule_verou(ByVal cellule As String) As String
    Dim val As Integer
    val = indice_first_chiffre(cellule)
    transforme_en_cellule_verou = "$" + Left(cellule, val - 1) + "$" + Mid(cellule, val)
End Function

'Fonction qui renvoie la valeur numérique d'une cellule

Public Function part_numerique_cellule(ByVal cellule As String) As Integer
    Dim ind As Integer
    ind = indice_first_chiffre(cellule)
    part_numerique_cellule = CInt(Mid(cellule, ind))
End Function

'Fonction qui renvoie la valeur alphabétique d'une cellule

Public Function part_alphabetique_cellule(ByVal cellule As String) As String
    Dim ind As Integer
    ind = nb_lettre_debut(cellule)
    part_alphabetique_cellule = Left(cellule, ind)
End Function

'Fonction qui renvoie une chaine de caractère en remplaçant le carcatère X par le caractère Y

Public Function remplacer_char_X_par_char_Y(ByVal expression As String, _
                                            ByVal char_X As String, _
                                            ByVal char_Y As String) As String
    Dim nb_char_a_remplacer As Integer
    Dim nb_char_suppr As Integer
    Dim i As Integer
    
    nb_char_a_remplacer = 0
    nb_char_remplace = 0

    'on récupere le nombre de caractère X présent dans la chaine de caractère
    For i = 1 To Len(expression) Step 1
        If Mid(expression, i, 1) = char_X Then
            nb_char_a_remplacer = nb_char_a_remplacer + 1
        End If
    Next i
    
    i = 1
    'on va faire une boucle qui va supprimer les caractères Y
    Do While nb_char_remplace <> nb_char_a_remplacer
        If Mid(expression, i, 1) = char_X Then
            If i = 1 Then
                expression = char_Y + Mid(expression, 2)
            ElseIf i = Len(expression) Then
                expression = Mid(expression, 1, Len(expression) - 1) + char_Y
            Else
                expression = Mid(expression, 1, i - 1) + char_Y + Mid(expression, i + 1)
            End If
            nb_char_remplace = nb_char_remplace + 1
        End If
        i = i + 1
    Loop
    
    remplacer_char_X_par_char_Y = expression
End Function

'Fonction qui renvoie une cellule en fonction de son numéro de ligne et son numéro de colonne

Public Function recupere_nom_cellule(ByVal ligne_cellule As Integer, _
                                    ByVal colonne_cellule As Integer) As String
    recupere_nom_cellule = LettreColonne(colonne_cellule) + CStr(ligne_cellule)
End Function

'Fonction qui recherche une chaine de caractère dans une liste de chaine de caractère séparé par des ;

Public Function est_dans_liste_de_cdc(ByVal chaine_a_tester As String, _
                                        ByVal liste_de_chaines As String) As Boolean
    Dim i As Integer
    Dim taille_chaine As Integer
    Dim taille_chaine_liste As Integer
    Dim caractere1 As String
    Dim caractere2 As String
    
    est_dans_liste_de_cdc = False
    taille_chaine = Len(chaine_a_tester)
    taille_chaine_liste = Len(liste_de_chaines)
    
    For i = 1 To taille_chaine_liste - taille_chaine - 1 Step 1
        If Mid(liste_de_chaines, i + 1, taille_chaine) = chaine_a_tester Then
            caractere1 = Mid(liste_de_chaines, i, 1)
            caractere2 = Mid(liste_de_chaines, i + taille_chaine + 1, 1)
            If caractere1 = "(" And caractere2 = ";" Or _
                caractere1 = ";" And caractere2 = ";" Or _
                caractere1 = ";" And caractere2 = ")" Then
                est_dans_liste_de_cdc = True
                Exit For
            End If
        End If
    Next i
End Function

'Fonction qui renvoie le nombre de chiffre dans une chaine de caractères

Public Function nb_chiffres(ByVal modalite As String) As Integer
    Dim i As Integer
    Dim lettre As String
    Dim compteur As Integer
    
    compteur = 0
    
    For i = 1 To Len(modalite) Step 1
        lettre = Mid(modalite, i, 1)
        If Asc(lettre) <= 57 And Asc(lettre) >= 48 Then
            compteur = compteur + 1
        End If
    Next i
    
    nb_chiffres = compteur
    
End Function

'Fonction qui renvoie Vrai si une chaine de caractére contient au moins une fois le caractère passé en paramètre
Public Function contient_char_X(ByVal texte As String, _
                                ByVal char_X As String) As Boolean
    
    Dim i As Integer
    
    contient_char_X = False
    
    If Len(texte) < Len(char_X) _
        Or Len(char_X) <> 1 Then
            Exit Function
    Else
        For i = 1 To Len(texte) Step 1
            If Mid(texte, i, 1) = char_X Then
                contient_char_X = True
                Exit For
            End If
        Next i
    End If
End Function

'=====================
' module : Extraction
'=====================

'Fonction qui permettrai de vider le press-papier (source : Forum)

Public Sub ClearClipboard()
Dim oDataObject As DataObject

Set oDataObject = New DataObject
oDataObject.SetText ""
oDataObject.PutInClipboard

Set oDataObject = Nothing
End Sub
                                
' Procédure qui va supprimer toutes les valeurs de la plage de données

Public Sub nettoyer_extraction()
    Dim ws As Worksheet
    Dim der_col, pdd As String
    Dim der_ligne As Integer
    
    Set ws = Worksheets("Extraction")

    der_col = LettreColonne(ws.Range("A1").End(xlToRight).Column)

    If ws.Range("A2").Value <> "" Then
        der_ligne = ws.Range("A1").End(xlDown).Row
        pdd = retire_les_espaces("A1:" + der_col + str(der_ligne))
    Else
        pdd = retire_les_espaces("A1:" + der_col + "1")
    End If
    ws.Range(pdd).Clear
    
    Set ws = Nothing
End Sub

'Procédure noyau qui va parcourir chaque ligne de la table Extraction et alimenter la table Valeur_calulées en
' passant par la feuille "Test_des_conditions".

Public Sub remplir_test_des_conditions(ByVal nom_parcours_extraction As String)
    Dim num_ligne_valeurs_calculees As Integer
    Dim num_ligne_max_extraction As Integer
    Dim num_colonne_max_extraction As Integer
    Dim num_ligne_max_test_des_conditons As Integer
    Dim nom_variable_extraction As String
    Dim nom_variable_filtre As String

    ligne_max_extraction = num_der_lignes("Extraction")
    num_colonne_max_extraction = num_max_colonne_droite("Extraction", "A1")
    num_ligne_max_test_des_conditons = num_der_lignes("Test_des_conditions")

    'On parcourt toutes les lignes de la feuille Extraction
    For i = 2 To ligne_max_extraction Step 1
        'On parcourt toutes les colonnes de la feuille Extraction
        For j = 1 To num_colonne_max_extraction Step 1
            'On récupère le nom de la variable qui lui ai associé
            nom_variable_extraction = retrouve_nom_variable("Extraction", j)
        Next j
    Next i

    'On recherche la ligne correspondant au nom du parcours figurant en paramètre
    num_ligne_valeurs_calculees = renvoie_num_ligne_modalite("Valeurs_calculées", 1, nom_parcours_extraction)
End Sub

'================
' module : Fiche
'================

'Procédure a n'exécuté qu'une seule fois qui renomme des formes

Public Sub Renommer_formes_situations()
    Call remplacer_nom_forme("Rectangle 10", "En emploi")
    Call remplacer_nom_forme("Rectangle 11", "En recherche emploi")
    Call remplacer_nom_forme("Rectangle 13", "En études")
    Call remplacer_nom_forme("Rectangle 14", "Autre situation")
End Sub

'Procédure qui nous permet de définir une position initiale des différentes formes

Public Sub formes_en_position_initiale()
    'On règle une largeur quasi nul
    Call modifier_dimension_forme2("Fiche", "En emploi", 0.01, 12.8)
    Call modifier_dimension_forme2("Fiche", "En recherche emploi", 0.01, 12.8)
    Call modifier_dimension_forme2("Fiche", "En études", 0.01, 12.8)
    Call modifier_dimension_forme2("Fiche", "Autre situation", 0.01, 12.8)
    'On positionne en un seul et même endroit
    Call modifier_positionnement_forme2("Fiche", "En emploi", 169.5, 103)
    Call modifier_positionnement_forme2("Fiche", "En recherche emploi", 169.5, 103)
    Call modifier_positionnement_forme2("Fiche", "En études", 169.5, 103)
    Call modifier_positionnement_forme2("Fiche", "Autre situation", 169.5, 103)
    'On les rend invisible
    Call rendre_forme_invisible("Fiche", "En emploi")
    Call rendre_forme_invisible("Fiche", "En recherche emploi")
    Call rendre_forme_invisible("Fiche", "En études")
    Call rendre_forme_invisible("Fiche", "Autre situation")
End Sub

'Fonction qui affiche un pourcentage si le contenu de la valeur est <= 1 un effectif sinon.

Public Function Si_qui_fonctionne_correctement2(ByVal plage As Range) As Variant
    
    Dim valeur_a_test As Variant
    
    Application.Volatile
    
    valeur_a_test = plage.Value
    
    If valeur_a_test <= 1 Then
        Si_qui_fonctionne_correctement2 = valeur_a_test * 100 & "%"
    Else
        plage.NumberFormat = "General"
        Si_qui_fonctionne_correctement2 = valeur_a_test
    End If
    
End Function

'Procédure qui définit la position initiale de la légende des différentes situations

Public Sub legendes_en_position_initiale()
    Dim c As Range
    
    Set c = Worksheets("Fiche").Range("E15:AF15")
    
    c.ClearContents
    c.Interior.Pattern = xlNone
    c.Borders(xlEdgeBottom).LineStyle = xlNone
    c.Borders(xlEdgeTop).LineStyle = xlNone
    c.Borders(xlInsideVertical).LineStyle = xlNone
    
    Set c = Nothing
End Sub

'Procédure qui sauvegarde une plage de donnée en PDF

Public Sub Save_as_format_pdf(ByVal feuille As String, _
                              ByVal plage As String, _
                              ByVal chemin As Variant, _
                              ByVal parcours As Variant)
    
    'Enlever le msgbox d'alerte
    Application.DisplayAlerts = False
    If contient_char_X(parcours, ":") Then
        parcours = remplacer_char_X_par_char_Y(parcours, ":", "-")
    End If
    If contient_char_X(parcours, "/") Then
        parcours = remplacer_char_X_par_char_Y(parcours, "/", "-")
    End If
    If contient_char_X(parcours, "\") Then
        parcours = remplacer_char_X_par_char_Y(parcours, "\", "-")
    End If
    Worksheets(feuille).Range(plage).ExportAsFixedFormat _
                                    Type:=x1TypePDF, _
                                    Filename:=chemin & "\" & parcours, _
                                    Quality:=x1QualityStandard, _
                                    IncludeDocProperties:=True, _
                                    IgnorePrintAreas:=False, _
                                    OpenAfterPublish:=False
    
    'Remettre le msgbox d'alerte
    Application.DisplayAlerts = True
End Sub

Public Sub Renommer_images_saisfactions()
    Call remplacer_nom_forme("Image 52", "Satis_emploi")
    Call remplacer_nom_forme("Image 55", "Insatis_emploi")
    Call remplacer_nom_forme("Image 58", "Satis_LP")
    Call remplacer_nom_forme("Image 59", "Insatis_LP")
End Sub

Public Sub renommer_les_graphiques_Fiche()
    Dim cl As Workbook
    Dim f As Worksheet
    Dim graphe As ChartObject
    
    Set cl = Workbooks("Production_de_fiche_automatisee_V41_rework2.xlsm")
    Set f = cl.Worksheets("Fiche")
    Set graphe = f.ChartObjects(1)
    
    For Each graphe In f.ChartObjects
        graphe.Activate
        Application.Wait Time + TimeSerial(0, 0, 2)
        If MsgBox("Souhaitez-vous renommez le graphique " & graphe.Name & " ?", vbYesNo) = vbYes Then
            graphe.Name = InputBox("Indiquez le nouveau nom du graphique")
        End If
    Next graphe
    
    Set cl = Nothing
    Set f = Nothing
    Set graphe = Nothing
End Sub

Public Sub smiley_en_position_initiale()
    Call modifier_positionnement_forme2("Fiche", "Satis_emploi", 610.85, 195.01)
    Call modifier_positionnement_forme2("Fiche", "Insatis_emploi", 610.85, 195.01)
    Call modifier_positionnement_forme2("Fiche", "Satis_LP", 661.915, 195.86)
    Call modifier_positionnement_forme2("Fiche", "Insatis_LP", 661.915, 195.86)
End Sub

'Procédure qui vérifie si l'utilisateur a réalisé les bonnes manipulations

Public Function Parametrage_avant_execution_valide() As String

    Dim f_R As Worksheet
    Dim f_Ds As Worksheet
    Dim f_Vc As Worksheet
    Dim f_F As Worksheet
    
    Dim y_a_une_erreur As Boolean
    Dim i As Integer
    Dim texte As String
    
    Set f_R = Worksheets("Référencement")
    Set f_Ds = Worksheets("Données_sources")
    Set f_Vc = Worksheets("Valeurs_calculées")
    Set f_F = Worksheets("Fiche")
    
    y_a_une_erreur = False
    i = 0
    texte = "Veuillez corriger les différents points ci-dessous et relancer la macro:" & Chr(13) & Chr(13)
    
    'Vérifs sur la feuille "Référencement"
        If f_R.Range("A4").Value = "" Then
            y_a_une_erreur = True
            i = i + 1
            texte = texte + CStr(i) & ") Entrer les variables référentes en 'Référencement' cellules 'A3'." & Chr(13)
        End If
        
        If f_R.Range("C2").Value = "" Then
            y_a_une_erreur = True
            i = i + 1
            texte = texte + CStr(i) & ") Entrer la variable dont on va se servir pour agréger les résultats en 'Référencement' cellules 'C2'." & Chr(13)
        End If
        
        If f_R.Range("P2").Value = "" Then
            y_a_une_erreur = True
            i = i + 1
            texte = texte + CStr(i) & ") Entrer les variables qualitative en 'Référencement' à partir de la colonne 'P' en ligne 2." & Chr(13)
        End If
        
        If f_R.Range("P3").Value = "" Then
            y_a_une_erreur = True
            i = i + 1
            texte = texte + CStr(i) + ") Entrer les modalités de variables qualitatives en 'Référencement' à partir de la ligne 3 et plus." & Chr(13)
        End If
        
    'Vérifs sur la feuille "Donnée_sources"
    
        If f_Ds.Range("A1").Value = "" Then
            y_a_une_erreur = True
            i = i + 1
            texte = texte + CStr(i) + ") Charger la base de données en 'Données_source'." & Chr(13)
        End If
        
    'Vérifs sur la feuille "Valeur_calculées"
        If f_Vc.Range("B1").Value = "" Then
            y_a_une_erreur = True
            i = i + 1
            texte = texte + CStr(i) + ") Entrer les codes valeurs en 'Valeurs_calculées' sur la première ligne depuis 'Test_des_conditions' ." & Chr(13)
        End If
        
    'Vérifs sur la feuille "Fiche"
        If f_F.Range("AX2").Value = "" Then
            y_a_une_erreur = True
            i = i + 1
            texte = texte + CStr(i) + ") Entrer le chemin du dossier (existant) de reception des fiches en 'Fiche' en 'AX2'." & Chr(13)
        End If
        
    If y_a_une_erreur = True Then
        Parametrage_avant_execution_valide = texte
    End If
        
    Set f_R = Nothing
    Set f_Ds = Nothing
    Set f_Vc = Nothing
    Set f_F = Nothing
        
End Function

Public Function Parametrage_avant_execution_valide0() As Boolean

    Dim f_R As Worksheet
    Dim f_Ds As Worksheet
    Dim f_Vc As Worksheet
    Dim f_F As Worksheet
    
    Set f_R = Worksheets("Référencement")
    Set f_Ds = Worksheets("Données_sources")
    Set f_Vc = Worksheets("Valeurs_calculées")
    Set f_F = Worksheets("Fiche")
    
    If f_R.Range("A4").Value = "" _
        Or f_R.Range("C2").Value = "" _
        Or f_R.Range("P2").Value = "" _
        Or f_R.Range("P3").Value = "" _
        Or f_Ds.Range("A1").Value = "" _
        Or f_Vc.Range("B1").Value = "" _
        Or f_F.Range("AX2").Value = "" Then
            Parametrage_avant_execution_valide0 = False
    Else
        Parametrage_avant_execution_valide0 = True
    End If
        
    Set f_R = Nothing
    Set f_Ds = Nothing
    Set f_Vc = Nothing
    Set f_F = Nothing
        
End Function

Public Function Parametrage_avant_execution_valide2() As String

    Dim f_R As Worksheet
    Dim f_Ds As Worksheet
    Dim f_Vc As Worksheet
    Dim f_F As Worksheet
    
    Dim y_a_une_alerte As Boolean
    Dim i As Integer
    Dim texte As String
    
    Set f_R = Worksheets("Référencement")
    Set f_Ds = Worksheets("Données_sources")
    Set f_Vc = Worksheets("Valeurs_calculées")
    Set f_F = Worksheets("Fiche")
    
    y_a_une_alerte = False
    
    'On vérifie que les variables référencées sont les mêmes que celles en base
    If presence_incoherence_Base_VariablesRef2 Then
        y_a_une_alerte = True
    End If  
        
    Set f_R = Nothing
    Set f_Ds = Nothing
    Set f_Vc = Nothing
    Set f_F = Nothing
        
End Function

'Procédure qui intialise_le_traitement avant execution de la macro

Public Sub initialise_les_plages_de_donnees()
    Dim ligne_fin_tab_R As Integer
    Dim ligne_fin_tab_Vc As Integer
    Dim colonne_fin_tab_Vc As Integer
    Dim plage As String
    
    ligne_fin_tab_R = Worksheets("Référencement").Range("C2").End(xlDown).Row
    ligne_fin_tab_Vc = Worksheets("Valeurs_calculées").Range("A1").End(xlDown).Row
    colonne_fin_tab_Vc = Worksheets("Valeurs_calculées").Range("A1").End(xlToRight).Column
    
    plage = "C3:C" & CStr(ligne_fin_tab_R)
    Worksheets("Référencement").Range(plage).ClearContents
    
    plage = "A2:" & LettreColonne(colonne_fin_tab_Vc) & CStr(ligne_fin_tab_Vc)
    Worksheets("Valeurs_calculées").Range(plage).ClearContents
    
    For i = 2 To ligne_fin_tab_Vc Step 1
        Worksheets("Valeurs_calculées").Rows(CStr(i) & ":" & CStr(i)).ClearFormats
    Next i
    
    Worksheets("Valeurs_calculées").Cells(ligne_fin_tab_Vc + 2, 2).ClearContents
    Worksheets("Valeurs_calculées").Cells(ligne_fin_tab_Vc + 2, 3).ClearContents
    Worksheets("Valeurs_calculées").Cells(ligne_fin_tab_Vc + 3, 2).ClearContents
    Worksheets("Valeurs_calculées").Cells(ligne_fin_tab_Vc + 3, 3).ClearContents
    
End Sub

'=================
' module : Listes
'=================

'Fonction qui renvoie le nombre de cellules non vides

Public Function compte_nb_cellule_non_vide(ByVal feuille As String, _
                                            ByVal cellule As String) As Integer
    Dim f As Worksheet
    Dim c As Range
    Dim i, compteur As Integer
    
    Set f = Worksheets(feuille)
    Set c = f.Range(cellule)
    
    i = 0
    
    Do While c.Offset(i, 0).Value <> ""
        i = i + 1
    Loop
    
    Set f = Nothing
    Set c = Nothing
    
    compte_nb_cellule_non_vide = i
End Function

'Fonction qui renvoie le nombre de cellule nom vides

Public Function compte_nb_cellule_non_vide2(ByVal feuille As String, _
                                            ByVal ligne_cellule As Integer, _
                                            ByVal colonne_cellule As Integer) As Integer
    Dim f As Worksheet
    Dim c As Range
    Dim i, compteur As Integer
    
    Set f = Worksheets(feuille)
    Set c = f.Cells(ligne_cellule, colonne_cellule)
    
    i = 0
    
    Do While c.Offset(i, 0).Value <> ""
        i = i + 1
    Loop
    
    Set f = Nothing
    Set c = Nothing
    
    compte_nb_cellule_non_vide2 = i
End Function
                                     

'Fonction qui renvoie true si le mot appartient à une liste d'autre mot

Public Function est_dans_la_liste(ByVal mot As String, _
                                    ByVal feuille As String, _
                                    ByVal cellule_start As String, _
                                    ByVal nb_occurence As Integer) As Boolean
    Dim f As Worksheet
    Dim c As Range
    Dim i As Integer
    
    Set f = Worksheets(feuille)
    Set c = f.Range(cellule_start)
    
    est_dans_la_liste = False
    
    For i = 1 To nb_occurence Step 1
        If mot = c.Offset(i - 1, 0).Value Then
            est_dans_la_liste = True
            Exit For
        End If
    Next i
    
    Set f = Nothing
    Set c = Nothing
End Function

'Fonction qui renvoie true si le mot appartient à une liste d'autre mot ayant au moins 3 mots

Public Function est_dans_la_liste_V2(ByVal mot As String, _
                                    ByVal feuille As String, _
                                    ByVal cellule_start As String) As Boolean
    Dim f As Worksheet
    Dim c As Range
    Dim i As Integer
    
    Set f = Worksheets(feuille)
    Set c = f.Range(cellule_start)
    
    est_dans_la_liste_V2 = False
    
    For i = c.Row To c.End(xlDown).Row Step 1
        If mot = c.Offset(i - c.Row, 0).Value Then
            est_dans_la_liste_V2 = True
            Exit For
        End If
    Next i
    
    Set f = Nothing
    Set c = Nothing
End Function

'Procédure qui va écrire une liste (verticale) de concaténation de deux textes avec une incrémentation

Public Sub Redige_liste_concat_increm(ByVal feuille As String, _
                                    ByVal cellule_debut As String, _
                                    ByVal texte1 As String, _
                                    ByVal incrementation_debut As Integer, _
                                    ByVal incrementation_fin As Integer, _
                                    ByVal texte2 As String)
    Dim ws As Worksheet
    Dim c As Range
    Dim i As Integer
    Dim nb_occ As Integer
    Dim resultat As String
    
    Set ws = Worksheets(feuille)
    Set c = ws.Range(cellule_debut)
    
    If increment_debut < incrementation_fin Then
        nb_occ = incrementation_fin - increment_debut + 1
        For i = 1 To nb_occ Step 1
            c.Offset(i - 1, 0).NumberFormat = "@"
            resultat = Chaine_de_caractères.remplacer_char_X_par_char_Y(texte1 + CStr(incrementation_debut + i - 1) + texte2, "'", 34)
            c.Offset(i - 1, 0).Formula = resultat
            c.Offset(i - 1, 0).NumberFormat = "General"
        Next i
    End If

    Set ws = Nothing
    Set c = Nothing
End Sub

'Fonction qui renvoie le nom de la dernière cellule à partir d'une feuille et d'une cellule de départ

Public Function nom_derniere_cellule_de_liste(ByVal feuille As String, _
                                                ByVal cellule As String) As String
    num_ligne_min = Worksheets(feuille).Range(cellule).Row
    lettre_col = Chaine_de_caractères.part_alphabetique_cellule(cellule)
    nb_choix = Listes.compte_nb_cellule_non_vide(feuille, cellule)
    nom_derniere_cellule_de_liste = lettre_col + CStr(num_ligne_min + nb_choix - 1)
End Function

'Procédure qui va paramétrer une liste sur une cellule Excel

Public Sub liste_parametree_sur_cellule(ByVal feuille_cible As String, _
                                        ByVal feuille_referente As String, _
                                        ByVal cellule_cible As String, _
                                        ByVal haut_cellule_referente As String, _
                                        Optional ByVal indice_decalage As Integer)
    Dim ws1 As Worksheet
    Dim c1 As Range
    Dim plage As String
    
    Set ws1 = Worksheets(feuille_cible)
    Set c1 = ws1.Range(cellule_cible)
    
    plage = "=" + feuille_referente + "!" + transforme_en_cellule_verou(haut_cellule_referente) + ":" + transforme_en_cellule_verou(nom_derniere_cellule_de_liste(feuille_referente, haut_cellule_referente))
    c1.Offset(indice_decalage, 0).Validation.Delete
    c1.Offset(indice_decalage, 0).Validation.Add xlValidateList, , , plage
    'c1.Offset(indice_decalage, 0).Validation.Add xlValidateWholeNumber
    Set ws1 = Nothing
    Set c1 = Nothing
End Sub


'Procédure qui fait passer d'une cellule liste à une cellule classique (tout)

Public Sub Supprime_liste_de_cellule(ByVal feuille As String, _
                                        ByVal cellule As String, _
                                        Optional ByVal indice_decalage As Integer)
    Dim ws1 As Worksheet
    Dim c1 As Range
    Dim plage As String
    
    Set ws1 = Worksheets(feuille)
    Set c1 = ws1.Range(cellule)
    
    c1.Offset(indice_decalage, 0).Validation.Delete
    
    Set ws1 = Nothing
    Set c1 = Nothing
End Sub

'Fonction qui renvoie Vrai si le calcule statistique est faisable, Faux sinon

Public Function calcul_stat_faisable(ByVal plage As Range) As Boolean
    Dim c As Range
    
    calcul_stat_faisable = False
    
    For Each c In plage
        If c.Value <> "" Then
            calcul_stat_faisable = True
            Exit For
        End If
    Next c
End Function


Public Function calcul_stat_faisable2(ByVal ws As Worksheet, _
                                      ByVal plage As String) As Boolean
    Dim c As Range
    Dim cellule As Range
    
    Set c = ws.Range(plage)
    
    calcul_stat_faisable2 = False
    
    For Each cellule In c
        If cellule.Value <> "" Then
            calcul_stat_faisable2 = True
            Exit For
        End If
    Next cellule
    
    Set c = Nothing
End Function

'======================
' Procédure principale
'======================

'Permet de rendre obligatoire la déclaration de toutes les variables avant compilation et exécution du code
Option Explicit

'Procédure principale qui va l'automatisation

Public Sub Lancer_automatisation_PDF()
    'Déclaration d'objet de type feuille de calcul
    Dim f_R As Worksheet
    Dim f_Ds As Worksheet
    Dim f_E As Worksheet
    Dim f_Vc As Worksheet
    Dim f_Tdc As Worksheet
    'Dim f_Pc As Worksheet
    Dim f_F As Worksheet

    'Déclaration de variable de type chaine de caractère
    Dim cellule_en_h_a_g_Ds As String
    Dim cellule_en_b_a_d_Ds As String
    Dim cellule_haut_colonne_tri_Ds As String
    Dim cellule_bas_colonne_tri_Ds As String
    Dim cellule_haut_parcours_Ds As String
    Dim intitule_var_parcours As String
    Dim intitule_modalite_parcours As String
    Dim nom_variable_E As String
    Dim nom_variable_Tdc As String
    Dim nom_code_valeur As String
    Dim plage As String
    Dim statistique As String
    Dim nom_code_valeur_tableau_droite_Pc As String
    Dim chemin As String
    
    'Déclaration de variable de type entier naturel
    Dim h, i, j, k, l, m As Integer
    Dim nb_total_parcours As Integer
    Dim nb_etudiants_E As Integer
    Dim nb_variables As Integer
    Dim num_ligne_max_Tdc As Integer
    Dim num_der_col_Vc As Integer
    Dim ligne_code_valeur_agrege As Integer
    Dim num_derniere_cellule_Pc As Integer
    Dim numero_derniere_ligne_tableau_droite_Pc As Integer
    Dim numero_derniere_ligne_tableau_gauche_Pc As Integer
    Dim compteur_eff_stat As Integer
    Dim total_condition_eff_stat As Integer
    Dim compteur_pct As Integer
    Dim total_condition_pct As Integer
    Dim num_colonne_code_valeur_Vc As Integer
    Dim num_ligne_der_moda_parcours As Integer
    
    'Déclaration de variable de type nombre réel
    Dim valeur_num_obs As Single
    Dim valeur_stat As Single
    Dim nombre_code_valeur_Vc As Single
    Dim valeur_pourcentage As Single
    
    'Déclaration de variable de type indéterminé
    Dim valeur_variable_E As Variant
    
    'Déclaration de variable de type booléen
    Dim code_val_gauche_trouve As Boolean
    Dim acceptation_petits_effectifs As Boolean
    
        '*************************************
        ' Initialisation des variables objets
        '*************************************

    Set f_R = Worksheets("Référencement")
    Set f_Ds = Worksheets("Données_sources")
    Set f_E = Worksheets("Extraction")
    Set f_Vc = Worksheets("Valeurs_calculées")
    Set f_Tdc = Worksheets("Test_des_conditions")
    'Set f_Pc = Worksheets("Phrases_conditionnées")
    Set f_F = Worksheets("Fiche")
    
    Application.ScreenUpdating = False
    
        '**************************************
        ' Initialisation des variables stables
        '**************************************
        
    'On part du principe que l'utilisateur souhaite publier les parcours ayant un trop faible nombre de diplômé en situation d'emploi
    acceptation_petits_effectifs = True
        
    'On compte le nombre de variables nécessaires à la production des indicateurs d'une fiche quelconque
    nb_variables = Listes.compte_nb_cellule_non_vide("Référencement", _
                                                    "A3")
                                                          
    'On récupère le numéro de la dernière colonne du tableau de la feuille "Valeurs_calculées"
    num_der_col_Vc = Tableau.num_max_colonne_droite("Valeurs_calculées", "A1")
    
        '*******************************
        ' Restriction sur les variables
        '*******************************
    
    'Procédure qui ne conserve uniquement les variables déclarées dans la feuille "Référencement"
    Call Preparation_donnees.restriction_sur_variable("Données_sources", _
                                                      "Référencement", _
                                                      "A3")
                                                                                                
        '*******************************
        ' Modification des non-reponses
        '*******************************
    
    'Procédure qui remplace les #NUL! par les #NULL!
    Call Preparation_donnees.repare_le_probleme_NUL("Données_sources", _
                                                    "A1")
                                
        '**********************************
        ' Recensement des noms de parcours
        '**********************************
                                
    'On affecte à intitule_var_parcours le nom de la variable contenant les différents parcours
    intitule_var_parcours = f_R.Range("C2").Value
    
    'On affecte à 4 variables des noms de cellules qui nous permettront de réaliser un tri
    cellule_en_h_a_g_Ds = "A1"
    cellule_en_b_a_d_Ds = Tableau.renvoie_nom_cellule_en_b_a_d("Données_sources", _
                                                               "A1")
    cellule_haut_colonne_tri_Ds = Tableau.lettre_colonne_var_recherchee("Données_sources", _
                                                                        intitule_var_parcours) + CStr(1)
    cellule_bas_colonne_tri_Ds = Tableau.lettre_colonne_var_recherchee("Données_sources", _
                                                                       intitule_var_parcours) + _
                                                                            CStr(Tableau.num_der_lignes("Données_sources"))
                                                                            
    'Procédure qui trie le tableau de données dans la feuille "Données_sources" selon une variable
    Call Preparation_donnees.trie_selon_une_variable("Données_sources", _
                                                    cellule_en_h_a_g_Ds, _
                                                    cellule_en_b_a_d_Ds, _
                                                    cellule_haut_colonne_tri_Ds, _
                                                    cellule_bas_colonne_tri_Ds, _
                                                    True, _
                                                    True)
                                                    
    'On stocke dans une variable le nom de la cellule où commence la première modalité de la variable parcours
    cellule_haut_parcours_Ds = Tableau.lettre_colonne_var_recherchee("Données_sources", _
                                                                     intitule_var_parcours) + CStr(2)
                                                                     
    'On rédige dans la feuille "Référencement" l'ensemble des parcours répertoriés dans la feuille "Données_sources"
    Call Preparation_donnees.lister_parcours("Référencement", _
                                            cellule_haut_parcours_Ds, _
                                            "C2")
                                            
        '********************************************
        ' Paramétrage de la feuille Valeur Calculées
        '********************************************
        
    'On stocke dans une variable le numéro de ligne correspondant à la dernière modalité de parcours
    num_ligne_der_moda_parcours = f_R.Range("C3").End(xlDown).Row
    
    'On copie la liste des noms de parcours
    f_R.Range("C3:C" & CStr(num_ligne_der_moda_parcours)).Copy
    
    'On colle cette liste dans la feuille Valeurs Calculées
    f_Vc.Range("A2").PasteSpecial
    
    'On supprime des données contenues dans le presse-papier
    Call Extraction.ClearClipboard
        
    'On compte le nombre de parcours
    nb_total_parcours = Listes.compte_nb_cellule_non_vide("Référencement", _
                                                          "C3")
                                                    
    'Procédure qui va rédiger un tableau temporaire pour le calcul des différentes statistiques
    Call Test_des_conditions.redige_tableau_annexe_vierge_V2
    
        '============================
        ' Boucle sur chaque parcours
        '============================
    
    'Pour chaque parcours
    For h = 1 To nb_total_parcours Step 1
    
        'On récupère l'intitulé du parcours
        intitule_modalite_parcours = f_R.Range("C2").Offset(h, 0)
        
        'On copie-colle les étudiants appartenant au parcours depuis "Données_sources" vers "Extraction"
        Call Preparation_donnees.extrait_les_donnees("Données_sources", _
                                                    "Extraction", _
                                                    intitule_var_parcours, _
                                                    intitule_modalite_parcours)
                                                    
        'On compte le nombre d'étudiants présent dans le parcours
        nb_etudiants_E = Tableau.num_der_lignes("Extraction")
        
            '============================
            ' Boucle sur chaque étudiant
            '============================
        
        'Pour chaque étudiant
        For i = 2 To nb_etudiants_E Step 1
        
                '============================
                ' Boucle sur chaque variable
                '============================
            
            'Pour chaque variable
            For j = 1 To nb_variables Step 1
            
                'On récupère le nom de la variable dans le tableau de la feuille "Extraction"
                nom_variable_E = Tableau.retrouve_nom_variable("Extraction", j)
                
                'On récupére la valeur de la variable dans le tableau de la feuille "Extraction"
                valeur_variable_E = f_E.Cells(i, j).Value
                
                'On récupère le numéro de la dernière ligne du tableau de la feuille "Test_des_conditions"
                num_ligne_max_Tdc = Tableau.num_der_lignes("Test_des_conditions")
                
                    '==============================
                    ' Boucle sur chaque conditions
                    '==============================
                
                'Pour chaque condition
                For k = 2 To num_ligne_max_Tdc Step 1

                    'On récupère le nom de la variable qui fait office de filtre
                    nom_variable_Tdc = f_Tdc.Cells(k, 2).Value
                    
                    'On teste si le nom de variable est le même que celui dans la feuille "Extraction"
                    If nom_variable_Tdc = nom_variable_E Then
                    
                        'On renseigne la valeur de la variable dans le champs "Valeur_observée" de la feuille "Test_des_conditions"
                        f_Tdc.Cells(k, 3).Value = valeur_variable_E
                        
                    End If
                    
                Next k
        
            Next j
            
                '===============================
                ' Boucle sur chaque code valeur
                '===============================
            
            'Pour chaque code_valeur
            For l = 2 To num_der_col_Vc Step 1
            
                'On récupère le nom du code_valeur
                nom_code_valeur = f_Vc.Cells(1, l).Value
                
                'On vérifie si l'étudiant est éligible au comptage
                If Test_des_conditions.toutes_conditions_validees(nom_code_valeur) = True Then
                
                    'Si l'étudiant est éligible on regarde si le code valeur est le résultat d'un comptage ou d'un calcul agrégé
                    If Test_des_conditions.est_calcul_agrege(nom_code_valeur) = True Then
                    
                        'Calcul agrégé : On récupère la valeur à insérer
                        valeur_num_obs = Test_des_conditions.valeur_obs_calcul_agrege(nom_code_valeur)
                        
                        '                On stocke les valeurs dans un tableau temporaire
                        Call Valeurs_calculées.alimente_tableau_annexe_Vc(nom_code_valeur, valeur_num_obs)
                        
                    Else
                    
                        'Comptage : On incrémente la bonne cellule du tableau de la feuille "Valeurs_calculées"
                        Call Valeurs_calculées.incremente_tableau_Vc(intitule_modalite_parcours, nom_code_valeur)
                        
                    End If
                    
                End If
            
            Next l
            
        Next i
        
        'On récupère le numéro de ligne correspondant à l'endroit où l'on va retrouver les différents code_valeur soumis au calcul d'agrégation
        ligne_code_valeur_agrege = Tableau.num_der_lignes("Valeurs_calculées") + 3
        
            '=================================
            ' Boucle sur chaque calcul agrégé
            '=================================
        
        'Pour chaque code_valeur_agrégé
        For m = 2 To 100 Step 1
        
            'If h = 12 Then
            
                'MsgBox "Là"
            
            'End If
        
            'On test s'il y a au moins un code valeur agrégé
            If f_Vc.Cells(ligne_code_valeur_agrege, m).Value <> "" Then
            
                'On test s'il y a au moins une valeur numérique associé au code valeur, même si égale à -99
                If f_Vc.Cells(ligne_code_valeur_agrege + 1, m).Value <> "" Then
                
                    'On récupère le nom du code valeur
                    nom_code_valeur = f_Vc.Cells(ligne_code_valeur_agrege, m).Value
                    
                    'On identifie et construit la plage de donnée qui va nous permettre d'effectuer le calcul de la statistique
                    plage = Valeurs_calculées.renvoie_plage_de_donnees(nom_code_valeur)
                    
                    'On remplace les valeurs nulles par "" pour ne pas les prendre en compte lors du calcul
                    f_Vc.Range(plage).Replace What:="-99", Replacement:="", LookAt:=xlPart, _
                        SearchOrder:=xlByRows, MatchCase:=False, SearchFormat:=False, _
                        ReplaceFormat:=False
                    
                    'On rècupère le type de statistique à effectuer
                    statistique = f_Vc.Cells(ligne_code_valeur_agrege - 1, m).Value
                    
                    'On test si il y a au moins une valeur numérique valide dans la plage de données
                    If calcul_stat_faisable2(f_Vc, plage) Then
                    
                        'On calcule la valeur de la statistique
                        valeur_stat = Valeurs_calculées.calcul_agrege(plage, statistique)
                        
                    'Sinon
                    Else
                    
                        valeur_stat = -1
                        
                    End If
                    
                    'On entre la valeur dans la bonne cellule du tableau de la feuille "Valeurs_Calculées"
                    Call Valeurs_calculées.incremente_tableau_Vc(intitule_modalite_parcours, nom_code_valeur, valeur_stat)
                    
                Else
                
                    'On récupère le nom du code valeur
                    nom_code_valeur = f_Vc.Cells(ligne_code_valeur_agrege, m).Value
                    
                    'On entre la valeur dans la bonne cellule du tableau de la feuille "Valeurs_Calculées"
                    Call Valeurs_calculées.incremente_tableau_Vc(intitule_modalite_parcours, nom_code_valeur, -1)
                    
                End If
                
            'Sinon
            Else
            
                'On quitte la boucle
                Exit For
                
            End If
        
        Next m
        'On supprime le contenu des cellules ayant permies de réaliser des calculs agrégés
        f_Vc.Range("B" & CStr(ligne_code_valeur_agrege + 1) & ":G680").ClearContents
        
        'On supprime le tableau présent sur la feuille "Extraction"
        Call Tableau.nettoie_integralement("Extraction", "A1")
        
    Next h
    
    'On supprime le contenu des cellules ayant permies de réaliser des calculs agrégés
    f_Vc.Range("B" & CStr(ligne_code_valeur_agrege - 1) & ":G" & CStr(ligne_code_valeur_agrege)).ClearContents
    
    'Procédure qui va remplacer les valeurs manquantes "" par 0 dans la base agrégée en "Test des conditions"
    Call Valeurs_calculées.replace_Vide_par_0("Valeurs_calculées")
    
    'On demande à l'utilisateur s'il souhaite obtenir les fiches dont le nombre
    If MsgBox("Souhaitez-vous publier les fiches dont le nombre de répondants est inférieur ou égale à 5 ?", vbYesNo) = vbNo Then

        'Procédure qui va marquer entièrement les lignes correspondants au parcours que l'on ne souhaite pas afficher
        Call reperage_fiches_non_publiees("cd_V24", 5)
        acceptation_petits_effectifs = False
        
    End If
    
    'On récupère le nom du chemin qui pointe vers le dossier où l'utilisateur désire enregistré ces fiches
    chemin = f_F.Range("AX2").Value
    
    'On récupère le numéro de la dernière colonne non vide en "Valeurs calculées"
    num_der_col_Vc = Tableau.num_max_colonne_droite("Valeurs_calculées", "A1")
    
    'On récupère le nombre de total de parcours
    nb_total_parcours = Listes.compte_nb_cellule_non_vide("Référencement", _
                                                          "C3")
    
        '============================
        ' Boucle sur chaque parcours
        '============================
    
    For h = 1 To nb_total_parcours Step 1    '1 To nb_total_parcours
    
        'On test si la fiche est publiable
        If est_parcours_avec_X_repondants_ou_moins(h) = False Or _
            (est_parcours_avec_X_repondants_ou_moins(h) = True And _
             acceptation_petits_effectifs = True) Then
             
                 f_F.Rows("62:72").Hidden = False
    
                 intitule_modalite_parcours = Mid(f_Vc.Cells(h + 1, 1).Value, 25)
                 
                 f_F.Range("C4").Value = intitule_modalite_parcours
                 
                     '=======================================
                     ' Boucle sur chaque code valeur calculé
                     '=======================================
                
                 For i = 1 To num_der_col_Vc + 1 Step 1
                 
                     If i <> num_der_col_Vc Then
                 
                         nom_code_valeur = f_Vc.Cells(1, i + 1).Value
                         
                         valeur_variable_E = f_Vc.Cells(h + 1, i + 1).Value
                     
                             '==========================================
                             ' Boucle sur chaque code valeur à afficher
                             '==========================================
                     
                         For j = 4 To 74 Step 1
                         
                             If f_F.Cells(j, 45).Value = nom_code_valeur Then
                                 
                                 f_F.Cells(j, 46).Value = valeur_variable_E
                                 
                                 Exit For
                                 
                             End If
                         
                         Next j
                     
                     End If
                
                 Next i
                 
                 'Procédure qui enregistre la fiche
                 Call Fiche.Save_as_format_pdf("Fiche", "B2:AG59", chemin, intitule_modalite_parcours)
                 
        End If
       
    Next h
    
    MsgBox "Les fiches ont été produites avec succès."
    
    Application.ScreenUpdating = True
       
    Set f_R = Nothing
    Set f_Ds = Nothing
    Set f_E = Nothing
    Set f_Vc = Nothing
    Set f_Tdc = Nothing
    Set f_F = Nothing
                
End Sub

'=================
' module : Objets
'=================

'Procédure qui va compter l'intégralité des "formes basiques" dans une feuille

Public Function nb_formes_basique(ByVal feuille As String) As Integer
    Dim f As Worksheet
    Dim compteur As Integer
    
    Set f = Worksheets(feuille)
    
    compteur = 0
    
    For Each Shape In f.Shapes
        If Shape.Type = 1 Then
            compteur = compteur + 1
        End If
    Next Shape
    
    Set f = Nothing
    
    nb_formes_basique = compteur
End Function

'Procédure qui va compter l'intégralité des "formes basiques" dans une feuille

Public Sub supprime_formes_basique(ByVal feuille As String)
    Dim f As Worksheet
    
    Set f = Worksheets(feuille)
    
    If nb_formes_basique(feuille) >= 1 Then
        For Each Shape In f.Shapes
            If Shape.Type = 1 Then
                Shape.Delete
            End If
        Next Shape
    End If
    
    Set f = Nothing
End Sub

'Procédure qui va rendre une forme invisible est inaccessible à l'utilisateur

Public Sub rendre_forme_invisible(ByVal feuille As String, _
                                  ByVal nom_forme As String)
    Dim f As Worksheet
    Dim s As Shape
    
    Set f = Worksheets(feuille)
    Set s = f.Shapes(nom_forme)
    
    s.Visible = msoFalse
    
    Set f = Nothing
    Set s = Nothing
End Sub

'Procédure qui va rendre une forme visible est accessible à l'utilisateur

Public Sub rendre_forme_visible(ByVal feuille As String, _
                                ByVal nom_forme As String)
    Dim f As Worksheet
    Dim s As Shape
    
    Set f = Worksheets(feuille)
    Set s = f.Shapes(nom_forme)
    
    s.Visible = msoTrue
    
    Set f = Nothing
    Set s = Nothing
End Sub

'Procédure qui va compter le nombre de formes visible dans une feuille

Public Function nb_formes_visibles(ByVal feuille As String) As Integer
    Dim f As Worksheet
    Dim compteur As Integer
    
    Set f = Worksheets(feuille)
    
    compteur = 0
    
    For Each Shape In f.Shapes
        If Shape.Visible = -1 Or Shape.Visible = 1 Then
            compteur = compteur + 1
        End If
    Next Shape
    
    Set f = Nothing
    
    nb_formes_visibles = compteur
End Function

'Procédure qui va compter le nombre de formes visible dans une feuille

Public Function nb_formes_invisibles(ByVal feuille As String) As Integer
    Dim f As Worksheet
    Dim compteur As Integer
    
    Set f = Worksheets(feuille)
    
    compteur = 0
    
    For Each Shape In f.Shapes
        If Shape.Visible = 0 Then
            compteur = compteur + 1
        End If
    Next Shape
    
    Set f = Nothing
    
    nb_formes_invisibles = compteur
End Function

'Procédure qui va déplacer l'objet sur la feuille Excel

Public Sub modifier_positionnement_forme(ByVal feuille As String, _
                                        ByVal nom_forme As String, _
                                        Optional ByVal decalage_h As Single, _
                                        Optional ByVal decalage_v As Single)
    Dim f As Worksheet
    Dim s As Shape
    
    Set f = Worksheets(feuille)
    Set s = f.Shapes(nom_forme)
    
    If decalage_h <> 0 Then
        s.IncrementLeft (decalage_h)    'Si decalage_h > 0 --> vers la droite
    End If                              'Si decalage_h < 0 --> vers la gauche
                                 
    If decalage_v <> 0 Then
        s.IncrementTop (decalage_v)     'Si decalage_v > 0 --> vers le bas
    End If                              'Si decalage_v < 0 --> vers le haut
                                 
    Set f = Nothing
    Set s = Nothing
End Sub

'Procédure qui va déplacer l'objet sur la feuille Excel

Public Sub modifier_positionnement_forme2(ByVal feuille As String, _
                                        ByVal nom_forme As String, _
                                        Optional ByVal hauteur As Single, _
                                        Optional ByVal largeur As Single)
    Dim f As Worksheet
    Dim s As Shape
    
    Set f = Worksheets(feuille)
    Set s = f.Shapes(nom_forme)
    
    If hauteur <> 0 Then
        s.Top = hauteur
    End If
        
    If largeur <> 0 Then
        s.Left = largeur
    End If

    Set f = Nothing
    Set s = Nothing
End Sub

'Procédure qui va modifier la dimension de l'objet par incrémentation

Public Sub modifier_dimension_forme(ByVal feuille As String, _
                                    ByVal nom_forme As String, _
                                    ByVal increment_largeur As Single, _
                                    ByVal increment_hauteur As Single)
    Dim f As Worksheet
    Dim s As Shape
    
    Set f = Worksheets(feuille)
    Set s = f.Shapes(nom_forme)
    
    s.Width = s.Width + (increment_largeur) 'La partie gauche de la forme reste figée
    s.Height = s.Height + (increment_hauteur) 'La partie haute de la forme reste figée
    
    Set f = Nothing
    Set s = Nothing
End Sub

'Procédure qui donne exactement les dimensions de la forme

Public Sub modifier_dimension_forme2(ByVal feuille As String, _
                                    ByVal nom_forme As String, _
                                    Optional ByVal largeur As Single, _
                                    Optional ByVal hauteur As Single)
    Dim f As Worksheet
    Dim s As Shape
    
    Set f = Worksheets(feuille)
    Set s = f.Shapes(nom_forme)
    
    If largeur <> 0 Then
        s.Width = largeur 'La partie gauche de la forme reste figée
    End If
    
    If hauteur <> 0 Then
        s.Height = hauteur 'La partie haute de la forme reste figée
    End If
    
    Set f = Nothing
    Set s = Nothing
End Sub

'Procédure qui renvoie la hauteur depuis le haut vers la partie haute de la forme

Public Function renvoyer_hauteur_depuis_le_haut_forme(ByVal feuille As String, _
                                                      ByVal nom_forme As String) As Single
    Dim f As Worksheet
    Dim s As Shape
    
    Set f = Worksheets(feuille)
    Set s = f.Shapes(nom_forme)
    
    renvoyer_hauteur_depuis_le_haut_forme = s.Top
    
    Set f = Nothing
    Set s = Nothing
End Function

'Procédure qui renvoie la hauteur depuis le haut vers la partie haute de la forme

Public Function renvoyer_largeur_depuis_la_gauche_forme(ByVal feuille As String, _
                                                        ByVal nom_forme As String) As Single
    Dim f As Worksheet
    Dim s As Shape
    
    Set f = Worksheets(feuille)
    Set s = f.Shapes(nom_forme)
    
    renvoyer_largeur_depuis_la_gauche_forme = s.Left
    
    Set f = Nothing
    Set s = Nothing
End Function

'Procédure qui remplace le nom d'une forme

Public Sub remplacer_nom_forme(ByVal ancien_nom As String, _
                               ByVal nouveau_nom As String)
    Worksheets("Fiche").Shapes(ancien_nom).Name = nouveau_nom
End Sub

'Fonction qui renvoie la hauteur d'une forme

Public Function renvoyer_hauteur_forme(ByVal feuille As String, _
                                       ByVal nom_forme As String) As Single
    Dim f As Worksheet
    Dim s As Shape
    
    Set f = Worksheets(feuille)
    Set s = f.Shapes(nom_forme)
    
    renvoyer_hauteur_forme = s.Height
    
    Set f = Nothing
    Set s = Nothing
End Function

'Fonction qui renvoie la largeur d'une forme

Public Function renvoyer_largeur_forme(ByVal feuille As String, _
                                       ByVal nom_forme As String) As Single
    Dim f As Worksheet
    Dim s As Shape
    
    Set f = Worksheets(feuille)
    Set s = f.Shapes(nom_forme)
    
    renvoyer_largeur_forme = s.Width
    
    Set f = Nothing
    Set s = Nothing
End Function

'Procédure qui insère du texte dans une forme

Public Sub inserer_texte_dans_forme(ByVal feuille As String, _
                                    ByVal forme As String, _
                                    ByVal texte_a_inserer As String)
    Dim s As Shape
    
    Set s = Worksheets(feuille).Shapes(forme)
    
    s.TextFrame2.TextRange.Characters.Text = texte_a_inserer
    
    Set s = Nothing
End Sub

'Procédure qui coloris de remplissage d'une cellule

Public Sub applique_couleur_remplissage(ByVal feuille As String, _
                                        ByVal ligne_cellule As Integer, _
                                        ByVal colonne_cellule As Integer, _
                                        ByVal couleur As String)
    Dim c As Range
    Set c = Worksheets(feuille).Cells(ligne_cellule, colonne_cellule)
    Select Case couleur
        Case "violet_pourpre"
            c.Interior.Color = RGB(114, 0, 98)
        Case "bleu_marine"
            c.Interior.Color = RGB(29, 66, 138)
        Case "vert_bouteille"
            c.Interior.Color = RGB(0, 179, 152)
        Case "vert_pelouse"
            c.Interior.Color = RGB(120, 190, 32)
    End Select
    Set c = Nothing
End Sub

'Procédure qui supprime la coloration de remplissage d'une cellule

Public Sub supprime_couleur_remplissage_cellule(ByVal feuille As String, _
                                                ByVal ligne_cellule As Integer, _
                                                ByVal colonne_cellule As Integer)
    Dim c As Range
    Set c = Worksheets(feuille).Cells(ligne_cellule, colonne_cellule)
        c.Interior.Pattern = xlNone
    Set c = Nothing
End Sub

'Procédure qui va mettre une bordure classique sur une cellule

Public Sub creer_bordure_cellule(ByVal feuille As String, _
                                 ByVal ligne_cellule As Integer, _
                                 ByVal colonne_cellule As Integer)
    Dim c As Range
    
    Set c = Worksheets(feuille).Cells(ligne_cellule, colonne_cellule)
    
    c.Borders(xlEdgeRight).LineStyle = xlContinuous
    c.Borders(xlEdgeBottom).LineStyle = xlContinuous
    c.Borders(xlEdgeLeft).LineStyle = xlContinuous
    c.Borders(xlEdgeTop).LineStyle = xlContinuous
        
    Set c = Nothing
End Sub
                                        
'Procédure qui supprime toutes les bordures d'une cellule

Public Sub supprime_bordure_cellule(ByVal feuille As String, _
                                 ByVal ligne_cellule As Integer, _
                                 ByVal colonne_cellule As Integer)
    Dim c As Range
    
    Set c = Worksheets(feuille).Cells(ligne_cellule, colonne_cellule)
    
    c.Borders(xlEdgeRight).LineStyle = xlNone
    c.Borders(xlEdgeBottom).LineStyle = xlNone
    c.Borders(xlEdgeLeft).LineStyle = xlNone
    c.Borders(xlEdgeTop).LineStyle = xlNone
        
    Set c = Nothing
End Sub

'==============================
' module : Preparation_donnees
'==============================

' Fonction qui renvoie le caractère d'une colonne à partir d'un entier
Public Function LettreColonne(NumCol As Integer) As String
    Dim reste, quotient As Long
    
    quotient = Int(NumCol / 26)
    reste = NumCol Mod 26
    If quotient = 0 And reste = 0 Then
        Exit Function
    End If
    ' si la cdc est comprise entre A et Z.
    If quotient = 0 Then
        LettreColonne = Chr(64 + reste)
    Else
        If reste = 0 Then
            quotient = quotient - 1
            If quotient = 0 Then
                LettreColonne = Chr(64 + 26)
            Else
                LettreColonne = Chr(64 + quotient) & Chr(64 + 26)
            End If
        Else
            LettreColonne = Chr(64 + quotient) & Chr(64 + reste)
        End If
    End If
End Function

'Procédure qui doit supprimer toutes les variables ne faisant pas partis d'une liste prédéfinie

Public Sub restriction_sur_variable(ByVal feuille_source As String, _
                                    ByVal feuille_ref As String, _
                                    ByVal cellule_ref As String)
    Dim f1 As Worksheet
    Dim f2 As Worksheet
    Dim c As Range
    Dim nb_var_nece, i As Integer
    Dim lettre As String
    
    Set f1 = Worksheets(feuille_source)
    Set f2 = Worksheets(feuille_ref)
    Set c = f2.Range(cellule_ref)
    
    nb_var_nece = compte_nb_cellule_non_vide(feuille_ref, "A3")
    i = 0
    
    Do While f1.Range("A1").End(xlToRight).Column <> nb_var_nece
        mot = f1.Range("A1").Offset(0, i).Value
        If Listes.est_dans_la_liste(mot, "Référencement", "A3", nb_var_nece) = True Then
            i = i + 1
        Else
            lettre = LettreColonne(f1.Range("A1").Offset(0, i).Column)
            lettre = lettre + ":" + lettre
            f1.Range(lettre).Delete xlShiftToLeft
        End If
    Loop
    
    Set f1 = Nothing
    Set f2 = Nothing
    Set c = Nothing
End Sub

'Procédure qui trie un jeu de donnée selon une variable

Public Sub trie_selon_une_variable(ByVal feuille As String, _
                                    ByVal cellule_hg As String, _
                                    ByVal cellule_bd As String, _
                                    ByVal colonne_haut As String, _
                                    ByVal colonne_bas As String, _
                                    ByVal croissant As Boolean, _
                                    ByVal entete As Boolean)
    Dim pdd As String
    Dim tri As String
    
    pdd = feuille + "!" + transforme_en_cellule_verou(cellule_hg) + ":" + transforme_en_cellule_verou(cellule_bd)
    
    tri = colonne_haut + ":" + colonne_bas
    
    ActiveWorkbook.Worksheets(feuille).Sort.SortFields.Clear
    If croissant = True And entete = True Then
        ActiveWorkbook.Worksheets(feuille).Sort.SortFields.Add _
            Key:=Range(tri), _
            SortOn:=xlSortOnValues, _
            Order:=xlAscending, _
            DataOption:=xlSortNormal
        With ActiveWorkbook.Worksheets(feuille).Sort
            .SetRange Range(pdd)
            .Header = xlYes
            .MatchCase = False
            .Apply
        End With
    ElseIf croissant = True And entete = False Then
        ActiveWorkbook.Worksheets(feuille).Sort.SortFields.Add _
            Key:=Range(tri), _
            SortOn:=xlSortOnValues, _
            Order:=xlAscending, _
            DataOption:=xlSortNormal
        With ActiveWorkbook.Worksheets(feuille).Sort
            .SetRange Range(pdd)
            .Header = xlNo
            .MatchCase = False
            .Apply
        End With
    ElseIf croissant = False And entete = True Then
        ActiveWorkbook.Worksheets(feuille).Sort.SortFields.Add _
            Key:=Range(tri), _
            SortOn:=xlSortOnValues, _
            Order:=xlDescending, _
            DataOption:=xlSortNormal
        With ActiveWorkbook.Worksheets(feuille).Sort
            .SetRange Range(pdd)
            .Header = xlYes
            .MatchCase = False
            .Apply
        End With
    Else
        ActiveWorkbook.Worksheets(feuille).Sort.SortFields.Add _
            Key:=Range(tri), _
            SortOn:=xlSortOnValues, _
            Order:=xlDescending, _
            DataOption:=xlSortNormal
        With ActiveWorkbook.Worksheets(feuille).Sort
            .SetRange Range(pdd)
            .Header = xlNo
            .MatchCase = False
            .Apply
        End With
    End If
End Sub
                                    
'Procédure qui liste l'ensemble des parcours du fichier source

Public Sub lister_parcours(ByVal feuille_affectee As String, _
                            ByVal cellule_depart As String, _
                            ByVal cellule_depart_dedup As String)
    Dim ws1 As Worksheet
    Dim ws2 As Worksheet
    Dim c1 As Range
    Dim c2 As Range
    Dim i As Integer
    
    Set ws1 = Worksheets("Données_sources")
    Set ws2 = Worksheets(feuille_affectee)
    Set c1 = ws1.Range(cellule_depart)
    Set c2 = ws2.Range(cellule_depart_dedup)
    
    'On renseigne le premier champs
    c2.Offset(1, 0).Value = c1.Value
    i = 1
    
    'On renseigne les autres champs
    Do While c1.Offset(i, 0).Value <> ""
        mot = c1.Offset(i, 0).Value
        nb_occ = compte_nb_cellule_non_vide(feuille_affectee, "C3")
        If est_dans_la_liste(mot, feuille_affectee, "C3", nb_occ) = False Then
            c2.End(xlDown).Offset(1, 0).Value = c1.Offset(i, 0).Value
        End If
        i = i + 1
    Loop
    
    Set ws1 = Nothing
    Set ws2 = Nothing
    Set c1 = Nothing
    Set c2 = Nothing
End Sub

'Procédure qui transforme une chaine de caractère par une autre

Public Sub remplace_X_par_Y(ByVal feuille As String, _
                            ByVal cellule_haut_gauche As String, _
                            ByVal X As String, _
                            ByVal Y As String)
    Dim ws As Worksheet
    Dim c As Range
    Dim i, j As Integer
    Dim num_ligne_max, num_col_max As Integer
    
    Set ws = Worksheets(feuille)
    Set c = ws = Range(cellule_haut_gauche)
    
    num_ligne_max = num_der_lignes(feuille)
    num_col_max = num_max_colonne_droite(feuille, cellule_haut_gauche)
    
    For i = c.Row To num_ligne_max Step 1
        For j = c.Column To num_col_max Step 1
            If ws.Cells(i, j).Value = X Then
                ws.Cells(i, j).Value = Y
            End If
        Next j
    Next i
    
    Set ws = Nothing
    Set c = Nothing
End Sub

'Procédure qui répare le problème de #NUL!

Public Sub repare_le_probleme_NUL(ByVal feuille As String, _
                                    ByVal cellule_haut_gauche As String)
    Dim ws As Worksheet
    Dim c As Range
    Dim i, j As Integer
    Dim num_ligne_max, num_col_max As Integer
    
    Set ws = Worksheets(feuille)
    Set c = ws.Range(cellule_haut_gauche)
    
    num_ligne_max = Tableau.num_der_lignes(feuille)
    num_col_max = Tableau.num_max_colonne_droite(feuille, cellule_haut_gauche)
    
    For i = c.Row To num_ligne_max Step 1
        For j = c.Column To num_col_max Step 1
            If ws.Cells(i, j).Formula = "=#NULL!" _
                Or ws.Cells(i, j).Formula = "=#NUL!" _
                Or ws.Cells(i, j).Formula = "#NULL!" _
                Or ws.Cells(i, j).Formula = "#NUL!" Then
                    ws.Cells(i, j).Clear
                    ws.Cells(i, j).Value = "NUL"
            End If
        Next j
    Next i
    
    Set ws = Nothing
    Set c = Nothing
End Sub

'Procédure qui va extraire une partie des données vers Extraction

Public Sub extrait_les_donnees(ByVal feuille_depart As String, _
                                ByVal feuille_arrivee As String, _
                                ByVal variable As String, _
                                ByVal modalite As String)
Dim ws1 As Worksheet
Dim ws2 As Worksheet
Dim i, indice_debut, indice_fin As Integer
Dim pdd, der_col, etiquette As String

Set ws1 = Worksheets(feuille_depart)
Set ws2 = Worksheets(feuille_arrivee)

indice_debut = num_first_occurence_modalite(feuille_depart, variable, modalite)
indice_fin = num_last_occurence_modalite(feuille_depart, variable, modalite)
der_col = LettreColonne(ws1.Range("A1").End(xlToRight).Column)
pdd = "A" + str(indice_debut) + ":" + der_col + str(indice_fin) + "," + "A1:" + der_col + "1"
pdd = retire_les_espaces(pdd)

ws1.Range(pdd).Copy
ws2.Range("A1").PasteSpecial
Call ClearClipboard

Set ws1 = Nothing
Set ws2 = Nothing

End Sub

'On supprime le terme "Licence professionnelle" en début d'intitulé de parcours

Public Sub supprime_LP_de_la_modalite()
    Dim f As Worksheet
    Dim i As Integer
    Dim parcours As String
    
    Set f = Worksheets("Référencement")
    
    For i = 3 To f.Range("C2").End(xlDown).Row Step 1
        parcours = f.Cells(i, 3).Value
        f.Cells(i, 3).Value = Mid(parcours, 25)
    Next i
    
    Set f = Nothing
End Sub

Public Function presence_incoherence_Base_VariablesRef(ByVal nb_variables As Integer) As Boolean
    Dim c1 As Range
    Dim c2 As Range
    Dim i, j As Integer
    Dim nb_concordance As Integer
    
    Set c1 = Worksheets("Référencement").Range("A3")
    Set c2 = Worksheets("Données_sources").Range("A1")
    
    nb_concordance = 0
    
    For i = 1 To nb_variables Step 1
        For j = 1 To nb_variables Step 1
            If c1.Offset(i - 1, 0).Value = c2.Offset(0, j - 1).Value Then
                nb_concordance = nb_concordance + 1
            End If
        Next j
    Next i
    
    If nb_concordance = nb_variables Then
        presence_incoherence_Base_VariablesRef = False
    Else
        presence_incoherence_Base_VariablesRef = True
    End If
    
    Set c1 = Nothing
    Set c2 = Nothing
End Function

Public Function presence_incoherence_Base_VariablesRef2() As Boolean
    Dim c1 As Range
    Dim c2 As Range
    Dim i, j As Integer
    Dim nb_concordance As Integer
    
    Set c1 = Worksheets("Référencement").Range("A3")
    Set c2 = Worksheets("Données_sources").Range("A1")
    
    nb_concordance = 0
    
    For i = 1 To c1.End(xlDown).Row - 2 Step 1
        For j = 1 To c2.End(xlToRight).Column Step 1
            If c1.Offset(i - 1, 0).Value = c2.Offset(0, j - 1).Value Then
                nb_concordance = nb_concordance + 1
            End If
        Next j
    Next i
    
    If nb_concordance = c1.End(xlDown).Row - 2 Then
        presence_incoherence_Base_VariablesRef2 = False
    Else
        presence_incoherence_Base_VariablesRef2 = True
    End If
    
    Set c1 = Nothing
    Set c2 = Nothing
End Function

'========================
' module : Référencement
'========================

'Fonction qui renvoie une valeur en fonction de la chaine de caractère passée en paramètre.

Public Function determine_code_calcul(ByVal feuille As String, _
                                        ByVal cellule_choix_user As String, _
                                        ByVal cellule_debut_liste_vert As String) As Single
    
    Dim ws As Worksheet
    Dim c2 As Range
    Dim c3 As Range
    Dim i As Integer
    Dim nb_choix_possible As Integer
    
    Set ws = Worksheets(feuille)
    Set c2 = ws.Range(cellule_choix_user)
    Set c3 = ws.Range(cellule_debut_liste_vert)
    
    Application.Volatile
    
    nb_choix_possible = compte_nb_cellule_non_vide(feuille, cellule_debut_liste_vert)
    determine_code_calcul = -99
    
    For i = 1 To nb_choix_possible Step 1
        If c2.Value = c3.Offset(i - 1, 0).Value Then
            If i = 1 Then
                determine_code_calcul = i - 100
            Else
                determine_code_calcul = i - 1
            End If
            Exit For
        End If
    Next i
    
    Set ws = Nothing
    Set c2 = Nothing
    Set c3 = Nothing
End Function

'Fonction qui renvoie le numéro de la colonne associée à un nom nom de variable recherchée

Public Function num_colonne_referencement(ByVal nom_variable As String) As Integer
    Dim ws As Worksheet
    Dim c As Range
    
    Set ws = Worksheets("Référencement")
    Set c = ws.Range("N2")
    
    num_colonne_referencement = 0
    
    For i = 0 To 200 Step 1
        If c.Offset(0, i).Value = nom_variable Then
            num_colonne_referencement = c.Offset(0, i).Column
            Exit For
        End If
    Next i
    
    Set ws = Nothing
    Set c = Nothing
End Function

'==================
' module : Tableau
'==================

'Fonction qui renvoie le nombre de ligne d'un jeu de données quelconque commençant en cellule A1

Public Function num_der_lignes(ByVal feuille As String) As Integer
    Dim ws As Worksheet
    Dim c As Range
    Dim i As Integer
    
    Set ws = Worksheets(feuille)
    Set c = ws.Range("A1")
    
    num_der_lignes = c.End(xlDown).Row
    
    Set ws = Nothing
    Set c = Nothing
End Function

' Fonction qui renvoie le numéro de la ligne correspondant à la première occurence

Public Function num_first_occurence_modalite(ByVal feuille As String, _
                                            ByVal variable As String, _
                                            ByVal modalite As String) As Integer
    Dim ws As Worksheet
    Dim i As Integer
    
    Set ws = Worksheets(feuille)

    num_der_l = num_der_lignes(feuille)
    num_col = numero_colonne(feuille, variable)
    
    num_first_occurence_modalite = 0
    
    For i = 2 To num_der_l Step 1
        If ws.Cells(i, num_col).Value = modalite Then
            num_first_occurence_modalite = i
            Exit For
        End If
    Next i
    
    Set ws = Nothing
End Function

' Fonction qui renvoie le numéro de la ligne correspondant à la dernière occurence

Public Function num_last_occurence_modalite(ByVal feuille As String, _
                                            ByVal variable As String, _
                                            ByVal modalite As String) As Integer
    Dim ws As Worksheet
    Dim i As Integer
    
    Set ws = Worksheets(feuille)

    
    num_der_l = num_der_lignes(feuille)
    num_col = numero_colonne(feuille, variable)
    
    num_last_occurence_modalite = 0
    
    For i = num_der_l To 2 Step -1
        If ws.Cells(i, num_col).Value = modalite Then
            num_last_occurence_modalite = i
            Exit For
        End If
    Next i
    
    Set ws = Nothing
End Function

'Fonction qui renvoie le numéro de colonne à partir d'un nom de variable

Public Function numero_colonne(ByVal feuille As String, _
                                ByVal variable As String) As Integer
    Dim ws As Worksheet
    Dim c As Range
    Dim i As Integer
    
    Set ws = Worksheets(feuille)
    Set c = ws.Range("A1")
    
    numero_colonne = 0
    
    For i = 1 To c.End(xlToRight).Column Step 1
        If c.Offset(0, i - 1).Value = variable Then
            numero_colonne = c.Offset(0, i - 1).Column
            Exit For
        End If
    Next i
    
    Set ws = Nothing
    Set c = Nothing
End Function

'Fonction qui renvoie le nom du parcours présent dans la feuille Extraction

Public Function premiere_modalite(ByVal feuille As String, _
                                  ByVal variable As String) As String
    Dim num_col As Integer
    num_col = numero_colonne(feuille, variable)
    premiere_modalite = Worksheets(feuille).Cells(2, num_col).Value
End Function

'Fonction qui renvoie le numéro de colonne au contenu non-vide le plus à droite

Public Function num_max_colonne_droite(ByVal feuille As String, _
                                        ByVal cellule_en_h_a_g As String) As Integer
    Dim ws As Worksheet
    Dim c As Range
    
    Set ws = Worksheets(feuille)
    Set c = ws.Range(cellule_en_h_a_g)
    
    num_max_colonne_droite = c.End(xlToRight).Column
    
    Set c = Nothing
    Set ws = Nothing
End Function

'Fonction qui renvoie un numéro de ligne correspondant à une modalité recherché

Public Function renvoie_num_ligne_modalite(ByVal feuille As String, _
                                            ByVal num_colonne As Integer, _
                                            ByVal nom_modalite As String) As Integer
    Dim f As Worksheet
    Dim c As Range
    
    Set f = Worksheets(feuille)
    Set c = f.Cells(1, num_colonne)
    
    For i = 0 To 10000 Step 1
        If c.Offset(i, 0).Value = nom_modalite Then
            renvoie_num_ligne_modalite = i + 1
            Exit For
        End If
    Next i
    
    Set f = Nothing
    Set c = Nothing
End Function

'Fonction qui renvoie le nom de la variable à partir d'un numéro de colonne

Public Function retrouve_nom_variable(ByVal feuille As String, _
                                        ByVal num_colonne As Integer) As String
    Dim f As Worksheet
    
    Set f = Worksheets(feuille)

    retrouve_nom_variable = f.Cells(1, num_colonne).End(xlUp).Value

    Set f = Nothing
End Function

'Procédure qui nettoie intégralement une feuille de calcul quelconque

Public Sub nettoie_integralement(ByVal feuille As String, _
                                 ByVal cellule_en_h_a_g As String)
    Dim num_der_ligne As Integer
    Dim num_der_colonne As Integer
    Dim lettre_der_colonne As String
    Dim plage As String
    
    num_der_ligne = Tableau.num_der_lignes(feuille)
    num_der_colonne = Worksheets(feuille).Range(cellule_en_h_a_g).End(xlToRight).Column
    lettre_der_colonne = Preparation_donnees.LettreColonne(num_der_colonne)
    plage = "A1:" + lettre_der_colonne + CStr(num_der_ligne)
    Worksheets(feuille).Range(plage).ClearContents
End Sub

'Fonction qui renvoie le nom de la cellule qui se trouve en bas à droite

Public Function renvoie_nom_cellule_en_b_a_d(ByVal feuille As String, _
                                            ByVal cellule_en_h_a_g As String) As String
    Dim num_der_ligne As Integer
    Dim num_der_colonne As Integer
    Dim lettre_der_colonne As String

    num_der_ligne = Tableau.num_der_lignes(feuille)
    num_der_colonne = Worksheets(feuille).Range(cellule_en_h_a_g).End(xlToRight).Column
    lettre_der_colonne = Preparation_donnees.LettreColonne(num_der_colonne)
    renvoie_nom_cellule_en_b_a_d = lettre_der_colonne + CStr(num_der_ligne)
End Function

'Fonction qui renvoie la lettre de la colonne à partir d'un nom de variable

Public Function lettre_colonne_var_recherchee(ByVal feuille As String, _
                                              ByVal variable As String) As String
    Dim ws As Worksheet
    Dim c As Range
    Dim i As Integer
    
    Set ws = Worksheets(feuille)
    Set c = ws.Range("A1")
    
    lettre_colonne_var_recherchee = "_"
    
    For i = 1 To c.End(xlToRight).Column Step 1
        If c.Offset(0, i - 1).Value = variable Then
            lettre_colonne_var_recherchee = LettreColonne(c.Offset(0, i - 1).Column)
            Exit For
        End If
    Next i
    
    Set ws = Nothing
    Set c = Nothing
End Function

'Fonction qui renvoie le numéro de la dernière ligne d'un jeu de données quelconque

Public Function num_der_lignes_V2(ByVal feuille As String, _
                                  ByVal cellule_en_h_a_g As String) As Integer
    Dim ws As Worksheet
    Dim c As Range
    Dim i As Integer
    
    Set ws = Worksheets(feuille)
    Set c = ws.Range(cellule_en_h_a_g)
    
    num_der_lignes_V2 = c.End(xlDown).Row
    
    Set ws = Nothing
    Set c = Nothing
End Function

'Fonction qui identifie si une variable est qualitative en renvoyant True sinon False.

Public Function est_variable_qualitative(ByVal nom_feuille As String, _
                                         ByVal nom_variable As String) As Boolean
    Dim f As Worksheet
    Dim i As Integer
    Dim modalite As String
    Dim num_colonne_variable As Integer
    Dim num_der_ligne As Integer
    Dim var_quali_trouvee As Boolean
    Dim nombre_chiffre_modalite As Integer
    
    Set f = Worksheets("Données_sources")
    
    i = 2
    var_quali_trouvee = False
    num_colonne_variable = Tableau.numero_colonne(nom_feuille, nom_variable)
    num_der_ligne = f.Range("A1").End(xlDown).Row
    
    Do While var_quali_trouvee = False Or i <= num_der_ligne
        modalite = f.Cells(i, num_colonne_variable).Value
        If modalite = "NUL" Then
            i = i + 1
        Else
            nombre_chiffre_modalite = nb_chiffres(modalite)
            If nombre_chiffre_modalite = Len(modalite) Or nombre_chiffre_modalite = Len(modalite) - 1 Then
                var_quali_trouvee = True
                Exit Do
            Else
                i = i + 1
            End If
        End If
    Loop
    
    est_variable_qualitative = var_quali_trouvee
    
    Set f = Nothing
End Function
                                         
'Procédure qui repère le numéro de la colonne la plus à gauche diponible sur la ligne 2

Public Function num_colonne_gauche_disponible(ByVal nom_feuille As String, _
                                         ByVal num_ligne As Integer)
    num_colonne_gauche_disponible = Worksheets(nom_feuille).Cells(num_ligne, 1000).End(xlToLeft).Column + 1
End Function

'==============================
' module : Test_des_conditions
'==============================

'Procédure qui défini un nombre de cellule en colonne comme étant une liste de variable

Public Sub Apply_liste_parametree_sur_cellule()
    Dim i As Integer
    For i = 0 To 90 Step 1
        Call liste_parametree_sur_cellule("Test_des_conditions", "Référencement", "B2", "A3", i)
    Next i
End Sub

'Procédure qui définie une liste sur une cellule en fonction d'une chaine de caractère

Public Sub Apply_liste_conditionnee(ByVal ligne_cellule_a_lister As Integer, _
                                    ByVal colonne_cellule_a_lister As Integer, _
                                    ByVal ligne_cellule_ref As Integer, _
                                    ByVal colonne_cellule_ref As Integer)
    Dim num_col As Integer
    Dim variable, cellule_du_haut, cellule_du_bas, plage As String
    
    variable = Worksheets("Test_des_conditions").Cells(ligne_cellule_ref, colonne_cellule_ref).Value
    num_col = Référencement.num_colonne_referencement(variable)
    If num_col <> 0 Then
        cellule_du_haut = recupere_nom_cellule(3, num_col)
        cellule_du_bas = nom_derniere_cellule_de_liste("Référencement", cellule_du_haut)
        plage = "=Référencement!" + transforme_en_cellule_verou(cellule_du_haut) + ":" + transforme_en_cellule_verou(cellule_du_bas)
        Worksheets("Test_des_conditions").Cells(ligne_cellule_a_lister, colonne_cellule_a_lister).Validation.Delete
        Worksheets("Test_des_conditions").Cells(ligne_cellule_a_lister, colonne_cellule_a_lister).Validation.Add xlValidateList, , , plage
    End If
End Sub

'Fonction qui va calculer un résultat en fonction de trois paramètres

Public Function calcul_resultat_du_filtre(ByVal val_obs As Variant, _
                                            ByVal operation As String, _
                                            ByVal val_filtre As Variant) As Integer
    calcul_resultat_du_filtre = 0
    If operation = "=" Then
        If val_obs = val_filtre Then
            calcul_resultat_du_filtre = 1
        End If
    ElseIf operation = "in" Then
        If est_dans_liste_de_cdc(val_obs, val_filtre) = True Then
            calcul_resultat_du_filtre = 1
        End If
    ElseIf operation = "<>" Then
        If val_obs <> val_filtre And val_obs <> "" And val_filtre <> "" Then
            calcul_resultat_du_filtre = 1
        End If
    ElseIf operation = "<" Then
        If val_obs < val_filtre Then
            calcul_resultat_du_filtre = 1
        End If
    ElseIf operation = "<=" Then
        If val_obs <= val_filtre Then
            calcul_resultat_du_filtre = 1
        End If
    ElseIf operation = ">=" Then
        If val_obs >= val_filtre Then
            calcul_resultat_du_filtre = 1
        End If
    ElseIf operation = ">" Then
        If val_obs > val_filtre Then
            calcul_resultat_du_filtre = 1
        End If
    Else
        calcul_resultat_du_filtre = 1
    End If
End Function

'Fonction qui vérifie si l'ensemble des conditions relatives à un code valeur est à 1

Public Function toutes_conditions_validees(ByVal code_valeur As String) As Boolean
    Dim i As Integer
    Dim ligne_max_Tdc As Integer
    Dim compteur_cd_valeur As Integer
    Dim compteur_ss_condition As Integer
    
    compteur_cd_valeur = 0
    compteur_ss_condition = 0
    ligne_max_Tdc = Tableau.num_der_lignes("Test_des_conditions")
    toutes_conditions_validees = False
    
    'On vérifie que le code_valeur est répertorié dans la liste des codes_valeurs
    If est_dans_la_liste_V2(code_valeur, "Test_des_conditions", "A2") = True Then
        For i = 2 To ligne_max_Tdc Step 1
            'On compte le nombre de ligne dans le champs "Code_valeur"
            If Worksheets("Test_des_conditions").Cells(i, 1).Value = code_valeur Then
                compteur_cd_valeur = compteur_cd_valeur + 1
                'On calcule la somme des valeurs des sous conditions
                If Worksheets("Test_des_conditions").Cells(i, 1).Offset(0, 5).Value = 1 Then
                    compteur_ss_condition = compteur_ss_condition + 1
                End If
            End If
        Next i
        If compteur_cd_valeur = compteur_ss_condition Then
            toutes_conditions_validees = True
        End If
    End If
End Function

'Fonction qui renvoie true si le code_valeur est rattaché à un calucl agrégé

Public Function est_calcul_agrege(ByVal code_valeur As String) As Boolean
    Dim f As Worksheet
    Dim i As Integer
    Dim ligne_max_Tdc As Integer
    
    Set f = Worksheets("Test_des_conditions")
    
    ligne_max_Tdc = Tableau.num_der_lignes("Test_des_conditions")
    est_calcul_agrege = False
    
    For i = 2 To ligne_max_Tdc Step 1
        If f.Cells(i, 1).Value = code_valeur Then
            Select Case f.Cells(i, 5).Value
                Case "somme", "moyenne", "médiane"
                    est_calcul_agrege = True
            End Select
        End If
    Next i
    
    Set f = Nothing
End Function

'Fonction qui récupère la valeur numérique observée est associée à la statistique

Public Function valeur_obs_calcul_agrege(ByVal code_valeur As String) As Single
    Dim f As Worksheet
    Dim i As Integer
    Dim ligne_max_Tdc As Integer
    
    Set f = Worksheets("Test_des_conditions")
    
    ligne_max_Tdc = Tableau.num_der_lignes("Test_des_conditions")
    valeur_obs_calcul_agrege = 0
    
    'Pour chaque ligne dans "Test des conditions"
    For i = 2 To ligne_max_Tdc Step 1
        'Si le code valeur correspond à celui en paramètre
        If f.Cells(i, 1).Value = code_valeur Then
            'Si le code valeur est soit une somme, soit une myenne ou soit une médiane alors
            Select Case f.Cells(i, 5).Value
                Case "somme", "moyenne", "médiane"
                    'Si l'individu n'a pas souhaité donner l'information
                    If f.Cells(i, 3).Value = "NUL" Then
                        valeur_obs_calcul_agrege = -99
                    'Sinon
                    Else
                        valeur_obs_calcul_agrege = f.Cells(i, 3).Value
                    End If
            End Select
        End If
    Next i
    
    Set f = Nothing
End Function

'Procédure one shot (une seule exécution) qui va rédiger l'ensemble des code valeur nécessitant un calcul agrégé

Public Sub redige_tableau_annexe_vierge_V2()
    Dim f1 As Worksheet
    Dim f2 As Worksheet
    Dim der_ligne_Tdc As Integer
    Dim der_ligne_Vc As Integer
    Dim ligne_cellule_etiquette As Integer
    Dim der_col_non_vide As Integer
    
    Set f1 = Worksheets("Test_des_conditions")
    Set f2 = Worksheets("Valeurs_calculées")
    
    'numéro de la dernière ligne dans "test des conditions"
    der_ligne_Tdc = Tableau.num_der_lignes("Test_des_conditions")
    'numéro de la dernière ligne dans "Valeurs calculées"
    der_ligne_Vc = Tableau.num_der_lignes("Valeurs_calculées")
    'numéro de ligne où on inscrit les codes valeurs où l'on effectuera un calcul statistique
    ligne_cellule_etiquette = der_ligne_Vc + 3
    
    'pour chaque ligne dans "Test des conditions"
    For i = 2 To der_ligne_Tdc Step 1
        'Si la condition concerne soit une somme, une moyenne ou une médiane alors
        If est_dans_la_liste_V2(f1.Cells(i, 5).Value, "Référencement", "L3") = True Then
            'Si la colonne B est vide alors
            If f2.Cells(ligne_cellule_etiquette, 2).Value = "" Then
                'On rentre les données code valeur et la statistique au dessus
                f2.Cells(ligne_cellule_etiquette, 2).Value = f1.Cells(i, 1).Value
                f2.Cells(ligne_cellule_etiquette - 1, 2).Value = f1.Cells(i, 5).Value
            'Sinon
            Else
                'On identifie la dernière colonne non vide et on y insère les deux éléments précédement cités
                der_col_non_vide = f2.Cells(ligne_cellule_etiquette, 200).End(xlToLeft).Column
                f2.Cells(ligne_cellule_etiquette, der_col_non_vide + 1).Value = f1.Cells(i, 1).Value
                f2.Cells(ligne_cellule_etiquette - 1, der_col_non_vide + 1).Value = f1.Cells(i, 5).Value
            End If
        End If
    Next i
    
    Set f1 = Nothing
    Set f2 = Nothing
End Sub

'Procédure qui va créer une coloration en fonction de la parité du code valeur

Public Sub MAJ_coloration_Tdc()
    Dim f As Worksheet
    Dim i As Integer
    Dim code_valeur As String
    Dim plage As String
    
    Set f = Worksheets("Test_des_conditions")
    ligne_max = num_der_lignes("Test_des_conditions")
    
    For i = 2 To ligne_max Step 1
        code_valeur = f.Cells(i, 1).Value
        plage = "A" + CStr(i) + ":E" + CStr(i)
        Select Case Right(code_valeur, 1)
            Case "1", "3", "5", "7", "9"
                f.Range(plage).Interior.Color = RGB(121, 248, 248)
            Case Else
                f.Range(plage).Interior.Color = RGB(84, 249, 141)
        End Select
    Next i
    Set f = Nothing
End Sub

'Procédure qui incrémente la valeur numérique du code_valeur

Public Sub Incremente_code_valeur_Tdc()
    Dim indice As Integer
    Dim val_increment As Integer
    Dim code_val_user As String
    Dim ligne_first_moda As Integer
    Dim ligne_max As Integer
    
    indice = InputBox("À partir de quel indice voulez-vous incrémeter le code valeur ?")
    val_increment = InputBox("De combien voulez-vous incrémenter la valeur numérique du code valeur ?")
    
    If indice > 0 Then
            'On construit la modalité recherché à partir de la valeur numérique fournie par l'utilisateur
            code_val_user = "cd_V" + CStr(indice)
            'On récupère le numéro de ligne où apparait la première occurence
            ligne_first_moda = renvoie_num_ligne_modalite("Test_des_conditions", 1, code_val_user)
            'On récupère la numéro de la dernière ligne non vide
            ligne_max = num_der_lignes("Test_des_conditions")
            For i = ligne_first_moda To ligne_max Step 1
                'On récupère la partie numérique de la cellule sur laquelle on se trouve
                val_a_incr = part_numerique_cellule(Worksheets("Test_des_conditions").Cells(i, 1).Value)
                'On rédefinit la valeur de la cellule en tenant compte de l'incrément de l'utilisateur
                Worksheets("Test_des_conditions").Cells(i, 1).Value = "cd_V" + CStr(val_a_incr + val_increment)
            Next i
    Else
        MsgBox ("L'indice de début doit être un nombre entier positif non nul.")
        Exit Sub
    End If
End Sub

'============================
' module : Valeurs_calculées
'============================

'Procédure qui va coller la liste des parcours vers la feuille "Valeurs_calculées"

Public Sub copie_liste_parcours(ByVal feuille_depart As String, _
                                ByVal cellule_depart As String, _
                                ByVal feuille_arrivee As String, _
                                ByVal cellule_arrivee As String)
    
    Dim ws1 As Worksheet
    Dim ws2 As Worksheet
    Dim nb_parc, ligne_init As Integer
    Dim lettre_col, pdd As String
    
    Set ws1 = Worksheets(feuille_depart)
    Set ws2 = Worksheets(feuille_arrivee)
    
    nb_parc = compte_nb_cellule_non_vide(feuille_depart, cellule_depart)
    ligne_init = part_numerique_cellule(cellule_depart)
    lettre_col = part_alphabetique_cellule(cellule_depart)
    pdd = lettre_col + CStr(ligne_init) + ":" + lettre_col + CStr(ligne_init + nb_parc - 1)
    
    ws1.Range(pdd).Copy
    ws2.Range(cellule_arrivee).PasteSpecial
    Call ClearClipboard
    
    Set ws1 = Nothing
    Set ws2 = Nothing
End Sub

'Fonction qui renvoie le numéro de ligne correspond au parcours

Public Function num_ligne_parcours_VC(ByVal nom_parcours As String) As Integer
    Dim i As Integer
    Dim ligne_max As Integer
    
    ligne_max = num_der_lignes("Valeurs_calculées")
    
    For i = 2 To ligne_max Step 1
        If Worksheets("Valeurs_calculées").Cells(i, 1).Value = nom_parcours Then
            num_ligne_parcours_VC = i
            Exit For
        End If
    Next i
End Function

'Procédure qui initialise toutes les valeurs des variables à 0

Public Sub initialise_ligne_du_parcours(ByVal feuille As String, _
                                        ByVal num_ligne As Integer)
    Dim num_col_max As Integer
    
    num_col_max = num_max_colonne_droite(feuille, "A1")
    
    For i = 2 To num_col_max Step 1
        Cells(num_ligne, i).Value = 0
    Next i
End Sub

'Procédure qui va calculer et insérer les résultats pour un parcours en particulier

Public Sub Compte_et_insere(ByVal feuille_de_donnees As String, _
                            ByVal feuille_de_reception As String, _
                            ByVal variable_final As String)
    Dim ws1 As Worksheet
    Dim ws2 As Worksheet
    Dim i As Integer
    Dim num_ligne_FDR, num_col_FDD, ligne_max_FDD As Integer
    Dim parc As String
    
    Set ws1 = Worksheets(feuille_de_donnees)
    Set ws2 = Worksheets(feuille_de_reception)
    
    parc = premiere_modalite(feuille_de_reception, "Parcours")
    num_ligne_FDR = num_ligne_parcours_VC(parc)
    num_col_FDD = numero_colonne(feuille_de_donnees, variable_final)
    ligne_max_FDD = num_der_lignes(feuille_de_donnees)
    
    For i = 1 To ligne_max_FDD Step 1
        If ws1.Cells(i, num_col_FDD).Value = "En emploi" Then
            ws2.Cells(num_ligne_FDR, 2).Value = ws2.Cells(num_ligne_FDR, 2).Value + 1
        ElseIf ws1.Cells(i, num_col_FDD).Value = "En recherche d'emploi" Then
            ws2.Cells(num_ligne_FDR, 3).Value = ws2.Cells(num_ligne_FDR, 3).Value + 1
        ElseIf ws1.Cells(i, num_col_FDD).Value = "En études" Then
            ws2.Cells(num_ligne_FDR, 4).Value = ws2.Cells(num_ligne_FDR, 4).Value + 1
        ElseIf ws1.Cells(i, num_col_FDD).Value = "Autre situation" Then
            ws2.Cells(num_ligne_FDR, 5).Value = ws2.Cells(num_ligne_FDR, 5).Value + 1
        End If
    Next i

    Set ws1 = Nothing
    Set ws2 = Nothing
End Sub

'Procédure qui  va réaliser un comptage paramètré par un nombre de filtre

Public Sub comptage_parametre(ByVal feuille_depart As String, _
                                ByVal feuille_arrivee As String, _
                                ByVal var_principale As String, _
                                Optional ByVal var_filtre1 As String = "0", _
                                Optional ByVal var_filtre2 As String = "0", _
                                Optional ByVal var_filtre3 As String = "0", _
                                Optional ByVal var_filtre4 As String = "0", _
                                Optional ByVal var_filtre5 As String = "0")

End Sub

'Procédure qui va construite un tableau annexe

Public Sub redige_tableau_annexe_vierge(ByVal code_valeur As String, _
                                        ByVal premiere_agregation As Boolean)
    
    Dim ligne_etiquette As Integer
    Dim der_col_non_vide As Integer
    
    'Repère la dernière ligne du tableau de la feuille "Valeurs_calculées" et ajoute 3 à cette dernière
    ligne_etiquette = Tableau.num_der_lignes("Valeurs_calculées") + 3
    'Redige le libellé code_valeur + agrégation en colonne B si premier, à la suite sinon
    If premiere_agregation = True Then
        Worksheets("Valeurs_calculées").Cells(ligne_etiquette, 2).Value = code_valeur
    Else
        der_col_non_vide = Worksheets("Valeurs_calculées").Cells(ligne_etiquette, 200).End(xlToLeft).Column
        Worksheets("Valeurs_calculées").Cells(ligne_etiquette, der_col_non_vide + 1).Value = code_valeur
    End If
End Sub

'Procédure qui va incrémenter la bonne cellule de la feuille "Valeurs_calculées"

Public Sub incremente_tableau_Vc(ByVal nom_parcours As String, _
                                 ByVal code_valeur As String, _
                                 Optional ByVal valeur_statistique As Single)
    Dim f As Worksheet
    Dim c As Range
    Dim ligne_parcours As Integer
    Dim num_colonne_cd_val As Integer
    
    Set f = Worksheets("Valeurs_calculées")
    ligne_parcours = renvoie_num_ligne_modalite("Valeurs_calculées", 1, nom_parcours)
    num_colonne_cd_val = numero_colonne("Valeurs_calculées", code_valeur)
    Set c = f.Cells(ligne_parcours, num_colonne_cd_val)
    
    'Pour le cas d'un resultat issu d'un comptage
    If valeur_statistique = 0 _
        And code_valeur <> f.Cells(f.Range("A1").End(xlDown).Row + 3, 2).Value _
        And code_valeur <> f.Cells(f.Range("A1").End(xlDown).Row + 3, 3).Value Then
        If ligne_parcours <> 0 And num_colonne_cd_val <> 0 Then
            If c.Value = "" Then
                c.Value = 1
            Else
                c.Value = c.Value + 1
            End If
        End If
    'Pour le cas d'un resultat issu d'un resultat statistique
    Else
        If ligne_parcours <> 0 And num_colonne_cd_val <> 0 Then
            c.Value = valeur_statistique
        End If
        'Application.ScreenUpdating = True
        'Application.ScreenUpdating = False
    End If
    
    Set f = Nothing
    Set c = Nothing
End Sub

'Procédure qui va enrichir la bonne cellule du tableau annexe de la feuille "Valeurs_calculées"

Public Sub alimente_tableau_annexe_Vc(ByVal code_valeur As String, _
                                      ByVal valeur_numerique As Single)
    Dim f As Worksheet
    Dim i As Integer
    Dim der_ligne_non_vide As Integer
    Dim ligne_etiquette As Integer
    'Dim num_colonne As Integer
    
    Set f = Worksheets("Valeurs_calculées")
    ligne_etiquette = Tableau.num_der_lignes("Valeurs_calculées") + 3
    
    'De 2 à 100 avec un pas de 1
    For j = 2 To 100 Step 1
        'Si la valeur du code valeur correspond à celle du paramètre
        If f.Cells(ligne_etiquette, j).Value = code_valeur Then
            'On identifie la ligne de la dernière valeur du code valeur
            der_ligne_non_vide_tab_anx = f.Cells(2000, j).End(xlUp).Row
            'On insère la valeur en dessous
            f.Cells(der_ligne_non_vide_tab_anx + 1, j).Value = valeur_numerique
            Exit For
        End If
    Next j
    
    Set f = Nothing
End Sub

'Procédure qui calcul une médiane à partir d'une plage de cellule en paramètre

Public Function calcul_agrege(ByVal plage_de_donnees As String, _
                              ByVal statisitque As String) As Single
    Dim f As Worksheet
    Dim c As Range
    
    Set f = Worksheets("Valeurs_calculées")
    Set c = f.Range(plage_de_donnees)
    
    If statisitque = "médiane" Then
        calcul_agrege = Application.Median(c)
    ElseIf statisitque = "moyenne" Then
        calcul_agrege = Application.Average(c)
    ElseIf statisitque = "somme" Then
        calcul_agrege = Application.Sum(c)
    End If
        
    Set f = Nothing
    Set c = Nothing
End Function

'Fonction qui identifie et renvoie une plage de données de valeur numérique selon le code_valeur

Public Function renvoie_plage_de_donnees(ByVal code_valeur As String) As String
    Dim f As Worksheet
    Dim j As Integer
    Dim ligne_etiquette As Integer
    Dim lettre_colonne As String
    Dim ligne_der_val_non_vide As Integer
    Dim plage As String
    
    Set f = Worksheets("Valeurs_calculées")
    ligne_etiquette = Tableau.num_der_lignes("Valeurs_calculées") + 3

    For j = 1 To 200 Step 1
        If f.Cells(ligne_etiquette, j).Value = code_valeur Then
            lettre_colonne = LettreColonne(j)
            Exit For
        End If
    Next j
    
    ligne_der_val_non_vide = f.Cells(2000, j).End(xlUp).Row
    If ligne_der_val_non_vide >= ligne_etiquette + 2 Then
        plage = lettre_colonne + CStr(ligne_etiquette + 1) + ":" + lettre_colonne + CStr(ligne_der_val_non_vide)
    Else
        plage = lettre_colonne + CStr(ligne_etiquette + 1)
    End If
    renvoie_plage_de_donnees = plage
    
    Set f = Nothing
End Function

'Procédure qui remplace les cellules vides par un zéro.

Public Sub replace_Vide_par_0(ByVal feuille As String)
    Dim w As Worksheet
    Dim i, j As Integer
    Dim der_l As Integer
    Dim der_c As Integer
    Set w = Worksheets(feuille)
    
    der_l = num_der_lignes(feuille)
    der_c = num_max_colonne_droite(feuille, "A1")
    
    For i = 1 To der_l Step 1
        For j = 1 To der_c Step 1
            If IsEmpty(w.Cells(i, j)) Then
                w.Cells(i, j).Value = 0
            End If
        Next j
    Next i
    
    Set w = Nothing
End Sub

'Procédure qui supprime les parcours ayant une valeur associé au code valeur trop faible

Public Sub supprime_parcours_impubliable(ByVal feuille As String, _
                                         ByVal code_valeur As String, _
                                         ByVal valeur_seuil As Integer)
    Dim w As Worksheet
    Dim num_col_code_valeur As Integer
    Set w = Worksheets(feuille)
    
    
    
    Set w = Nothing
End Sub

'Procédure qui va supprimer les parcours qui ne seront pas publié

Public Sub supprimer_fiches_non_publiees(ByVal code_valeur As String, _
                                         ByVal valeur_seuil As Integer)
    Dim i As Integer
    Dim num_der_ligne_Vc As Integer
    Dim num_col_code_valeur As Integer
    
    num_der_ligne_Vc = Worksheets("Valeurs_calculées").Range("A1").End(xlDown).Row
    num_col_code_valeur = numero_colonne("Valeurs_calculées", code_valeur)
    
    For i = num_der_ligne_Vc To 2 Step -1
        If Worksheets("Valeurs_calculées").Cells(i, num_col_code_valeur).Value <= valeur_seuil Then
            Worksheets("Valeurs_calculées").Cells(i, num_col_code_valeur).EntireRow.Delete 'shift:=xlUp
        End If
    Next i
    
End Sub

'Procédure qui va marquer les parcours qui ne seront pas publié

Public Sub reperage_fiches_non_publiees(ByVal code_valeur As String, _
                                         ByVal valeur_seuil As Integer)
    Dim i As Integer
    Dim num_der_ligne_Vc As Integer
    Dim num_col_code_valeur As Integer
    
    num_der_ligne_Vc = Worksheets("Valeurs_calculées").Range("A1").End(xlDown).Row
    num_col_code_valeur = numero_colonne("Valeurs_calculées", code_valeur)
    
    For i = 2 To num_der_ligne_Vc Step 1
        If Worksheets("Valeurs_calculées").Cells(i, num_col_code_valeur).Value <= valeur_seuil Then
            Worksheets("Valeurs_calculées").Rows(CStr(i) & ":" & CStr(i)).Interior.Color = RGB(0, 255, 255)
        End If
    Next i
    
End Sub

'Fonction qui renvoie Vrai si la ligne entière est marquée d'une couleur de remplissage particulière

Public Function est_parcours_avec_X_repondants_ou_moins(ByVal num_ligne As Integer) As Boolean
    If Worksheets("Valeurs_calculées").Rows(CStr(num_ligne) & ":" & CStr(num_ligne)).Interior.Color = RGB(0, 255, 255) Then
        est_parcours_avec_X_repondants_ou_moins = True
    Else
        est_parcours_avec_X_repondants_ou_moins = False
    End If
End Function

'===============================
' Feuille : Test des conditions
'===============================

Private Sub CommandButton1_Click()
    Call MAJ_coloration_Tdc
End Sub

Private Sub CommandButton2_Click()
    Call Incremente_code_valeur_Tdc
End Sub

Private Sub Worksheet_Change(ByVal Target As Range)
    Dim num_ligne As Integer
    Dim num_col As Integer
    
    num_ligne = Target.Row
    num_col = Target.Column
    
    'Si on modifie le champs "Variable" ça affectera les valeurs filtre
    If Target.Count = 1 And num_col = 2 And num_ligne > 1 And num_ligne < 20000 Then
        Cells(num_ligne, num_col + 3).Value = ""
        Call Apply_liste_conditionnee(num_ligne, num_col + 3, num_ligne, num_col)
        
    'Si une valeur est insérer dans le champs "Valeur observée" ça calculera la valeur du champs "Condition"
    ElseIf Target.Count = 1 And num_col = 3 And num_ligne > 1 And num_ligne < 20000 Then
        Cells(num_ligne, num_col + 3).Clear
        Cells(num_ligne, num_col + 3).Value = calcul_resultat_du_filtre(Cells(num_ligne, num_col).Value, _
                                                                        Cells(num_ligne, num_col + 1).Value, _
                                                                        Cells(num_ligne, num_col + 2).Value)
                                                                        
    'Si on modifie le type d'opération dans le champs "Opération" ça affectera le champs "Valeur filtre"
    ElseIf Target.Count = 1 And num_col = 4 And num_ligne > 1 And num_ligne < 20000 Then
        If Cells(num_ligne, num_col).Value = "in" Or _
            Cells(num_ligne, num_col).Value = "<=" Or _
            Cells(num_ligne, num_col).Value = "<" Or _
            Cells(num_ligne, num_col).Value = ">" Or _
            Cells(num_ligne, num_col).Value = ">=" Then
                Cells(num_ligne, num_col + 1).Value = ""
                Cells(num_ligne, num_col + 1).Validation.Delete
        ElseIf Cells(num_ligne, num_col).Value = "=" Or _
            Cells(num_ligne, num_col).Value = "<>" Then
                Cells(num_ligne, num_col + 1).Value = ""
                Call Apply_liste_conditionnee(num_ligne, _
                                                num_col + 1, _
                                                num_ligne, _
                                                num_col - 2)
        Else
            Cells(num_ligne, num_col + 1).Value = ""
            Call liste_parametree_sur_cellule("Test_des_conditions", _
                                                "Référencement", _
                                                recupere_nom_cellule(num_ligne, num_col + 1), _
                                                "L3")
        End If
    End If
End Sub

'=================
' Feuille : Fiche
'=================

Private Sub Worksheet_Change(ByVal Target As Range)
    Dim avancement As Integer
    Dim avancement_legende As Integer
    If Target.Count = 1 Then
    
        If Target.Column = 46 And Target.Row = 8 Then
            
            If Target.Offset(-3, 0).Value <> "" _
                And Target.Offset(-2, 0).Value <> "" _
                And Target.Offset(-1, 0).Value <> "" _
                And Target.Value <> "" Then
                    avancement = 0
                    avancement_legende = 6
                    Call formes_en_position_initiale
                    Call legendes_en_position_initiale
                    If Target.Offset(1, 0).Value <= -1 Then 'Dans le cas où l'on se trouve en présence de pourcentage
                        'On paramètre la modalité en emploi
                        If Target.Offset(-3, 0).Value > 0 Then
                            Call modifier_dimension_forme2("Fiche", "En emploi", 428 * (Target.Offset(-3, 0).Value))
                            avancement = avancement + (428 * (Target.Offset(-3, 0).Value))
                            Call rendre_forme_visible("Fiche", "En emploi")
                        End If
                        'On paramètre la modalité en recherche d'emploi
                        If Target.Offset(-2, 0).Value > 0 Then
                            Call modifier_positionnement_forme("Fiche", "En recherche emploi", avancement)
                            Call modifier_dimension_forme2("Fiche", "En recherche emploi", 428 * (Target.Offset(-2, 0).Value))
                            avancement = avancement + (428 * (Target.Offset(-2, 0).Value))
                            Call rendre_forme_visible("Fiche", "En recherche emploi")
                        End If
                        'On paramètre la modalité en études
                        If Target.Offset(-1, 0).Value > 0 Then
                            Call modifier_positionnement_forme("Fiche", "En études", avancement)
                            Call modifier_dimension_forme2("Fiche", "En études", 428 * (Target.Offset(-1, 0).Value))
                            avancement = avancement + (428 * (Target.Offset(-1, 0).Value))
                            Call rendre_forme_visible("Fiche", "En études")
                        End If
                        'On paramètre la modalité autre situation
                        If Target.Value > 0 Then
                            Call modifier_positionnement_forme("Fiche", "Autre situation", avancement)
                            Call modifier_dimension_forme2("Fiche", "Autre situation", 428 * (Target.Value))
                            Call rendre_forme_visible("Fiche", "Autre situation")
                        End If
                        
                    Else 'Dans le cas où l'on se trouve en présence d'effectifs
                    
                        'On paramètre la modalité en emploi
                        If Target.Offset(-3, 0).Value > 0 Then
                            Call modifier_dimension_forme2("Fiche", "En emploi", 371 * (Target.Offset(-3, 0).Value / Target.Offset(1, 0).Value))
                            avancement = avancement + (371 * (Target.Offset(-3, 0).Value / Target.Offset(1, 0).Value))
                            Call rendre_forme_visible("Fiche", "En emploi")
                            Call inserer_texte_dans_forme("Fiche", "En emploi", CStr(Target.Offset(-3, 0).Value))
                            Call applique_couleur_remplissage("Fiche", 15, avancement_legende, "violet_pourpre")
                            Call creer_bordure_cellule("Fiche", 15, avancement_legende)
                            Worksheets("Fiche").Cells(15, avancement_legende + 1).Value = "En emploi"
                            avancement_legende = avancement_legende + 5
                        End If
                        'On paramètre la modalité en recherche d'emploi
                        If Target.Offset(-2, 0).Value > 0 Then
                            Call modifier_positionnement_forme("Fiche", "En recherche emploi", avancement)
                            Call modifier_dimension_forme2("Fiche", "En recherche emploi", 371 * (Target.Offset(-2, 0).Value / Target.Offset(1, 0).Value))
                            avancement = avancement + (371 * (Target.Offset(-2, 0).Value / Target.Offset(1, 0).Value))
                            Call rendre_forme_visible("Fiche", "En recherche emploi")
                            Call inserer_texte_dans_forme("Fiche", "En recherche emploi", CStr(Target.Offset(-2, 0).Value))
                            Call applique_couleur_remplissage("Fiche", 15, avancement_legende, "bleu_marine")
                            Call creer_bordure_cellule("Fiche", 15, avancement_legende)
                            Worksheets("Fiche").Cells(15, avancement_legende + 1).Value = "En recherche d'emploi"
                            avancement_legende = avancement_legende + 9
                        End If
                        'On paramètre la modalité en études
                        If Target.Offset(-1, 0).Value > 0 Then
                            Call modifier_positionnement_forme("Fiche", "En études", avancement)
                            Call modifier_dimension_forme2("Fiche", "En études", 371 * (Target.Offset(-1, 0).Value / Target.Offset(1, 0).Value))
                            avancement = avancement + (371 * (Target.Offset(-1, 0).Value / Target.Offset(1, 0).Value))
                            Call rendre_forme_visible("Fiche", "En études")
                            Call inserer_texte_dans_forme("Fiche", "En études", CStr(Target.Offset(-1, 0).Value))
                            Call applique_couleur_remplissage("Fiche", 15, avancement_legende, "vert_bouteille")
                            Call creer_bordure_cellule("Fiche", 15, avancement_legende)
                            Worksheets("Fiche").Cells(15, avancement_legende + 1).Value = "En études"
                            avancement_legende = avancement_legende + 5
                        End If
                        'On paramètre la modalité autre situation
                        If Target.Value > 0 Then
                            Call modifier_positionnement_forme("Fiche", "Autre situation", avancement)
                            Call modifier_dimension_forme2("Fiche", "Autre situation", 371 * (Target.Value / Target.Offset(1, 0).Value))
                            Call rendre_forme_visible("Fiche", "Autre situation")
                            Call inserer_texte_dans_forme("Fiche", "Autre situation", CStr(Target.Value))
                            Call applique_couleur_remplissage("Fiche", 15, avancement_legende, "vert_pelouse")
                            Call creer_bordure_cellule("Fiche", 15, avancement_legende)
                            Worksheets("Fiche").Cells(15, avancement_legende + 1).Value = "Autre situation"
                        End If
                        
                    End If
            End If
            
         'Secteur d'activité
         ElseIf Target.Column = 46 And Target.Row = 62 And Target.Value <> "" Then
            If Target.Value = 0 Then
                Rows("62:62").EntireRow.Hidden = True
            Else
                Rows("62:62").EntireRow.Hidden = False
            End If
            
        ElseIf Target.Column = 46 And Target.Row = 63 And Target.Value <> "" Then
            If Target.Value = 0 Then
                Rows("63:63").EntireRow.Hidden = True
            Else
                Rows("63:63").EntireRow.Hidden = False
            End If
            
        ElseIf Target.Column = 46 And Target.Row = 64 And Target.Value <> "" Then
            If Target.Value = 0 Then
                Rows("64:64").EntireRow.Hidden = True
            Else
                Rows("64:64").EntireRow.Hidden = False
            End If
            
        'Lieu d'emploi
         
        ElseIf Target.Column = 46 And Target.Row = 70 Then
            Worksheets("Fiche").ChartObjects("lieu_emploi_graphique").Activate
            ActiveChart.SetElement (msoElementDataLabelNone)
            ActiveChart.SetElement (msoElementDataLabelCenter)
            ActiveChart.FullSeriesCollection(1).DataLabels.Select
            With Selection.Format.TextFrame2.TextRange.Font.Fill
                '.ForeColor.ObjectThemeColor = RGB(255, 255, 255)
                '.ForeColor.RGB = RGB(255, 255, 255)
                .ForeColor.ObjectThemeColor = msoThemeColorBackground1
            End With
            For i = 0 To 4 Step 1
                If Target.Offset(-i, 0).Value = 0 Then
                    Rows(CStr(70 - i) & ":" & CStr(70 - i)).EntireRow.Hidden = True
                Else
                    Rows(CStr(70 - i) & ":" & CStr(70 - i)).EntireRow.Hidden = False
                    Select Case i
                    Case Is = 0
                        Worksheets("Fiche").ChartObjects("lieu_emploi_graphique").Activate
                        ActiveChart.FullSeriesCollection(1).Points(5).Select
                        Selection.Format.Fill.ForeColor.RGB = RGB(29, 66, 138)
                        Worksheets("Fiche").ChartObjects("Lieu_emploi_labels").Activate
                        ActiveChart.FullSeriesCollection(1).Points(5).Select
                        Selection.Format.Fill.ForeColor.RGB = RGB(29, 66, 138)
                    Case Is = 1
                        Worksheets("Fiche").ChartObjects("lieu_emploi_graphique").Activate
                        ActiveChart.FullSeriesCollection(1).Points(4).Select
                        Selection.Format.Fill.ForeColor.RGB = RGB(211, 130, 53)
                        Worksheets("Fiche").ChartObjects("Lieu_emploi_labels").Activate
                        ActiveChart.FullSeriesCollection(1).Points(4).Select
                        Selection.Format.Fill.ForeColor.RGB = RGB(211, 130, 53)
                    Case Is = 2
                        Worksheets("Fiche").ChartObjects("lieu_emploi_graphique").Activate
                        ActiveChart.FullSeriesCollection(1).Points(3).Select
                        Selection.Format.Fill.ForeColor.RGB = RGB(141, 200, 232)
                        Worksheets("Fiche").ChartObjects("Lieu_emploi_labels").Activate
                        ActiveChart.FullSeriesCollection(1).Points(3).Select
                        Selection.Format.Fill.ForeColor.RGB = RGB(141, 200, 232)
                    Case Is = 3
                        Worksheets("Fiche").ChartObjects("lieu_emploi_graphique").Activate
                        ActiveChart.FullSeriesCollection(1).Points(2).Select
                        Selection.Format.Fill.ForeColor.RGB = RGB(249, 66, 58)
                        Worksheets("Fiche").ChartObjects("Lieu_emploi_labels").Activate
                        ActiveChart.FullSeriesCollection(1).Points(2).Select
                        Selection.Format.Fill.ForeColor.RGB = RGB(249, 66, 58)
                    Case Is = 4
                        Worksheets("Fiche").ChartObjects("lieu_emploi_graphique").Activate
                        ActiveChart.FullSeriesCollection(1).Points(1).Select
                        Selection.Format.Fill.ForeColor.RGB = RGB(127, 160, 172)
                        Worksheets("Fiche").ChartObjects("Lieu_emploi_labels").Activate
                        ActiveChart.FullSeriesCollection(1).Points(1).Select
                        Selection.Format.Fill.ForeColor.RGB = RGB(127, 160, 172)
                    End Select
                End If
                
            Next i
            
        'Satisfaction
        ElseIf Target.Column = 46 And Target.Row = 34 Then
            If Target.Offset(-1, 0).Value >= Target.Value Then
                Call rendre_forme_visible("Fiche", "Satis_emploi")
                Call rendre_forme_invisible("Fiche", "Insatis_emploi")
            Else
                Call rendre_forme_visible("Fiche", "Insatis_emploi")
                Call rendre_forme_invisible("Fiche", "Satis_emploi")
            End If
            
        ElseIf Target.Column = 46 And Target.Row = 36 Then
            If Target.Offset(-1, 0).Value >= Target.Value Then
                Call rendre_forme_visible("Fiche", "Satis_LP")
                Call rendre_forme_invisible("Fiche", "Insatis_LP")
            Else
                Call rendre_forme_visible("Fiche", "Insatis_LP")
                Call rendre_forme_invisible("Fiche", "Satis_LP")
            End If
            
        End If
    End If
End Sub

'==========
' Classeur
'==========

Private Sub Workbook_BeforeSave(ByVal SaveAsUI As Boolean, Cancel As Boolean)
    If Worksheets.Count <> 6 Or Worksheets(4).Name <> "Test_des_conditions" Then
        MsgBox "Attention vous avez modifié ou supprimé une feuille de calcul" & vbCrLf & _
               "importante au bon déroulement de l'exécution de la macro Excel." & vbCrLf & vbCrLf & _
               "Veuillez enregistrer votre fichier sous un nom différent. "
        Cancel = True
        SaveAsUI = True
    End If
End Sub

__C2__

__C3__

'Procédure principale qui va l'automatisation
Public Sub automatisation_fiches_Eric()
    'Déclaration d'objet de type feuille de calcul
    Dim f_R As Worksheet
    Dim f_Ds As Worksheet
    Dim f_E As Worksheet
    Dim f_E2 As Worksheet
    Dim f_Vc As Worksheet
    Dim f_Tdc As Worksheet
    Dim f_F As Worksheet

    'Déclaration de variable de type chaine de caractère
    Dim cellule_en_h_a_g_Ds As String
    Dim cellule_en_b_a_d_Ds As String
    Dim cellule_haut_colonne_tri_Ds As String
    Dim cellule_haut_colonne_tri2_Ds As String
    Dim cellule_bas_colonne_tri_Ds As String
    Dim cellule_bas_colonne_tri2_Ds
    Dim cellule_haut_parcours_Ds As String
    Dim intitule_var_parcours As String
    Dim intitule_var_parcours_0 As String
    Dim intitule_modalite_parcours As String
    Dim intitule_modalite_champs As String
    Dim nom_variable_E As String
    Dim nom_variable_E2 As String
    Dim nom_variable_Tdc As String
    Dim nom_code_valeur As String
    Dim plage As String
    Dim statistique As String
    Dim nom_code_valeur_tableau_droite_Pc As String
    Dim chemin As String
    Dim nom_modalite_granularite As String
    
    'Déclaration de variable de type entier naturel
    Dim g, h, i, j, k, l, m, n As Integer
    Dim nb_total_parcours As Integer
    Dim nb_total_champs As Integer
    Dim nb_etudiants_E As Integer
    Dim nb_etudiants_E2 As Integer
    Dim nb_variables As Integer
    Dim num_ligne_max_Tdc As Integer
    Dim num_der_col_Vc As Integer
    Dim ligne_code_valeur_agrege As Integer
    Dim num_derniere_cellule_Pc As Integer
    Dim numero_derniere_ligne_tableau_droite_Pc As Integer
    Dim numero_derniere_ligne_tableau_gauche_Pc As Integer
    Dim compteur_eff_stat As Integer
    Dim total_condition_eff_stat As Integer
    Dim compteur_pct As Integer
    Dim total_condition_pct As Integer
    Dim num_colonne_code_valeur_Vc As Integer
    Dim num_ligne_der_moda_parcours As Integer
    Dim compteur_boucle As Integer
    Dim compteur_progression As Integer
    Dim nb_occ_1_pct As Integer
    Dim compteur_fiches_publies As Integer
    Dim compteur_a_publier As Integer
    Dim nb_val_non_vide As Integer
    
    'Déclaration de variable de type nombre réel
    Dim valeur_num_obs As Single
    Dim valeur_stat As Single
    Dim nombre_code_valeur_Vc As Single
    Dim valeur_pourcentage As Single
    
    'Déclaration de variable de type indéterminé
    Dim valeur_variable_E As Variant
    Dim valeur_variable_E2 As Variant
    
    'Déclaration de variable de type booléen
    Dim code_val_gauche_trouve As Boolean
    Dim acceptation_petits_effectifs As Boolean
    
        '*************************************
        ' Initialisation des variables objets
        '*************************************

    Set f_R = Worksheets("Référencement")
    Set f_Ds = Worksheets("Données_sources")
    Set f_E = Worksheets("Extraction")
    Set f_E2 = Worksheets("Extraction2")
    Set f_Vc = Worksheets("Valeurs_calculées")
    Set f_Tdc = Worksheets("Test_des_conditions")
    Set f_F = Worksheets("Fiche")
    
    'Permet de désactiver la mise à jour de la visualisation de la fenêtre
    Application.ScreenUpdating = False
    
    'La barre des status n'est plus afficher
    Application.DisplayStatusBar = False
    
    'Les recalculs ne se font plus automatiquement
    Application.Calculation = xlCalculationManual
    
        '**************************************
        ' Initialisation des variables stables
        '**************************************
        
    'On part du principe que l'utilisateur ne souhaite pas publier les parcours ayant un trop faible nombre de répondants
    acceptation_petits_effectifs = False
        
    'On compte le nombre de variables nécessaires à la production des indicateurs d'une fiche quelconque
    nb_variables = Listes.compte_nb_cellule_non_vide("Référencement", _
                                                     "A3")
                                                          
    'On récupère le numéro de la dernière colonne du tableau de la feuille "Valeurs_calculées"
    num_der_col_Vc = Tableau.num_max_colonne_droite("Valeurs_calculées", _
                                                    "A1")
                                                    
    'On récupère le numéro de la dernière ligne du tableau de la feuille "Test_des_conditions"
    num_ligne_max_Tdc = Tableau.num_der_lignes("Test_des_conditions")
    
        '*******************************
        ' Restriction sur les variables
        '*******************************
    
    'Procédure qui ne conserve uniquement (dans la feuille "Données_sources") les variables déclarées dans la feuille "Référencement"
    Call Preparation_donnees.restriction_sur_variable("Données_sources", _
                                                      "Référencement", _
                                                      "A3")
                                                      
        '*******************************
        ' Modification des non-reponses
        '*******************************
    
    'Procédure qui remplace les #NUL! et les #NULL! par "NUL" dans la feuille "Données_sources"
    Call Preparation_donnees.repare_le_probleme_NUL("Données_sources", _
                                                    "A1")
                                
        '**********************************
        ' Recensement des noms de parcours
        '**********************************
    
    'On parcours le tableau présent dans la feuille "Référencement" pour déterminer le nom des variables (granularités) à considèrer
    For h = 1 To 4 Step 1
        If f_R.Range("N13").Offset(h, 0).Value <> "" Then
            intitule_var_parcours_0 = f_R.Range("N13").Offset(h, -2).Value  'variable associée à l'élément comparant
        End If
        If f_R.Range("M13").Offset(h, 0).Value <> "" Then
            intitule_var_parcours = f_R.Range("M13").Offset(h, -1).Value    'variable associée à l'élément comparé
        End If
    Next h
                                
    'On affecte à intitule_var_parcours le nom de la variable comparé et intitule_var_parcours_0 le nom de la variable comparante
    f_R.Range("C2").Value = intitule_var_parcours
    If intitule_var_parcours_0 <> "" Then
        f_R.Range("D2").Value = intitule_var_parcours_0
    End If
    
    'On affecte à 4 variables des noms de cellules qui nous permettront de réaliser un tri selon la granularité dite comparé
    cellule_en_h_a_g_Ds = "A1"
    
    cellule_en_b_a_d_Ds = Tableau.renvoie_nom_cellule_en_b_a_d("Données_sources", _
                                                               "A1")
                                                               
    cellule_haut_colonne_tri_Ds = Tableau.lettre_colonne_var_recherchee("Données_sources", _
                                                                        intitule_var_parcours) + CStr(2)
                                                                        
    cellule_bas_colonne_tri_Ds = Tableau.lettre_colonne_var_recherchee("Données_sources", _
                                                                        intitule_var_parcours) + _
                                                                        CStr(Tableau.num_der_lignes("Données_sources"))
                                                                            
    'Si nous sommes dans le cas d'une utilisation avec comparaison (comparé-comparant)
    If intitule_var_parcours_0 <> "" Then
        
        cellule_haut_colonne_tri2_Ds = Tableau.lettre_colonne_var_recherchee("Données_sources", _
                                                                            intitule_var_parcours_0) + CStr(2)
                                                                            
        cellule_bas_colonne_tri2_Ds = Tableau.lettre_colonne_var_recherchee("Données_sources", _
                                                                            intitule_var_parcours_0) + _
                                                                            CStr(Tableau.num_der_lignes("Données_sources"))
                                                                            
    End If
                                                                            
    'Procédure qui trie le tableau de données dans la feuille "Données_sources" selon une variable
    If intitule_var_parcours_0 = "" Then
    
        Call Preparation_donnees.trie_selon_une_variable("Données_sources", _
                                                        cellule_en_h_a_g_Ds, _
                                                        cellule_en_b_a_d_Ds, _
                                                        cellule_haut_colonne_tri_Ds, _
                                                        cellule_bas_colonne_tri_Ds, _
                                                        True, _
                                                        True)
                                                            
    Else
    
        Call Preparation_donnees.trie_selon_deux_variables("Données_sources", _
                                                            cellule_en_h_a_g_Ds, _
                                                            cellule_en_b_a_d_Ds, _
                                                            cellule_haut_colonne_tri2_Ds, _
                                                            cellule_bas_colonne_tri2_Ds, _
                                                            cellule_haut_colonne_tri_Ds, _
                                                            cellule_bas_colonne_tri_Ds)

    End If
                                                                     
    'On rédige dans la feuille "Référencement" l'ensemble des modalité de la variable comparée répertoriés dans la feuille "Données_sources"
    Call Preparation_donnees.lister_parcours("Référencement", _
                                            cellule_haut_colonne_tri_Ds, _
                                            "C2")
                                            
    'Call Extraction.ClearClipboard
                                            
    'On rédige dans la feuille "Référencement" l'ensemble des modalité de la variable comparante répertoriés dans la feuille "Données_sources"
    Call Preparation_donnees.lister_parcours_V2("Référencement", _
                                            cellule_haut_colonne_tri2_Ds, _
                                            "D2")
                                            
        '********************************************
        ' Paramétrage de la feuille Valeur Calculées
        '********************************************
        
    'On stocke dans une variable le numéro de ligne correspondant à la dernière modalité de parcours
    num_ligne_der_moda_parcours = f_R.Range("C3").End(xlDown).Row
    
    'On copie la liste des noms de parcours
    f_R.Range("C3:C" & CStr(num_ligne_der_moda_parcours)).Copy
    
    'On colle cette liste dans la feuille Valeurs Calculées
    f_Vc.Range("A2").PasteSpecial
    
    'On supprime des données contenues dans le presse-papier
    Call Extraction.ClearClipboard
        
    'On compte le nombre de parcours
    nb_total_parcours = Listes.compte_nb_cellule_non_vide("Référencement", _
                                                          "C3")
                                                          
    If intitule_var_parcours_0 <> "" Then
    
        'On compte le nombre de champs
        nb_total_champs = Listes.compte_nb_cellule_non_vide("Référencement", _
                                                          "D3")
                            
    End If
                                                    
    'Procédure qui va rédiger un tableau temporaire dans la feuille "Valeurs_calculées" pour le calcul des différentes statistiques
    Call Test_des_conditions.redige_tableau_annexe_vierge_V2 
           
    'Dans le cas où l'on doit comparé une granularité à une autre
    If intitule_var_parcours_0 <> "" Then
    
            '==========================
            ' Boucle sur chaque champs
            '==========================
    
        'On boucle pour chaque champs
        For g = 1 To 1 Step 1 'nb_total_champs
        
            'On récupère l'intitulé du champs
            intitule_modalite_champs = f_R.Range("D2").Offset(g, 0).Value
            
            'On copie-colle les étudiants appartenant au champs depuis "Données_sources" vers "Extraction2"
            Call Preparation_donnees.extrait_les_donnees("Données_sources", _
                                                        "Extraction2", _
                                                        intitule_var_parcours_0, _
                                                        intitule_modalite_champs)
                                                        
            'On applique une coloration qui détermine quelles étapes sont rattachées au champs
            Call Référencement.coloration_etape_du_champs("Extraction2", _
                                                        "Référencement", _
                                                        intitule_modalite_champs, _
                                                        intitule_var_parcours, _
                                                        "C2")
                                                                
            'On compte le nombre d'étudiants présent dans le champs (-1 car en fait on repère le numéro de la ligne)
            nb_etudiants_E2 = Tableau.num_der_lignes("Extraction2")
        
                '============================
                ' Boucle sur chaque étudiant
                '============================
                
            'On stocke dans une cellule l'heure à laquelle on commence les longs traitements
            f_R.Range("K23").Value = Time
        
            'On boucle pour chaque étudiant du champs
            For i = 2 To nb_etudiants_E2 Step 1 '
            
                    '============================
                    ' Boucle sur chaque variable
                    '============================
                
                'On boucle pour chaque variable
                For j = 1 To nb_variables Step 1
                
                    'On récupère le nom de la variable dans le tableau de la feuille "Extraction2"
                    nom_variable_E2 = Tableau.retrouve_nom_variable("Extraction2", j)
                    
                    'On récupére la valeur de la variable dans le tableau de la feuille "Extraction2"
                    valeur_variable_E2 = f_E2.Cells(i, j).Value
                    
                        '==============================
                        ' Boucle sur chaque conditions
                        '==============================
                    
                    'On boucle pour chaque condition
                    For k = 2 To num_ligne_max_Tdc Step 1
    
                        'On récupère le nom de la variable qui fait office de filtre dans la feuille "Test_des_conditions"
                        nom_variable_Tdc = f_Tdc.Cells(k, 2).Value
                        
                        'On récupère le nom de la modalité correspondant à la granularité de la feuille "Test des conditions"
                        nom_modalite_granularite = f_Tdc.Cells(k, 7).Value
                        
                        'On teste si le nom de variable est le même que celui dans la feuille "Extraction2" et qu'il s'agit d'un indicateur "comparant"
                        If nom_variable_Tdc = nom_variable_E2 And nom_modalite_granularite = "Comparant" Then
                        
                                'On renseigne la valeur de la variable dans le champs "Valeur_observée" de la feuille "Test_des_conditions"
                                f_Tdc.Cells(k, 3).Value = valeur_variable_E2
                            
                        End If
                        
                    Next k
            
                Next j
                
                    '===============================
                    ' Boucle sur chaque code valeur
                    '===============================
                
                'On boucle pour chaque code_valeur
                For l = 2 To num_der_col_Vc Step 1
                
                    'On récupère le nom du code_valeur
                    nom_code_valeur = f_Vc.Cells(1, l).Value
                    
                    'On récupère le nom de la modalité correspondant à la granularité de la feuille "Test des conditions"
                    For n = 2 To num_ligne_max_Tdc Step 1
                        
                        'Si la première colonne de Test_des_conditions correspond au code valeur avec une granularité "Comparant" alors
                        If f_Tdc.Cells(n, 1).Value = nom_code_valeur And f_Tdc.Cells(n, 7).Value = "Comparant" Then
                        
                            'On affecte à la variable nom_modalite_granularite la valeur "Comparant"
                            nom_modalite_granularite = "Comparant"
                            
                            Exit For
                            
                        'Sinon
                        ElseIf f_Tdc.Cells(n, 1).Value = nom_code_valeur And f_Tdc.Cells(n, 7).Value = "Comparé" Then
                            
                            'On affecte à la variable nom_modalite_granularite la valeur "Comparé"
                            nom_modalite_granularite = "Comparé"
                                
                            Exit For
                        
                        End If
                        
                    Next n
                    
                    'On vérifie si l'étudiant est éligible au comptage et que l'indicateur se calcule à partir de la variable dite "comparante"
                    If Test_des_conditions.toutes_conditions_validees(nom_code_valeur) = True And nom_modalite_granularite = "Comparant" Then
                    
                        'Si le code valeur est le résultat d'une statistique
                        If Test_des_conditions.est_calcul_agrege(nom_code_valeur) = True Then
                        
                            'On récupère la valeur à insérer
                            valeur_num_obs = Test_des_conditions.valeur_obs_calcul_agrege(nom_code_valeur)
                            
                            'On stocke la valeur dans le tableau temporaire de la feuille "Valeurs_calculées"
                            Call Valeurs_calculées.alimente_tableau_annexe_Vc(nom_code_valeur, valeur_num_obs)
                            
                        'Si le code valeur est le résultat d'un comptage
                        Else
                        
                            'On boucle sur toutes les étapes présentes dans la feuille "Valeurs_calculées"
                            For m = 1 To nb_total_parcours Step 1
                            
                                'Si l'étape correspond au champs (grace à la coloration de sa cellule) alors
                                If f_R.Cells(m + 2, 3).Interior.Color = RGB(0, 255, 255) Then
                                
                                    'On récupère le nom du parcours
                                    intitule_modalite_parcours = f_R.Cells(m + 2, 3).Value
                            
                                    'On incrémente la bonne cellule du tableau de la feuille "Valeurs_calculées"
                                    Call Valeurs_calculées.incremente_tableau_Vc(intitule_modalite_parcours, nom_code_valeur)
                                    
                                    'On quitte volontairement la boucle
                                    Exit For
                                    
                                End If
                                
                            Next m
                            
                        End If
                        
                    End If
                
                Next l
                
            Next i
            
            'On récupère le numéro de ligne correspondant à l'endroit où l'on va retrouver les différents code_valeur soumis au calcul d'une statistique
            ligne_code_valeur_agrege = Tableau.num_der_lignes("Valeurs_calculées") + 3
            
                '=================================
                ' Boucle sur chaque calcul agrégé
                '=================================
            
            'On boucle pour chaque code_valeur_agrégé (statistique)
            For m = 2 To 100 Step 1
            
                'On test s'il y a au moins un code valeur agrégé (statistique) à calculer
                If f_Vc.Cells(ligne_code_valeur_agrege, m).Value <> "" Then
                
                    'On test s'il y a au moins une valeur numérique associé au code valeur
                    If f_Vc.Cells(ligne_code_valeur_agrege + 1, m).Value <> "" Then
                    
                        'On récupère le nom du code valeur
                        nom_code_valeur = f_Vc.Cells(ligne_code_valeur_agrege, m).Value
                        
                        'On identifie et construit la plage de donnée qui va nous permettre d'effectuer le calcul de la statistique
                        plage = Valeurs_calculées.renvoie_plage_de_donnees(nom_code_valeur)
                        
                        'On remplace les valeurs nulles par "" pour ne pas les prendre en compte lors du calcul
                        f_Vc.Range(plage).Replace What:="-99", Replacement:="", LookAt:=xlPart, _
                            SearchOrder:=xlByRows, MatchCase:=False, SearchFormat:=False, _
                            ReplaceFormat:=False
                        
                        'On rècupère le nom de la statistique à effectuer
                        statistique = f_Vc.Cells(ligne_code_valeur_agrege - 1, m).Value
                        
                        'On calcule la valeur de la statistique
                        valeur_stat = Valeurs_calculées.calcul_agrege(plage, statistique)
                        
                        'On entre la valeur dans la bonne cellule du tableau de la feuille "Valeurs_Calculées"
                        Call Valeurs_calculées.incremente_tableau_Vc(intitule_modalite_parcours, nom_code_valeur, valeur_stat)
                        
                    End If
                    
                Else
                
                    Exit For
                    
                End If
            
            Next m
            
            'On supprime le contenu des cellules ayant permies de réaliser des calculs agrégés (statistique)
            f_Vc.Range("B81:CZ13000").ClearContents
            
                '=========================
                ' Boucle sur chaque etape
                '=========================
    
            'On boucle pour chaque parcours
            For h = 1 To nb_total_parcours Step 1 'nb_total_parcours
            
                'Si le parcours est bien rattaché au champs (coloration)
                If f_R.Range("C2").Offset(h, 0).Interior.Color = RGB(0, 255, 255) Then
            
                    'On récupère l'intitulé du parcours
                    intitule_modalite_parcours = f_R.Range("C2").Offset(h, 0).Value
                    
                    'On copie-colle les étudiants appartenant au parcours depuis "Extraction" vers "Extraction2"
                    Call Preparation_donnees.extrait_les_donnees("Extraction2", _
                                                                "Extraction", _
                                                                intitule_var_parcours, _
                                                                intitule_modalite_parcours)
                                                                
                    'On compte le nombre d'étudiants présent dans le parcours
                    nb_etudiants_E = Tableau.num_der_lignes("Extraction")
                    
                        '============================
                        ' Boucle sur chaque étudiant
                        '============================
                    
                    'On boucle pour chaque étudiant
                    For i = 2 To nb_etudiants_E Step 1
                    
                            '============================
                            ' Boucle sur chaque variable
                            '============================
                        
                        'On boucle pour chaque variable
                        For j = 1 To nb_variables Step 1
                        
                            'On récupère le nom de la variable dans le tableau de la feuille "Extraction"
                            nom_variable_E = Tableau.retrouve_nom_variable("Extraction", j)
                            
                            'On récupére la valeur de la variable dans le tableau de la feuille "Extraction"
                            valeur_variable_E = f_E.Cells(i, j).Value
                            
                                '==============================
                                ' Boucle sur chaque conditions
                                '==============================
                            
                            'On boucle pour chaque condition
                            For k = 2 To num_ligne_max_Tdc Step 1
            
                                'On récupère le nom de la variable qui fait office de filtre
                                nom_variable_Tdc = f_Tdc.Cells(k, 2).Value
                                
                                'On récupère le nom de la modalité correspondant à la granularité de la feuille "Test des conditions"
                                nom_modalite_granularite = f_Tdc.Cells(k, 7).Value
                                
                                'On teste si le nom de variable est le même que celui dans la feuille "Extraction"
                                If nom_variable_Tdc = nom_variable_E And f_Tdc.Cells(k, 7).Value = "Comparé" Then
                                
                                        'Si la condition du dessus est validé alors on renseigne la valeur de la variable dans le champs "Valeur_observée" de la feuille "Test_des_conditions"
                                        f_Tdc.Cells(k, 3).Value = valeur_variable_E
                                    
                                End If
                                
                            Next k
                    
                        Next j
                        
                            '===============================
                            ' Boucle sur chaque code valeur
                            '===============================
                        
                        'On boucle pour chaque code_valeur
                        For l = 2 To num_der_col_Vc Step 1
                        
                            'On récupère le nom du code_valeur
                            nom_code_valeur = f_Vc.Cells(1, l).Value
                            
                            'On récupère le nom de la modalité correspondant à la granularité de la feuille "Test des conditions"
                            For n = 2 To num_ligne_max_Tdc Step 1
                                
                                'Si la première colonne de Test_des_conditions correspond au code valeur avec une granularité "Comparé" alors
                                If f_Tdc.Cells(n, 1).Value = nom_code_valeur And f_Tdc.Cells(n, 7).Value = "Comparé" Then
                                
                                    nom_modalite_granularite = "Comparé"
                                    
                                    Exit For
                                    
                                ElseIf f_Tdc.Cells(n, 1).Value = nom_code_valeur And f_Tdc.Cells(n, 7).Value = "Comparant" Then
                                
                                    nom_modalite_granularite = "Comparant"
                                    
                                    Exit For
                                
                                End If
                                
                            Next n
                            
                            'On initialise toutes les variables rattaché à la granularité comparé à 0
                            If nom_modalite_granularite = "Comparé" And f_Vc.Cells(h + 1, l).Value = "" Then
                            
                                f_Vc.Cells(h + 1, l).Value = 0
                            
                            End If
                            
                            'On vérifie si l'étudiant est éligible au comptage
                            If Test_des_conditions.toutes_conditions_validees(nom_code_valeur) = True And nom_modalite_granularite = "Comparé" Then
                            
                                'Si l'étudiant est éligible on regarde si la variable est le résultat d'un comptage ou d'un calcul agrégé
                                If Test_des_conditions.est_calcul_agrege(nom_code_valeur) = True Then
                                
                                    'Calcul agrégé : On récupère la valeur à insérer
                                    valeur_num_obs = Test_des_conditions.valeur_obs_calcul_agrege(nom_code_valeur)
                                    
                                    '                On stocke les valeurs dans un tableau temporaire
                                    Call Valeurs_calculées.alimente_tableau_annexe_Vc(nom_code_valeur, valeur_num_obs)
                                    
                                Else
                                
                                    'Comptage : On incrémente la bonne cellule du tableau de la feuille "Valeurs_calculées"
                                    Call Valeurs_calculées.incremente_tableau_Vc(intitule_modalite_parcours, nom_code_valeur)
                                    
                                End If
                                
                            End If
                        
                        Next l
                        
                    Next i
                    
                    'On récupère le numéro de ligne correspondant à l'endroit où l'on va retrouver les différents code_valeur soumis au calcul d'agrégation
                    ligne_code_valeur_agrege = Tableau.num_der_lignes("Valeurs_calculées") + 3
                    
                        '=================================
                        ' Boucle sur chaque calcul agrégé
                        '=================================
                    
                    'On boucle pour chaque code_valeur_agrégé
                    For m = 2 To 100 Step 1
                    
                        'On test s'il y a au moins un code valeur agrégé
                        If f_Vc.Cells(ligne_code_valeur_agrege, m).Value <> "" Then
                        
                            'On test s'il y a au moins une valeur numérique associé au code valeur
                            If f_Vc.Cells(ligne_code_valeur_agrege + 1, m).Value <> "" Then
                            
                                'On récupère le nom du code valeur
                                nom_code_valeur = f_Vc.Cells(ligne_code_valeur_agrege, m).Value
                                
                                'On identifie et construit la plage de donnée qui va nous permettre d'effectuer le calcul de la statistique
                                plage = Valeurs_calculées.renvoie_plage_de_donnees(nom_code_valeur)
                                
                                'On remplace les valeurs nulles par "" pour ne pas les prendre en compte lors du calcul
                                f_Vc.Range(plage).Replace What:="-99", Replacement:="", LookAt:=xlPart, _
                                    SearchOrder:=xlByRows, MatchCase:=False, SearchFormat:=False, _
                                    ReplaceFormat:=False
                                    
                                'On compte le nombre de cellule ayant une valeur différent de ""
                                nb_val_non_vide = compte_nb_cellule_non_vide3("Valeurs_calculées", plage)
                                
                                'On rècupère le nom de la statistique à effectuer
                                statistique = f_Vc.Cells(ligne_code_valeur_agrege - 1, m).Value
                                
                                'Si le nombre de valeur non vide est supérieur ou egale à 20
                                If nb_val_non_vide >= 20 Then
                                
                                    'On calcule la valeur de la statistique
                                    valeur_stat = Valeurs_calculées.calcul_agrege(plage, statistique)
                                    
                                'Sinon
                                Else
                                
                                    'On renseigne une valeur statistique absurde
                                    valeur_stat = -999
                                    
                                End If
                                
                                'On entre la valeur dans la bonne cellule du tableau de la feuille "Valeurs_Calculées"
                                Call Valeurs_calculées.incremente_tableau_Vc2(intitule_modalite_parcours, nom_code_valeur, valeur_stat, nb_val_non_vide)
                                
                            End If
                            
                        Else
                        
                            Exit For
                            
                        End If
                    
                    Next m
                    'On supprime le contenu des cellules ayant permies de réaliser des calculs agrégés
                    f_Vc.Range("B81:CZ13000").ClearContents
                    
                    'On supprime le tableau présent sur la feuille "Extraction"
                    Call Tableau.nettoie_integralement("Extraction", "A1")
                    
                End If
                    
            Next h
        
        'On supprime le tableau présent sur la feuille "Extraction"
        Call Tableau.nettoie_integralement("Extraction2", "A1")
            
        'On supprime les couleurs de repère dans la feuille référencement
        Call Référencement.decoloration_etape_du_champs
            
        Next g
            
    Else
    
        'On boucle pour chaque parcours
        For h = 1 To nb_total_parcours Step 1
        
            'On récupère l'intitulé du parcours
            intitule_modalite_parcours = f_R.Range("C2").Offset(h, 0)
            
            'On copie-colle les étudiants appartenant au parcours depuis "Données_sources" vers "Extraction"
            Call Preparation_donnees.extrait_les_donnees("Données_sources", _
                                                        "Extraction", _
                                                        intitule_var_parcours, _
                                                        intitule_modalite_parcours)
                                                        
            'On compte le nombre d'étudiants présent dans le parcours
            nb_etudiants_E = Tableau.num_der_lignes("Extraction")
            
                '============================
                ' Boucle sur chaque étudiant
                '============================
            
            'On boucle pour chaque étudiant
            For i = 2 To nb_etudiants_E Step 1
            
                    '============================
                    ' Boucle sur chaque variable
                    '============================
                
                'On boucle pour chaque variable
                For j = 1 To nb_variables Step 1
                
                    'On récupère le nom de la variable dans le tableau de la feuille "Extraction"
                    nom_variable_E = Tableau.retrouve_nom_variable("Extraction", j)
                    
                    'On récupére la valeur de la variable dans le tableau de la feuille "Extraction"
                    valeur_variable_E = f_E.Cells(i, j).Value
                    
                    'On récupère le numéro de la dernière ligne du tableau de la feuille "Test_des_conditions"
                    num_ligne_max_Tdc = Tableau.num_der_lignes("Test_des_conditions")
                    
                        '==============================
                        ' Boucle sur chaque conditions
                        '==============================
                    
                    'On boucle pour chaque condition
                    For k = 2 To num_ligne_max_Tdc Step 1
    
                        'On récupère le nom de la variable qui fait office de filtre
                        nom_variable_Tdc = f_Tdc.Cells(k, 2).Value
                        
                        'On teste si le nom de variable est le même que celui dans la feuille "Extraction"
                        If nom_variable_Tdc = nom_variable_E Then
                        
                            'Si la condition du dessus est validé alors on renseigne la valeur de la variable dans le champs "Valeur_observée" de la feuille "Test_des_conditions"
                            f_Tdc.Cells(k, 3).Value = valeur_variable_E
                            
                        End If
                        
                    Next k
            
                Next j
                
                    '===============================
                    ' Boucle sur chaque code valeur
                    '===============================
                
                'On boucle pour chaque code_valeur
                For l = 2 To num_der_col_Vc Step 1
                
                    'On récupère le nom du code_valeur
                    nom_code_valeur = f_Vc.Cells(1, l).Value
                    
                    'On vérifie si l'étudiant est éligible au comptage
                    If Test_des_conditions.toutes_conditions_validees(nom_code_valeur) = True Then
                    
                        'Si l'étudiant est éligible on regarde si la variable est le résultat d'un comptage ou d'un calcul agrégé
                        If Test_des_conditions.est_calcul_agrege(nom_code_valeur) = True Then
                        
                            'Calcul agrégé : On récupère la valeur à insérer
                            valeur_num_obs = Test_des_conditions.valeur_obs_calcul_agrege(nom_code_valeur)
                            
                            '                On stocke les valeurs dans un tableau temporaire
                            Call Valeurs_calculées.alimente_tableau_annexe_Vc(nom_code_valeur, valeur_num_obs)
                            
                        Else
                        
                            'Comptage : On incrémente la bonne cellule du tableau de la feuille "Valeurs_calculées"
                            Call Valeurs_calculées.incremente_tableau_Vc(intitule_modalite_parcours, nom_code_valeur)
                            
                        End If
                        
                    End If
                
                Next l
                
            Next i
            
            'On récupère le numéro de ligne correspondant à l'endroit où l'on va retrouver les différents code_valeur soumis au calcul d'agrégation
            ligne_code_valeur_agrege = Tableau.num_der_lignes("Valeurs_calculées") + 3
            
                '=================================
                ' Boucle sur chaque calcul agrégé
                '=================================
            
            'On boucle pour chaque code_valeur_agrégé
            For m = 2 To 100 Step 1
            
                'On test s'il y a au moins un code valeur agrégé
                If f_Vc.Cells(ligne_code_valeur_agrege, m).Value <> "" Then
                
                    'On test s'il y a au moins une valeur numérique associé au code valeur
                    If f_Vc.Cells(ligne_code_valeur_agrege + 1, m).Value <> "" Then
                    
                        'On récupère le nom du code valeur
                        nom_code_valeur = f_Vc.Cells(ligne_code_valeur_agrege, m).Value
                        
                        'On identifie et construit la plage de donnée qui va nous permettre d'effectuer le calcul de la statistique
                        plage = Valeurs_calculées.renvoie_plage_de_donnees(nom_code_valeur)
                        
                        'On remplace les valeurs nulles par "" pour ne pas les prendre en compte lors du calcul
                        f_Vc.Range(plage).Replace What:="-99", Replacement:="", LookAt:=xlPart, _
                            SearchOrder:=xlByRows, MatchCase:=False, SearchFormat:=False, _
                            ReplaceFormat:=False
                        
                        'On rècupère le type de statistique à effectuer
                        statistique = f_Vc.Cells(ligne_code_valeur_agrege - 1, m).Value
                        
                        'On calcule la valeur de la statistique
                        valeur_stat = Valeurs_calculées.calcul_agrege(plage, statistique)
                        
                        'On entre la valeur dans la bonne cellule du tableau de la feuille "Valeurs_Calculées"
                        Call Valeurs_calculées.incremente_tableau_Vc(intitule_modalite_parcours, nom_code_valeur, valeur_stat)
                        
                    End If
                    
                Else
                
                    Exit For
                    
                End If
            
            Next m
            'On supprime le contenu des cellules ayant permies de réaliser des calculs agrégés
            f_Vc.Range("B68:Z680").ClearContents
            
            'On supprime le tableau présent sur la feuille "Extraction"
            Call Tableau.nettoie_integralement("Extraction", "A1")
            
        Next h
            
    End If
    
    f_R.Range("L23").Value = Time
    
    'On récupère le nom du chemin qui pointe vers le dossier où l'utilisateur désire enregistré ces fiches
    chemin = f_F.Range("AU2").Value
    
    Application.Calculation = xlCalculationAutomatic
    
        '============================
        ' Boucle sur chaque parcours
        '============================
    
    For h = 1 To 50 Step 1 'nb_total_parcours
    
        'On test si la fiche est publiable
        If Valeurs_calculées.est_parcours_avec_X_repondants_ou_moins(h + 1) = False Or _
            (Valeurs_calculées.est_parcours_avec_X_repondants_ou_moins(h + 1) = True And _
             acceptation_petits_effectifs = True) Then
    
                 intitule_modalite_parcours = Mid(f_Vc.Cells(h + 1, 1).Value, 5)
                 intitule_modalite_champs = Mid(f_Vc.Cells(h + 1, 1).Value, 1, 2)
                 
                 If intitule_modalite_champs = "AL" Then
                    intitule_modalite_champs = "ALL-SHS"
                 ElseIf intitule_modalite_champs = "DE" Then
                    intitule_modalite_champs = "DEG"
                 ElseIf intitule_modalite_champs = "Sa" Then
                    intitule_modalite_champs = "Santé-STAPS"
                 ElseIf intitule_modalite_champs = "Sc" Then
                    intitule_modalite_champs = "Sciences"
                 End If
                 
                 f_F.Range("AQ9").Value = intitule_modalite_parcours
                 f_F.Range("AQ7").Value = intitule_modalite_champs
                 
                     '=======================================
                     ' Boucle sur chaque code valeur calculé
                     '=======================================
                
                 For i = 1 To num_der_col_Vc - 1 Step 1
                 
                     'If i <> num_der_col_Vc Then
                 
                         nom_code_valeur = f_Vc.Cells(1, i + 1).Value
                         
                         valeur_variable_E = f_Vc.Cells(h + 1, i + 1).Value
                     
                             '==========================================
                             ' Boucle sur chaque code valeur à afficher
                             '==========================================
                     
                         For j = 11 To 296 Step 1
                         
                            For k = 42 To 59 Step 17
                         
                                If f_F.Cells(j, k).Value = nom_code_valeur And valeur_variable_E <> "" Then
                                    
                                    f_F.Cells(j, k + 1).Value = valeur_variable_E
                                    
                                    Exit For
                                    
                                ElseIf f_F.Cells(j, k).Value = nom_code_valeur And valeur_variable_E = "" And Right(f_F.Cells(j, k + 2).Value, 6) <> "groupe" Then
                                    
                                    f_F.Cells(j, k + 1).Value = 0
                                    
                                    Exit For
                            
                                End If
                            
                            Next k
                         
                         Next j
                     
                     'End If
                
                 Next i
                 
                 'Procédure qui enregistre la fiche
                 Call Fiche.Save_as_format_pdf("Fiche", _
                                                "B2:AK261", _
                                                chemin, _
                                                intitule_modalite_champs & "_" & intitule_modalite_parcours)

        End If
       
    Next h
    
    Application.ScreenUpdating = True
    Application.DisplayStatusBar = True
    
    'On informe l'utilisateur que les fiches ont bien été produite
    MsgBox ("Les fiches ont été produites au format PDF avec succès.")
       
    Set f_R = Nothing
    Set f_Ds = Nothing
    Set f_E = Nothing
    Set f_E2 = Nothing
    Set f_Vc = Nothing
    Set f_Tdc = Nothing
    Set f_F = Nothing
End Sub

__C4__

'Extraction_ciblee

Public Sub extrait_donnees(ByVal nom_feuille_source As String, _
                           ByVal nom_feuille_arrive As String, _
                           ByVal nom_lycée As String)
                           
    Dim f1 As Worksheet
    Dim f2 As Worksheet
    
    Dim i As Integer
    Dim num_der_individu As Integer
    Dim ligne_first_occ As Integer
    Dim ligne_last_occ As Integer
    
    Dim plage As String
    
    Set f1 = Worksheets(nom_feuille_source)
    Set f2 = Worksheets(nom_feuille_arrive)
                           
    num_der_individu = f1.Range("B5000").End(xlUp).Row
                           
    For i = 2 To num_der_individu Step 1
        If f1.Cells(i, 2).Value = nom_lycée Then
            ligne_first_occ = i
            Exit For
        End If
    Next i
    
    For i = num_der_individu To 2 Step -1
        If f1.Cells(i, 2).Value = nom_lycée Then
            ligne_last_occ = i
            Exit For
        End If
    Next i
    
    plage = "C" & CStr(ligne_first_occ) & ":C" & ligne_last_occ
    f1.Range(plage).Copy
    f2.Range("B6").PasteSpecial xlPasteValues
    
    plage = "D" & CStr(ligne_first_occ) & ":D" & ligne_last_occ
    f1.Range(plage).Copy
    f2.Range("D6").PasteSpecial xlPasteValues
    
    plage = "E" & CStr(ligne_first_occ) & ":I" & ligne_last_occ
    f1.Range(plage).Copy
    f2.Range("F6").PasteSpecial xlPasteValues
                           
    Set f1 = Nothing
    Set f2 = Nothing
End Sub

'Fusion_cellules

Public Sub fusion_verticale(ByVal nom_feuille As String, _
                            ByVal nom_col As String, _
                            ByVal start As Integer, _
                            ByVal fin As Integer)
    If start >= 1 And fin >= 2 Then
        If start < fin Then
            Application.DisplayAlerts = False
            Worksheets(nom_feuille).Range(nom_col & CStr(start) & ":" & nom_col & CStr(fin)).Merge
            Application.DisplayAlerts = True1
        End If
    End If
End Sub

Public Sub fusion_cellules_annee(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim vecteur_0 As Variant
    Dim vecteur_1 As Variant
    
    Dim start, fin As Integer
    Dim compteur As Integer
    Dim i As Integer
    
    Set f = Worksheets(nom_feuille)
    
    Application.ScreenUpdating = False
    
    start = 0
    fin = 0
    compteur = 0
    
    For i = 7 To f.Range("F6").End(xlDown).Row Step 1
        Set vecteur_0 = f.Range("B" & CStr(i - 1) & ":F" & CStr(i - 1))
        Set vecteur_1 = f.Range("B" & CStr(i) & ":F" & CStr(i))
        If vecteur_0(1, 1) = vecteur_1(1, 1) _
            And vecteur_0(1, 3) = vecteur_1(1, 3) _
            And vecteur_0(1, 5) = vecteur_1(1, 5) Then
                If compteur = 0 Then
                    start = i - 1
                    fin = i
                    compteur = compteur + 1
                Else
                    compteur = compteur + 1
                    fin = i
                End If
        Else
            If start + fin > 0 Then
                Call fusion_verticale(nom_feuille, "F", start, fin)
                start = -1000
                compteur = 0
            End If
        End If
    Next i
    Application.ScreenUpdating = True
    
    Set f = Nothing
End Sub

Public Sub fusion_cellules_formation(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim vecteur_0 As Variant
    Dim vecteur_1 As Variant
    
    Dim start, fin As Integer
    Dim compteur As Integer
    Dim i As Integer
    Dim somme As Integer
    
    Set f = Worksheets(nom_feuille)
    
    Application.ScreenUpdating = False
    
    start = 0
    fin = 0
    compteur = 0
    
    For i = 7 To f.Range("I6").End(xlDown).Row + 1 Step 1
        Set vecteur_0 = f.Range("B" & CStr(i - 1) & ":F" & CStr(i - 1))
        Set vecteur_1 = f.Range("B" & CStr(i) & ":F" & CStr(i))
        If vecteur_0(1, 1) = vecteur_1(1, 1) _
            And vecteur_0(1, 3) = vecteur_1(1, 3) _
            And vecteur_0(1, 5) = vecteur_1(1, 5) _
            And vecteur_0(1, 7) = vecteur_1(1, 7) Then
                If compteur = 0 Then
                    start = i - 1
                    fin = i
                    compteur = compteur + 1
                Else
                    compteur = compteur + 1
                    fin = i
                End If
        Else
            If start + fin > 0 Then
                Call fusion_verticale(nom_feuille, "H", start, fin)
                somme = Application.Sum(f.Range("G" & CStr(start) & ":G" & CStr(fin)))
                f.Range("G" & CStr(start) & ":G" & CStr(fin)).ClearContents
                f.Range("G" & CStr(fin)).Value = somme
                Call fusion_verticale(nom_feuille, "G", start, fin)
                start = -1000
                compteur = 0
            End If
        End If
    Next i
    Application.ScreenUpdating = True
    
    Set f = Nothing
End Sub

Public Sub fusion_avec_saut_de_page(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim ligne_active As Integer
    Dim prochaine_ligne_nv As Integer
    
    Application.ScreenUpdating = False
    
    Set f = Worksheets(nom_feuille)
    
    ligne_active = f.Range("I2000").End(xlUp).Row
    
    Do While ligne_active >= 6
        If f.Cells(ligne_active, 2).Value <> "" Then
            ligne_active = ligne_active - 1
        Else
            prochaine_ligne_nv = f.Cells(ligne_active, 2).End(xlUp).Row
            Call fusion_verticale(nom_feuille, "B", prochaine_ligne_nv, ligne_active)
            'If Right(f.Cells(prochaine_ligne_nv, 2).value, 7) <> "(suite)" Then
                'ligne_active = prochaine_ligne_nv - 2
            'Else
                ligne_active = prochaine_ligne_nv - 1
            'End If
        End If
    Loop
    
    ligne_active = f.Range("I2000").End(xlUp).Row
    
    Do While ligne_active >= 6
        If f.Cells(ligne_active, 4).Value <> "" Then
            ligne_active = ligne_active - 1
        Else
            prochaine_ligne_nv = f.Cells(ligne_active, 4).End(xlUp).Row
            Call fusion_verticale(nom_feuille, "D", prochaine_ligne_nv, ligne_active)
            'If Right(f.Cells(prochaine_ligne_nv, 4).value, 7) <> "(suite)" Then
                'ligne_active = prochaine_ligne_nv - 2
            'Else
                ligne_active = prochaine_ligne_nv - 1
            'End If
        End If
    Loop
    
    ligne_active = f.Range("I2000").End(xlUp).Row
    
    Do While ligne_active >= 6
        If f.Cells(ligne_active, 6).Value <> "" Then
            ligne_active = ligne_active - 1
        Else
            prochaine_ligne_nv = f.Cells(ligne_active, 6).End(xlUp).Row
            Call fusion_verticale(nom_feuille, "F", prochaine_ligne_nv, ligne_active)
            'If Right(f.Cells(prochaine_ligne_nv, 6).value, 7) <> "(suite)" Then
                'ligne_active = prochaine_ligne_nv - 2
            'Else
                ligne_active = prochaine_ligne_nv - 1
            'End If
        End If
    Loop
    
    Set f = Nothing
    
    Application.ScreenUpdating = True
End Sub

Public Sub defusion_des_cellules(ByVal nom_feuille As String)
    Dim f As Worksheet
    Dim der_ligne As Integer
    
    Application.ScreenUpdating = False
    
    Set f = Worksheets(nom_feuille)
    
    der_ligne = f.Range("I2000").End(xlUp).Row
    
    f.Range("B6:B" & CStr(der_ligne)).UnMerge
    f.Range("D6:D" & CStr(der_ligne)).UnMerge
    f.Range("F6:F" & CStr(der_ligne)).UnMerge
    
    Set f = Nothing
    
    Application.ScreenUpdating = True
End Sub

'Procédures principales

'Procédure qui construit la forme primitive de la fiche 1
Public Sub mettre_en_forme_fiche_1_partie_1()
    Application.ScreenUpdating = False
    Dim nom_etab As String
    nom_etab = Worksheets("Paramétrage").Range("E3").Value
    Call Extraction_ciblee.extrait_donnees("Base individus", "Faidherbe", nom_etab)
    Call Regroupement_doublons.Regruper_memes_individus("Faidherbe")
    Call Fusion_cellules.fusion_cellules_formation("Faidherbe")
    Call Modification_texte.tranformation_texte_3("Faidherbe")
    Call Modification_texte.tranformation_texte_2("Faidherbe")
    Call Modification_texte.tranformation_texte_1("Faidherbe")
    Application.ScreenUpdating = True
End Sub

'Procédure qui tient compte des sauts de page mis à la main
Public Sub mettre_en_forme_fiche_1_partie_2a()
    Application.ScreenUpdating = False
    Call rediger_suites_type_mention_annee("Faidherbe")
    Call fusion_avec_saut_de_page("Faidherbe")
    Call lignes_pourpres_h_v3("Faidherbe")
    Call appliquer_bordures_simples("Faidherbe")
    Application.ScreenUpdating = True
End Sub

'Procédure qui tient compte des sauts de page mis à la main
Public Sub mettre_en_forme_fiche_1_partie_2b()
    Application.ScreenUpdating = False
    Call defusion_des_cellules("Faidherbe")
    Call retirer_les_suites("Faidherbe")
    Call suppression_lignes_pourpres("Faidherbe")
    Call enlever_bordures_simples("Faidherbe")
    Application.ScreenUpdating = True
End Sub

'Procédure qui sauvegarde le document
Public Sub mettre_en_forme_fiche_1_partie_3()
    Dim nom_etab, nom_dossier As String
    nom_dossier = "Y:\odif\ODIF_Partage\Demandes de statistiques et d'enquêtes\Services internes\SUAIO\Demain l'université\20172018\Fiches\Préparation"
    nom_etab = "Fiche1_" & Worksheets("Paramétrage").Range("E3").Value
    Application.ScreenUpdating = False
    Call mise_en_forme_final
    Worksheets("Faidherbe").Range("C6:C300,E6:E300").Interior.Color = RGB(174, 37, 115)
    Application.ScreenUpdating = True
    MsgBox "Observez la fiche et entrez 'Oui' dans la cellule M1"
    Do While Worksheets("Faidherbe").Range("M1").Value = "Non"
        DoEvents
    Loop
    Application.ScreenUpdating = False
    Worksheets("Faidherbe").Range("M1").Value = "Non"
    If MsgBox("Validez-vous cette fiche ?", vbYesNo) = vbYes Then
        Call sauvegarder_xlsm(nom_dossier, nom_etab)
        Call reinitialise_feuille("Faidherbe")
    Else
        Exit Sub
    End If
    Application.ScreenUpdating = True
End Sub

'Mise en forme

Public Sub lignes_pourpres_h1(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim vecteur_0 As String
    Dim vecteur_1 As String
    
    Dim i As Integer
    
    Set f = Worksheets(nom_feuille)
    
    For i = f.Range("I2000").End(xlUp).Row - 1 To 6 Step -1
        vecteur_0 = f.Cells(i + 1, 4).Value
        vecteur_1 = f.Cells(i, 4).Value
        If vecteur_0 <> vecteur_1 Then
            f.Rows(i + 1).Insert shift:=xlDown
            f.Rows(i + 1).RowHeight = 3
            f.Range("D" & CStr(i + 1) & ":J" & CStr(i + 1)).Interior.Color = RGB(174, 37, 115)
        End If
    Next i
    
    Set f = Nothing
End Sub

Public Sub lignes_pourpres_h2(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim vecteur_0 As String
    Dim vecteur_1 As String
    
    Dim i As Integer
    
    Set f = Worksheets(nom_feuille)
    
    For i = f.Range("I2000").End(xlUp).Row - 1 To 6 Step -1
        vecteur_0 = f.Cells(i + 1, 2).Value
        vecteur_1 = f.Cells(i, 2).Value
        If vecteur_0 <> vecteur_1 Then
            If vecteur_0 = "" Or vecteur_1 = "" Then
                If vecteur_0 = "" Then
                    f.Range("B" & CStr(i + 1)).Interior.Color = RGB(174, 37, 115)
                End If
            Else
                f.Rows(i + 1).Insert shift:=xlDown
                f.Rows(i + 1).RowHeight = 3
                f.Range("B" & CStr(i + 1) & ":J" & CStr(i + 1)).Interior.Color = RGB(174, 37, 115)
            End If
        End If
    Next i
    
    Set f = Nothing
End Sub



Public Sub lignes_pourpres_h1_v2(ByVal nom_feuille As String)

    Dim f As Worksheet
    
    Dim vecteur As String
    
    Dim i As Integer
    
    Set f = Worksheets(nom_feuille)
    
    For i = f.Range("I2000").End(xlUp).Row To 7 Step -1
        vecteur = f.Cells(i, 4).Value
        If vecteur <> "" Then
            f.Rows(i).Insert shift:=xlDown
            f.Rows(i).RowHeight = 3
            f.Range("D" & CStr(i) & ":J" & CStr(i)).Interior.Color = RGB(174, 37, 115)
        End If
    Next i
End Sub

Public Sub lignes_pourpres_h2_v2(ByVal nom_feuille As String)

    Dim f As Worksheet
    
    Dim vecteur As String
    
    Dim i As Integer
    
    Set f = Worksheets(nom_feuille)
    
    For i = f.Range("I2000").End(xlUp).Row To 7 Step -1
        vecteur = f.Cells(i, 2).Value
        If vecteur <> "" Then
            f.Rows(i).Insert shift:=xlDown
            f.Rows(i).RowHeight = 3
            f.Range("B" & CStr(i)).Interior.Color = RGB(174, 37, 115)
        End If
    Next i
End Sub

Public Sub lignes_pourpres_h_v3(ByVal nom_feuille As String)

    Dim f As Worksheet
    
    Dim vecteur As String
    Dim gauche As Boolean
    Dim i As Integer
    Dim compteur As Integer
    
    Set f = Worksheets(nom_feuille)
    
    compteur = 0
    
    For i = f.Range("I2000").End(xlUp).Row To 7 Step -1
        vecteur = f.Cells(i, 4).Value
        If vecteur <> "" And Right(vecteur, 7) <> "(suite)" Then
            If f.Cells(i, 2).Value <> "" Then
                gauche = True
            Else
                gauche = False
            End If
            
            f.Rows(i).Insert shift:=xlDown
            f.Rows(i).RowHeight = 3
            
            If gauche = False Then
                f.Range("D" & CStr(i) & ":J" & CStr(i)).Interior.Color = RGB(174, 37, 115)
            Else
                f.Range("B" & CStr(i) & ":J" & CStr(i)).Interior.Color = RGB(174, 37, 115)
            End If
            
            compteur = compteur + 1
            
            Worksheets("Paramétrage").Range("C200").End(xlUp).Offset(1, 0).Value = i
            
        End If
    Next i
    
    For i = 1 To compteur Step 1
        Worksheets("Paramétrage").Range("C3").Offset(i - 1, 0).Value = Worksheets("Paramétrage").Range("C3").Offset(i - 1, 0).Value + compteur - i
    Next i
End Sub

Public Sub appliquer_bordures_simples(ByVal nom_feuille As String)
    Dim p As Range
    Dim num_der_ligne As Integer
    Dim plage As String
    
    num_der_ligne = Worksheets(nom_feuille).Range("I2000").End(xlUp).Row
    plage = "B6:B" & CStr(num_der_ligne) & ",D6:D" & CStr(num_der_ligne) & ",F6:J" & CStr(num_der_ligne)
    
    Set p = Worksheets(nom_feuille).Range(plage)
    
    With p
        .Borders(xlEdgeLeft).LineStyle = xlContinuous
        .Borders(xlEdgeTop).LineStyle = xlContinuous
        .Borders(xlEdgeBottom).LineStyle = xlContinuous
        .Borders(xlEdgeRight).LineStyle = xlContinuous
        .Borders(xlInsideVertical).LineStyle = xlContinuous
        .Borders(xlInsideHorizontal).LineStyle = xlContinuous
    End With
    
    Set p = Nothing
End Sub



Public Sub enlever_bordures_simples(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Set f = Worksheets(nom_feuille)
    
    With f.Range("B6:B300,D6:D300,F6:F300")
        .Borders(xlEdgeLeft).LineStyle = xlNone
        .Borders(xlEdgeTop).LineStyle = xlNone
        .Borders(xlEdgeBottom).LineStyle = xlNone
        .Borders(xlEdgeRight).LineStyle = xlNone
        .Borders(xlInsideVertical).LineStyle = xlNone
        .Borders(xlInsideHorizontal).LineStyle = xlNone
    End With

    Set f = Nothing
End Sub

Public Sub mise_en_forme_final()
    Dim f As Worksheet
    Dim der_ligne_nv As Integer
    Dim plage As String
    
    Set f = Worksheets("Faidherbe")
    
    der_ligne_nv = f.Range("I2000").End(xlUp).Row
    chaine = "B6:B" & CStr(der_ligne_nv) & ",D6:D" & CStr(der_ligne_nv) & ",F6:F" & CStr(der_ligne_nv) & ",G6:G" & CStr(der_ligne_nv)
    
    With f.Range(chaine)
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .WrapText = True
    End With
    
    chaine = "H6:H" & CStr(der_ligne_nv) & ",I6:I" & CStr(der_ligne_nv)
    
    With f.Range(chaine)
        .HorizontalAlignment = xlLeft
        .VerticalAlignment = xlCenter
        .WrapText = False
    End With
    
    chaine = "J6:J" & CStr(der_ligne_nv)
    
    f.Range(chaine).HorizontalAlignment = xlCenter
    
    Set f = Nothing
End Sub

'Modification_texte

Public Sub tranformation_texte_1(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim vecteur_0 As Variant
    Dim vecteur_1 As Variant
    
    Dim start, fin As Integer
    Dim compteur As Integer
    Dim i As Integer
    Dim der_obs As Integer
    
    Set f = Worksheets(nom_feuille)
    
    Application.ScreenUpdating = False
    
    i = 6
    compteur = 1
    der_obs = f.Range("B2000").End(xlUp).Row
    
    Do While i <> der_obs + 1
        vecteur_0 = f.Cells(i, 2).Value
        vecteur_1 = f.Cells(i + 1, 2).Value
        If vecteur_0 = vecteur_1 _
            And vecteur_0 <> "" Then
                If compteur = 1 Then
                    start = i
                    fin = i + 1
                Else
                    fin = i + 1
                End If
                compteur = compteur + 1
        Else
            If compteur = 1 And i <> der_obs + 1 Then
                f.Cells(i, 2).Value = "1 bachelier " & vecteur_0
            Else
                f.Range("B" & CStr(start)).Value = CStr(Application.Sum(f.Range("G" & CStr(start) & ":G" & CStr(fin)))) & " bacheliers " & vecteur_0
                If start + 1 < fin Then
                    f.Range("B" & CStr(start + 1) & ":B" & CStr(fin)).Value = ""
                Else
                    f.Range("B" & CStr(start + 1)).Value = ""
                End If
            End If
            compteur = 1
        End If
        i = i + 1
    Loop
    
    Application.ScreenUpdating = True
    
    Set f = Nothing
End Sub

Public Sub tranformation_texte_2(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim vecteur_0 As Variant
    Dim vecteur_1 As Variant
    
    Dim start, fin As Integer
    Dim compteur As Integer
    Dim i As Integer
    Dim der_obs As Integer
    
    Set f = Worksheets(nom_feuille)
    
    Application.ScreenUpdating = False
    
    i = 7
    compteur = 1
    der_obs = f.Range("D2000").End(xlUp).Row
    
    Do While i <> der_obs + 2
        Set vecteur_0 = f.Range("B" & CStr(i - 1) & ":D" & CStr(i - 1))
        Set vecteur_1 = f.Range("B" & CStr(i) & ":D" & CStr(i))
        If vecteur_0(1, 1) = vecteur_1(1, 1) _
            And vecteur_0(1, 3) = vecteur_1(1, 3) _
            And vecteur_0(1, 3) <> "" Then
                If compteur = 1 Then
                    start = i - 1
                    fin = i
                Else
                    fin = i
                End If
                compteur = compteur + 1
        Else
            If compteur = 1 And i <> der_obs + 2 Then
                f.Cells(i - 1, 4).Value = CStr(f.Cells(i - 1, 7).Value) & " " & vecteur_0(1, 3)
            Else
                f.Range("D" & CStr(start)).Value = CStr(Application.Sum(f.Range("G" & CStr(start) & ":G" & CStr(fin)))) & " " & vecteur_0(1, 3)
                If start + 1 < fin Then
                    f.Range("D" & CStr(start + 1) & ":D" & CStr(fin)).Value = ""
                Else
                    f.Range("D" & CStr(start + 1)).Value = ""
                End If
            End If
            compteur = 1
        End If
        i = i + 1
    Loop
    
    Application.ScreenUpdating = True
    
    Set f = Nothing
End Sub

Public Sub tranformation_texte_3(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim vecteur_0 As Variant
    Dim vecteur_1 As Variant
    
    Dim start, fin As Integer
    Dim compteur As Integer
    Dim i As Integer
    Dim der_obs As Integer
    
    Set f = Worksheets(nom_feuille)
    
    Application.ScreenUpdating = False
    
    i = 7
    compteur = 1
    der_obs = f.Range("F2000").End(xlUp).Row
    
    Do While i <> der_obs + 2
        Set vecteur_0 = f.Range("B" & CStr(i - 1) & ":F" & CStr(i - 1))
        Set vecteur_1 = f.Range("B" & CStr(i) & ":F" & CStr(i))
        If vecteur_0(1, 1) = vecteur_1(1, 1) _
            And vecteur_0(1, 3) = vecteur_1(1, 3) _
            And vecteur_0(1, 5) = vecteur_1(1, 5) _
            And vecteur_0(1, 5) <> "" Then
                If compteur = 1 Then
                    start = i - 1
                    fin = i
                Else
                    fin = i
                End If
                compteur = compteur + 1
        Else
            If compteur > 1 And i <> der_obs + 2 Then
                If start + 1 < fin Then
                    f.Range("F" & CStr(start + 1) & ":F" & CStr(fin)).Value = ""
                Else
                    f.Range("F" & CStr(start + 1)).Value = ""
                End If
            End If
            compteur = 1
        End If
        i = i + 1
    Loop
    
    Application.ScreenUpdating = True
    
    Set f = Nothing
End Sub


Public Function description_type_bac(ByVal nom_feuille As String, _
                                     ByVal num_ligne_debut As Integer, _
                                     ByVal num_ligne_fin As Integer, _
                                     ByVal nom_lycée As String) As String
    Dim f As Worksheet
    
    Dim resultat As String
    Dim i, j As Integer
    Dim ligne_focus As Integer
    Dim total_bac As Integer
    Dim compteur As Integer
    Dim type_bac As String
    Dim nb_type_bac As Integer
    Dim ind_reprise As Integer
    Dim prem_occ As Integer
    Dim last_occ As Integer
    
    Set f = Worksheets(nom_feuille)
    
    Application.Volatile
    
    resultat = "("
    compteur = 0
    
    'Recherche du numéro de la ligne correspondant au nom du lycée
    For i = num_ligne_debut To num_ligne_fin Step 1
        If f.Cells(i, 2).Value = nom_lycée Then
            ligne_focus = i
            Exit For
        End If
    Next i
    
    'On ajoute le total de bacheliers dans le résultat
    total_bac = f.Cells(ligne_focus, 8).Value
    resultat = resultat + CStr(total_bac) + " néobacheliers dont "
    
    'On compte le nombre de type de bac non nul
    For j = 3 To 7 Step 1
        If f.Cells(ligne_focus, j).Value <> 0 Then
            compteur = compteur + 1
        End If
    Next j
    
    If compteur = 1 Then
        For j = 3 To 7 Step 1
            If f.Cells(ligne_focus, j).Value <> 0 Then
                type_bac = Mid(f.Cells(2626, j).Value, 6)
                nb_type_bac = f.Cells(ligne_focus, j).Value
                Exit For
            End If
        Next j
        resultat = resultat + CStr(nb_type_bac) + " " + type_bac + ")"
        
    ElseIf compteur = 2 Then
        For j = 3 To 7 Step 1
            If f.Cells(ligne_focus, j).Value <> 0 Then
                ind_reprise = j
                type_bac = Mid(f.Cells(2626, j).Value, 6)
                nb_type_bac = f.Cells(ligne_focus, j).Value
                Exit For
            End If
        Next j
        resultat = resultat + CStr(nb_type_bac) + " " + type_bac + " et "
        
        For j = ind_reprise + 1 To 7 Step 1
            If f.Cells(ligne_focus, j).Value <> 0 Then
                ind_reprise = j
                type_bac = Mid(f.Cells(2626, j).Value, 6)
                nb_type_bac = f.Cells(ligne_focus, j).Value
                Exit For
            End If
        Next j
        resultat = resultat + CStr(nb_type_bac) + " " + type_bac + ")"
        
    Else
        prem_occ = indice_est_first(nom_feuille, ligne_focus)
        last_occ = indice_est_last(nom_feuille, ligne_focus)
        For j = 3 To 7 Step 1
            If f.Cells(ligne_focus, j).Value <> 0 Then
                type_bac = Mid(f.Cells(2626, j).Value, 6)
                nb_type_bac = f.Cells(ligne_focus, j).Value
                If j = prem_occ Then
                    resultat = resultat + CStr(nb_type_bac) + " " + type_bac
                ElseIf j = last_occ Then
                    resultat = resultat + " et " + CStr(nb_type_bac) + " " + type_bac + ")"
                Else
                    resultat = resultat + ", " + CStr(nb_type_bac) + " " + type_bac
                End If
            End If
        Next j
    End If
    description_type_bac = resultat
    
    Set f = Nothing
End Function

'Positionnement

Public Function indice_est_first(ByVal nom_feuille As String, _
                                 ByVal num_ligne As Integer) As Integer
    
    Dim f As Worksheet
    Dim i As Integer
    
    Set f = Worksheets(nom_feuille)
    
    For i = 3 To 7 Step 1
        If f.Cells(num_ligne, i).Value <> 0 Then
            indice_est_first = i
            Exit For
        End If
    Next i
        
    Set f = Nothing
End Function

Public Function indice_est_last(ByVal nom_feuille As String, _
                                ByVal num_ligne As Integer) As Integer
    
    Dim f As Worksheet
    Dim i As Integer
    
    Set f = Worksheets(nom_feuille)
    
    For i = 7 To 3 Step -1
        If f.Cells(num_ligne, i).Value <> 0 Then
            indice_est_last = i
            Exit For
        End If
    Next i
        
    Set f = Nothing
End Function

'Recodage

Public Function modif_type_bac(ByVal type_bac As String) As String
    If type_bac = "S-Scientifique" Then
        modif_type_bac = "S"
    ElseIf type_bac = "ES-Economique et social" Then
        modif_type_bac = "ES"
    ElseIf type_bac = "L-Littéraire" Then
        modif_type_bac = "L"
    ElseIf Left(type_bac, 1) = "S" Then
        modif_type_bac = "Techno"
    ElseIf Left(type_bac, 3) = "002" Then
        modif_type_bac = "Pro"
    ElseIf Left(type_bac, 3) = "Bac" Then
        modif_type_bac = "Int"
    Else
        modif_type_bac = "Autre"
    End If
End Function

Public Function ordre_type_bac(ByVal type_bac As String) As Integer
    If type_bac = "S" Then
        ordre_type_bac = 4
    ElseIf type_bac = "ES" Then
        ordre_type_bac = 2
    ElseIf type_bac = "L" Then
        ordre_type_bac = 3
    ElseIf type_bac = "Techno" Then
        ordre_type_bac = 5
    ElseIf type_bac = "Pro" Then
        ordre_type_bac = 6
    ElseIf type_bac = "Int" Then
        ordre_type_bac = 1
    Else
        ordre_type_bac = 7
    End If
End Function

'Recuperation_RNE

Public Function recup_code_rne(ByVal nom_etab As String) As String
    Dim f As Worksheet
    Dim last_ligne As Integer
    Dim i As Integer
    
    Set f = Worksheets("RNE")
    
    last_ligne = Worksheets("RNE").Range("B100").End(xlUp).Row
    recup_code_rne = "RNE : "
    
    For i = 2 To last_ligne Step 1
        If f.Cells(i, 2).Value = nom_etab Then
            If f.Cells(i, 2).Value = "Lycée César Baggio (Lille)" _
                Or f.Cells(i, 2).Value = "Lycée des Flandres (Hazebrouck)" Then
                    recup_code_rne = recup_code_rne & f.Cells(i, 3).Value & " et " & f.Cells(i + 1, 3).Value
            Else
                recup_code_rne = recup_code_rne & f.Cells(i, 3).Value
            End If
            Exit For
        End If
    Next i
    
    Set f = Nothing
End Function

'Redaction_des_suites

Public Sub rediger_suites_type_mention_annee(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim tab_sdp() As Integer
    
    Dim i, j As Integer
    Dim taille_tab_sdp As Integer
    
    Dim valeur_pere As Variant
    
    Application.ScreenUpdating = False
    
    Set f = Worksheets(nom_feuille)
    
    taille_tab_sdp = nb_sauts_page(nom_feuille) - 1
    
    ReDim tab_sdp(taille_tab_sdp)
    
    For i = LBound(tab_sdp, 1) To UBound(tab_sdp, 1) Step 1
        tab_sdp(i) = get_num_ligne_debut_de_page(nom_feuille, i + 1)
    Next i
    
    For i = 2 To 6 Step 2
        For j = 1 To UBound(tab_sdp, 1) Step 1
            If f.Cells(tab_sdp(j), i).Value = "" Then
                valeur_pere = f.Cells(tab_sdp(j), i).End(xlUp).Value
                If Right(CStr(valeur_pere), 7) <> "(suite)" Then
                    f.Cells(tab_sdp(j), i).Value = CStr(valeur_pere) & " (suite)"
                Else
                    f.Cells(tab_sdp(j), i).Value = CStr(valeur_pere)
                End If
            End If
        Next j
    Next i
    
    Set f = Nothing
    
    Application.ScreenUpdating = True
End Sub

Public Sub retirer_les_suites(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim tab_sdp() As Integer
    
    Dim i, j As Integer
    Dim taille_tab_sdp As Integer
    
    Application.ScreenUpdating = False
    
    Set f = Worksheets(nom_feuille)
    
    taille_tab_sdp = nb_sauts_page(nom_feuille) - 1
    
    ReDim tab_sdp(taille_tab_sdp)
    
    For i = LBound(tab_sdp, 1) To UBound(tab_sdp, 1) Step 1
        tab_sdp(i) = get_num_ligne_debut_de_page(nom_feuille, i + 1)
    Next i
    
    For i = 2 To 6 Step 2
        For j = 1 To UBound(tab_sdp, 1) Step 1
            If Right(f.Cells(tab_sdp(j), i).Value, 7) = "(suite)" Then
                f.Cells(tab_sdp(j), i).Value = ""
            End If
        Next j
    Next i
    
    Set f = Nothing
    
    Application.ScreenUpdating = True
End Sub

'Regroupement_doublons

Public Sub Regruper_memes_individus(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim vecteur_0 As Variant
    Dim vecteur_1 As Variant
    
    Dim start, fin As Integer
    Dim i As Integer
    
    Set f = Worksheets(nom_feuille)
    
    Application.ScreenUpdating = False
    
    start = 0
    fin = 0
    
    For i = f.Range("I6").End(xlDown).Row - 1 To 6 Step -1
        Set vecteur_0 = f.Range("B" & CStr(i + 1) & ":I" & CStr(i + 1))
        Set vecteur_1 = f.Range("B" & CStr(i) & ":I" & CStr(i))
        If vecteur_0(1, 1) = vecteur_1(1, 1) _
            And vecteur_0(1, 3) = vecteur_1(1, 3) _
            And vecteur_0(1, 5) = vecteur_1(1, 5) _
            And vecteur_0(1, 7) = vecteur_1(1, 7) _
            And vecteur_0(1, 8) = vecteur_1(1, 8) Then
                If compteur = 0 Then
                    start = i + 1
                    fin = i
                    compteur = compteur + 1
                Else
                    compteur = compteur + 1
                    fin = i
                End If
        Else
            If start + fin > 0 Then
                If start - fin = 1 Then
                    f.Rows(start).Delete
                Else
                    f.Rows(CStr(start) & ":" & CStr(fin + 1)).Delete
                End If
                
                If vecteur_0(1, 8) = "Non réinscrit à l'UL" Then
                    f.Range("I" & CStr(fin)).Value = CStr(start - fin + 1) & " non réinscrits à l'UL"
                Else
                    f.Range("I" & CStr(fin)).Value = CStr(start - fin + 1) & " en " & f.Range("I" & CStr(fin)).Value
                End If
                
                f.Range("G" & CStr(fin)).Value = start - fin + 1
                
                start = -2000
                compteur = 0
            End If
        End If
    Next i
    Application.ScreenUpdating = True
    
    Set f = Nothing
End Sub

'Reinitialiser

Public Sub reinitialise_feuille(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim i As Integer
    
    Set f = Worksheets(nom_feuille)
    
    Application.ScreenUpdating = False
    
    'Hauteur de ligne à 15
    f.Rows("6:300").RowHeight = 15
    
    'suppression des couleurs de remplissage
    f.Range("B6:J300").Interior.Pattern = xlNone
    
    'suppression des fusions de cellules
    f.Range("B6:H300").UnMerge
    
    'Suppression des bordures
    With f.Range("B6:J300")
        .Borders(xlEdgeLeft).LineStyle = xlNone
        .Borders(xlEdgeTop).LineStyle = xlNone
        .Borders(xlEdgeBottom).LineStyle = xlNone
        .Borders(xlEdgeRight).LineStyle = xlNone
        .Borders(xlInsideVertical).LineStyle = xlNone
        .Borders(xlInsideHorizontal).LineStyle = xlNone
    End With
    
    'Suppression du contenu
    f.Range("B6:J300").ClearContents
    
    'Enlever le retour à la ligne automatique
    f.Range("H6:I300").WrapText = False
    
    'Suppression des numéros de lignes pourpres
    Worksheets("Paramétrage").Range("C3:C32").ClearContents
    
    Application.ScreenUpdating = True
    
    Set f = Nothing
End Sub

Public Sub suppression_lignes_pourpres(ByVal nom_feuille As String)
    Dim f As Worksheet
    
    Dim i As Integer
    Dim num_ligne As Integer
    
    Set f = Worksheets(nom_feuille)
    
    Application.ScreenUpdating = False
    
    For i = 3 To Worksheets("Paramétrage").Range("C200").End(xlUp).Row Step 1
        num_ligne = Worksheets("Paramétrage").Cells(i, 3).Value
        f.Range("A" & CStr(num_ligne)).EntireRow.Delete
    Next i
    
    Worksheets("Paramétrage").Range("C3:C32").ClearContents
    
    Application.ScreenUpdating = True
    
    Set f = Nothing
End Sub

'restr_var

' Fonction qui renvoie le caractère d'une colonne à partir d'un entier
Public Function LettreColonne(NumCol As Integer) As String
    Dim reste, quotient As Long
    
    quotient = Int(NumCol / 26)
    reste = NumCol Mod 26
    If quotient = 0 And reste = 0 Then
        Exit Function
    End If
    ' si la cdc est comprise entre A et Z.
    If quotient = 0 Then
        LettreColonne = Chr(64 + reste)
    Else
        If reste = 0 Then
            quotient = quotient - 1
            If quotient = 0 Then
                LettreColonne = Chr(64 + 26)
            Else
                LettreColonne = Chr(64 + quotient) & Chr(64 + 26)
            End If
        Else
            LettreColonne = Chr(64 + quotient) & Chr(64 + reste)
        End If
    End If
End Function

Public Function compte_nb_cellule_non_vide(ByVal feuille As String, _
                                            ByVal cellule As String) As Integer
    Dim f As Worksheet
    Dim c As Range
    Dim i, compteur As Integer
    
    Set f = Worksheets(feuille)
    Set c = f.Range(cellule)
    
    i = 0
    
    Do While c.Offset(i, 0).Value <> ""
        i = i + 1
    Loop
    
    Set f = Nothing
    Set c = Nothing
    
    compte_nb_cellule_non_vide = i
End Function

'Fonction qui renvoie true si le mot appartient à une liste d'autre mot

Public Function est_dans_la_liste(ByVal mot As String, _
                                    ByVal feuille As String, _
                                    ByVal cellule_start As String, _
                                    ByVal nb_occurence As Integer) As Boolean
    Dim f As Worksheet
    Dim c As Range
    Dim i As Integer
    
    Set f = Worksheets(feuille)
    Set c = f.Range(cellule_start)
    
    est_dans_la_liste = False
    
    For i = 1 To nb_occurence Step 1
        If mot = c.Offset(i - 1, 0).Value Then
            est_dans_la_liste = True
            Exit For
        End If
    Next i
    
    Set f = Nothing
    Set c = Nothing
End Function

'Procédure qui doit supprimer toutes les variables ne faisant pas partis d'une liste prédéfinie

Public Sub restriction_sur_variable(ByVal feuille_source As String, _
                                    ByVal feuille_ref As String, _
                                    ByVal cellule_ref As String)
    Dim f1 As Worksheet
    Dim f2 As Worksheet
    Dim c As Range
    Dim nb_var_nece, i, j As Integer
    Dim lettre As String
    
    Set f1 = Worksheets(feuille_source)
    Set f2 = Worksheets(feuille_ref)
    Set c = f2.Range(cellule_ref)
    
    nb_var_nece = compte_nb_cellule_non_vide(feuille_ref, "A3")
    i = 0
    
    Do While f1.Range("A1").End(xlToRight).Column <> nb_var_nece
        mot = f1.Range("A1").Offset(0, i).Value
        If restr_var.est_dans_la_liste(mot, "Paramétrage", "A3", nb_var_nece) = True Then
            i = i + 1
        Else
            lettre = LettreColonne(f1.Range("A1").Offset(0, i).Column)
            lettre = lettre + ":" + lettre
            f1.Range(lettre).Delete xlShiftToLeft
        End If
    Loop
    
    Set f1 = Nothing
    Set f2 = Nothing
    Set c = Nothing
End Sub

'Saut_de_page

Public Function get_num_ligne_fin_de_page(ByVal nom_feuille As String, _
                                          ByVal num_page As Integer) As Integer
    If num_page > 0 Then
        'Sheets(nom_feuille).Select
        get_num_ligne_fin_de_page = Sheets(nom_feuille).HPageBreaks(num_page).Location.Row - 1
    End If
End Function

Public Function get_num_ligne_debut_de_page(ByVal nom_feuille As String, _
                                            ByVal num_page As Integer) As Integer
    If num_page > 1 Then
        'Sheets(nom_feuille).Select
        get_num_ligne_debut_de_page = Sheets(nom_feuille).HPageBreaks(num_page - 1).Location.Row
    End If
End Function

Public Function nb_sauts_page(ByVal nom_feuille As String) As Integer
    Dim i As Integer
    
    i = 1

    On Error GoTo num_sdp_introuvable
    
    Do While Sheets(nom_feuille).HPageBreaks(i).Location.Column = 2
        'MsgBox "Ligne: " & Sheets(nom_feuille).HPageBreaks(i).Location.Row & " Colonne: " & Sheets(nom_feuille).HPageBreaks(i).Location.Column
        i = i + 1
    Loop
    
num_sdp_introuvable:
nb_sauts_page = i
    
End Function

'Sauvegarder

Public Sub sauvegarder_xlsm(ByVal nom_dossier As String, _
                            ByVal nom_fichier As String)
    ActiveWorkbook.SaveAs Filename:= _
        nom_dossier & "\" & nom_fichier & ".xlsm", _
        FileFormat:=xlOpenXMLWorkbookMacroEnabled, _
        CreateBackup:=False
End Sub