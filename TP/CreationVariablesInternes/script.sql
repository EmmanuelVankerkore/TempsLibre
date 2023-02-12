-- =============================================
-- Author:		Vankerkore Emmanuel
-- Create date: 24/08/2018
-- Description:	Création de nouvelles variables
-- =============================================

-- Déclaration des variables.

declare @titre as int

	/* T_best_mois*/
declare @month_last_date as int
declare @year_last_date as int
declare @mois_debut as int
declare @annee_debut as int
declare @mois_fin as int
declare @annee_fin as int
declare @periode_fin as date
declare @periode_Debut as date

	/* T_RF_dynamique */
declare @dern_ha_moins12 as date

	/* T_Top_panier_moyen_sup */
declare @panier_moyen as real

	/* T_top_ecart_HA_inf_moy */
declare @ha_inac_moy_global as real

	/* T_ecart_inac_inf_moy */
declare @der_trx_cible as date
declare @duree_moy_cible as real
declare @der_trx_PAR as date
declare @duree_moy_PAR as real

-- affectation des valeurs aux variables.

set @titre = 531

-- Suppression des tables temporaires déjà existantes.
 
IF OBJECT_ID('EV_transactions_@titre') IS NOT NULL BEGIN; DROP TABLE EV_transactions_@titre END;
IF OBJECT_ID('EV_matrice_variables_interne_@titre') IS NOT NULL BEGIN; DROP TABLE EV_matrice_variables_interne_@titre END;

	/*T_g_nb_trx*/
IF OBJECT_ID('EV_foyers_min_max_date') IS NOT NULL BEGIN; DROP TABLE EV_foyers_min_max_date END;
IF OBJECT_ID('EV_T_g_nb_trx') IS NOT NULL BEGIN; DROP TABLE EV_T_g_nb_trx END;

	/*T_ecart_first_last*/	
IF OBJECT_ID('EV_T_ecart_first_last') IS NOT NULL BEGIN; DROP TABLE EV_T_ecart_first_last END;

	/*T_best_mois*/
IF OBJECT_ID('EV_periode_analyse') IS NOT NULL BEGIN; DROP TABLE EV_periode_analyse END;
IF OBJECT_ID('EV_transaction_mois_@titre') IS NOT NULL BEGIN; DROP TABLE EV_transaction_mois_@titre END;
IF OBJECT_ID('EV_Table_best_mois') IS NOT NULL BEGIN; DROP TABLE EV_Table_best_mois END;
IF OBJECT_ID('EV_Foyers_best_mois') IS NOT NULL BEGIN; DROP TABLE EV_Foyers_best_mois END;

	/*Top_soldes*/
IF OBJECT_ID('EV_Table_Top_solde_dedup') IS NOT NULL BEGIN; DROP TABLE EV_Table_Top_solde_dedup END;	

	/*T_top_TBC T_top_BC T_top_Nouveaux*/
IF OBJECT_ID('EV_Cible_T_RF_dynamique') IS NOT NULL BEGIN; DROP TABLE EV_Cible_T_RF_dynamique END;
IF OBJECT_ID('EV_inactifs_last_ha') IS NOT NULL BEGIN; DROP TABLE EV_inactifs_last_ha END;
IF OBJECT_ID('EV_inactifs_transc_last_ha') IS NOT NULL BEGIN; DROP TABLE EV_inactifs_transc_last_ha END;
IF OBJECT_ID('EV_inactifs_top_ha_period') IS NOT NULL BEGIN; DROP TABLE EV_inactifs_top_ha_period END;
IF OBJECT_ID('EV_Table_RF_Dynamique') IS NOT NULL BEGIN; DROP TABLE EV_Table_RF_Dynamique END;

	/* T_evol_nb_trx */
IF OBJECT_ID('EV_first_last_trx2') IS NOT NULL BEGIN; DROP TABLE EV_first_last_trx2 END;
IF OBJECT_ID('EV_evol_trx') IS NOT NULL BEGIN; DROP TABLE EV_evol_trx END;
IF OBJECT_ID('EV_T_evol_nb_trx') IS NOT NULL BEGIN; DROP TABLE EV_T_evol_nb_trx END;

	/* T_top_panier_moyen_sup */
IF OBJECT_ID('EV_Table_top_panier_moyen_sup') IS NOT NULL BEGIN; DROP TABLE EV_Table_top_panier_moyen_sup END;

	/* T_top_ha_[channel] */
IF OBJECT_ID('EV_Table_ha_channel') IS NOT NULL BEGIN; DROP TABLE EV_Table_ha_channel END;

	/* T_top_ecart_HA_inf_moy */
IF OBJECT_ID('EV_alim_pre_der_trx') IS NOT NULL BEGIN; DROP TABLE EV_alim_pre_der_trx END;
IF OBJECT_ID('EV_ha_foyer_non_last') IS NOT NULL BEGIN; DROP TABLE EV_ha_foyer_non_last END;
IF OBJECT_ID('EV_ha_foyer_non_first') IS NOT NULL BEGIN; DROP TABLE EV_ha_foyer_non_first END;
IF OBJECT_ID('EV_duree_inac_detail') IS NOT NULL BEGIN; DROP TABLE EV_duree_inac_detail END;
IF OBJECT_ID('EV_Table_top_inac_inf_moy') IS NOT NULL BEGIN; DROP TABLE EV_Table_top_inac_inf_moy END;

	/* T_ecart_inac_inf_moy */
IF OBJECT_ID('EV_duree_der_trx_cible') IS NOT NULL BEGIN; DROP TABLE EV_duree_der_trx_cible END;
IF OBJECT_ID('EV_duree_der_trx_cible2') IS NOT NULL BEGIN; DROP TABLE EV_duree_der_trx_cible2 END;
IF OBJECT_ID('EV_duree_der_trx_PAR') IS NOT NULL BEGIN; DROP TABLE EV_duree_der_trx_PAR END;
IF OBJECT_ID('EV_duree_der_trx_PAR2') IS NOT NULL BEGIN; DROP TABLE EV_duree_der_trx_PAR2 END;
IF OBJECT_ID('EV_duree_moy_glob_@titre') IS NOT NULL BEGIN; DROP TABLE EV_duree_moy_glob_@titre END;

-- On créée une table dans laquelle on récupère toutes les transactions (sauf celles par défauts).

Select householdid,
		profilid, 
		titleid, 
		transactiondate,
		transactionchannel,
		transactionamount,
		transactiontype
	into EV_transactions_@titre
from TITLETRANSACTION
where titleid = @titre
	and transactiontype <> 99; /*Suppression des transactions par défaut Conexance*/

-- Vérification que la table transactions_titre se créée bien.

Select top (30) *
From EV_transactions_@titre

-- Création d'une table matrice pour la phase de recette avec
-- initialisation des variables à 0.

Select householdid,
		case when recence <= 3 then 1 Else 0 End as Vae,
		0 as T_g_nb_trx,
		0 as T_ecart_first_last,
		0 as T_best_mois,
		0 as T_top_soldes_ete,
		0 as T_top_soldes_hiver,
		0 as T_top_soldes,
		0 as T_trans_trim1,
		0 as T_trans_trim2,
		0 as T_trans_trim3,
		0 as T_trans_trim4,
		0 as T_top_TBC,
		0 as T_top_BC,
		0 as T_top_Nouveaux,
		0 as T_evol_nb_trx_positif,
		0 as T_evol_nb_trx_negatif,
		0 as T_top_panier_moyen_sup,
		0 as T_top_ha_web,
		0 as T_top_ha_courrier,
		0 as T_top_ha_tel,
		0 as T_top_ha_multi_channel,
		0 as T_top_ecart_HA_inf_moy,
		0 as T_ecart_inac_inf_moy
	into EV_matrice_variables_interne_@titre
From titlehousehold
Where titleid = 531
Order by householdid

-- Vérification des fréquences population à réactiver/cible.

select vae,
		count(distinct householdid) as nb_hhd
from EV_matrice_variables_interne_@titre
group by vae

-- Vérification que la table EV_Population_etude_@titre se créée bien.

Select top(30) *
From EV_matrice_variables_interne_@titre

--/*******************************************************/
--/***************** Variable: T_g_nb_trx ****************/
--/*******************************************************/

-- On récupère la date de dernière transaction pour chaque foyer puis 
-- celle correspondant à la date de dernière transaction moins 5 ans.

Select householdid, 
		min(transactiondate) as pre_trx,
		max(transactiondate) as der_trx,
		dateadd(month,-5*12,max(transactiondate)) as cinq_avant
	into EV_foyers_min_max_date
From EV_transactions_@titre
Group By householdid
Order By householdid

-- Vérification du contenu de la table EV_foyers_min_max_date.

Select top (30) *
From EV_foyers_min_max_date

/* On a notre intervalle de temps, maintenant on recherche les transactions qui
	sont comprises entre cet intervalle. */
	
Select t1.householdid,
		count(transactiondate) as Nb_trx,
		Case when count(transactiondate)>=2 then 2
			 when count(transactiondate) =1 then 1
				Else 0 end T_g_nb_trx
	into EV_T_g_nb_trx
From EV_transactions_@titre t1
	inner join EV_foyers_min_max_date t2 on t1.householdid=t2.Householdid
Where t2.cinq_avant <= t1.transactiondate
	and t1.transactiondate < t2.der_trx
Group By t1.Householdid 
	
-- Vérification du contenu de la table EV_table_g_nb_trx.
	
Select top(30) *
From EV_T_g_nb_trx

-- On met à jour la colonne T_g_nb_trx de la table EV_matrice_variables_interne_@titre
-- à l'aide de la table EV_T_g_nb_trx

update EV_matrice_variables_interne_@titre
set EV_matrice_variables_interne_@titre.T_g_nb_trx = EV_T_g_nb_trx.T_g_nb_trx
From EV_matrice_variables_interne_@titre
	inner join EV_T_g_nb_trx 
		on EV_matrice_variables_interne_@titre.householdid=EV_T_g_nb_trx.householdid

-- Vérification de la MAJ de la table EV_matrice_variables_interne_@titre.
	
Select top(30) *
From EV_matrice_variables_interne_@titre
						
/*  On affiche les résultats obtenus des tris croisés VAE * T_g_nb_trx  */

Select T_g_nb_trx, count(householdid) as T_g_nb_trx__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_g_nb_trx
Select T_g_nb_trx, count(householdid) as T_g_nb_trx__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_g_nb_trx

--/*******************************************************/
--/*********** Variable: T_ecart_first_last **************/
--/*******************************************************/

-- On créée une table qui calcul l'écart (en nombre de mois) entre la première 
-- et la dernière transaction pour chaque foyers, et on regroupe.

Select householdid,
		datediff(month,pre_trx,der_trx) as tranche_anc,
		case when datediff(month,pre_trx,der_trx) = 0 then 0
			 when datediff(month,pre_trx,der_trx) <= 6 then 1
			 when datediff(month,pre_trx,der_trx) <= 12 then 2
			 when datediff(month,pre_trx,der_trx) <= 24 then 3
			 when datediff(month,pre_trx,der_trx) <= 48 then 4 Else 5
			 end T_ecart_first_last
	into EV_T_ecart_first_last
From EV_foyers_min_max_date

-- Vérification du contenu de la table EV_T_ecart_first_last.

Select top(30) *
From EV_T_ecart_first_last

-- On met à jour la colonne T_ecart_first_last de la table EV_matrice_variables_interne_@titre
-- à l'aide de la table EV_T_ecart_first_last

update EV_matrice_variables_interne_@titre
set EV_matrice_variables_interne_@titre.T_ecart_first_last = EV_T_ecart_first_last.T_ecart_first_last
From EV_matrice_variables_interne_@titre
	inner join EV_T_ecart_first_last 
		on EV_matrice_variables_interne_@titre.householdid=EV_T_ecart_first_last.householdid

-- Vérification de la MAJ de la table EV_matrice_variables_interne_@titre.
	
Select top(30) *
From EV_matrice_variables_interne_@titre
						
-- On affiche les résultats obtenus des tris croisés VAE * T_ecart_first_last

Select T_ecart_first_last, count(householdid) as T_ecart_first_last__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_ecart_first_last
order by T_ecart_first_last
Select T_ecart_first_last, count(householdid) as T_ecart_first_last__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_ecart_first_last
order by T_ecart_first_last

--/*******************************************************/
--/*************** Variable: T_best_mois *****************/
--/*******************************************************/

-- On stock dans une variable le mois et l'année de la dernière transaction réalisé au global.

Select @month_last_date = month(max(transactiondate)),
		@year_last_date = year(max(transactiondate))
From EV_transactions_@titre

-- On affiche les deux variables.

Select @month_last_date as mois_der_ha,
		@year_last_date as année_der_ha

-- On détermine les deux dates permettant de définir notre période d'analyse.

If @month_last_date >=1 and @month_last_date <=6
	Begin
		Set @mois_debut = 1
		Set @annee_debut = @year_last_date -1
		Set @mois_fin = 1
		Set @annee_fin = @year_last_date
		Set @periode_debut = DATEFROMPARTS(@annee_debut,@mois_debut,1)
		Set @periode_fin = DATEFROMPARTS(@annee_fin,@mois_fin,1)
	End
Else 
	Begin
		Set @mois_debut = 7
		Set @annee_debut = @year_last_date -1
		Set @mois_fin = 7
		Set @annee_fin = @year_last_date
		Set @periode_debut = DATEFROMPARTS(@annee_debut,@mois_debut,1)
		Set @periode_fin = DATEFROMPARTS(@annee_fin,@mois_fin,1)
	End

-- On affiche les deux dates pour voir si elles sont cohérentes avec le résultat précédent.
	
Select @periode_debut as date_debut,
		@periode_fin as date_fin

-- On créée une table dans laquelle on récupère uniquement les transactions ayant
-- été réalisées durant cette période d'analyse.

Select householdid,
		transactiondate,
		month(transactiondate) as mois
	into EV_periode_analyse
From EV_transactions_@titre
Where @periode_debut<=transactiondate
	and transactiondate < @periode_fin

-- Vérification du contenu de la table EV_periode_analyse.

Select top(30) *
From EV_periode_analyse

-- à partir de la table précédente on détermine le nombre de transactions
-- pour chaque mois.

Select mois,
		count(*) as Nb_trx_periode
	into EV_transaction_mois_@titre
From EV_periode_analyse
Group By mois

-- Vérification du contenu de la table EV_transaction_mois_@titre.

Select *
From EV_transaction_mois_@titre
order by Nb_trx_periode desc

-- Récupération des 3 meilleurs mois.

Select top(3) mois
	into EV_table_best_mois
From EV_transaction_mois_@titre
order by Nb_trx_periode desc
		
-- Vérification du contenu de la table EV_table_best_mois.

Select *
From EV_table_best_mois

-- Récupération des foyers ayant réalisé au moins une transaction LT dans l'un 
-- des 3 meilleurs mois.

Select distinct householdid
	into EV_Foyers_best_mois
From EV_transactions_@titre
Where month(transactiondate) in (Select mois
								From EV_table_best_mois)
								
-- On met à jour la colonne T_g_nb_trx de la table EV_matrice_variables_interne_@titre
-- à l'aide de la table EV_Foyers_best_mois

update EV_matrice_variables_interne_@titre
set EV_matrice_variables_interne_@titre.T_best_mois = 1
From EV_matrice_variables_interne_@titre
	inner join EV_Foyers_best_mois 
		on EV_matrice_variables_interne_@titre.householdid=EV_Foyers_best_mois.householdid

-- Vérification de la MAJ de la table EV_matrice_variables_interne_@titre.
	
Select top(30) *
From EV_matrice_variables_interne_@titre
						
/*  On affiche les résultats obtenus des tris croisés VAE * T_best_mois  */

Select T_best_mois, count(householdid) as T_best_mois__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_best_mois
Select T_best_mois, count(householdid) as T_best_mois__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_best_mois

--/******************************************************************************/
--/*****************Variable: [T_top_solde] et [Top_trimestre]*******************/
--/******************************************************************************/

Select householdid,
		Max(Case When month(transactiondate) in (1,2,3) then 1 Else 0 End) as T_trans_trim1,
		Max(Case When month(transactiondate) in (4,5,6) then 1 Else 0 End) as T_trans_trim2,
		Max(Case When month(transactiondate) in (7,8,9) then 1 Else 0 End) as T_trans_trim3,
		Max(Case When month(transactiondate) in (10,11,12) then 1 Else 0 End) as T_trans_trim4,
		Max(case when (DATEFROMPARTS(year(transactiondate),6,27)<= transactiondate and
					DATEFROMPARTS(year(transactiondate),8,7)>= transactiondate) then 1 else 0 End) as T_top_soldes_ete,
		Max(case when (DATEFROMPARTS(year(transactiondate),1,10)<= transactiondate and
					DATEFROMPARTS(year(transactiondate),2,20)>= transactiondate) then 1 else 0 End) as T_top_soldes_hiver,
		Max(case when (DATEFROMPARTS(year(transactiondate),6,27)<= transactiondate and
					DATEFROMPARTS(year(transactiondate),8,7)>= transactiondate) or 
				  (DATEFROMPARTS(year(transactiondate),1,10)<= transactiondate and
					DATEFROMPARTS(year(transactiondate),2,20)>= transactiondate) then 1 Else 0 End) as T_top_soldes
	Into EV_Table_Top_solde_dedup
From EV_transactions_@titre
Group By Householdid

-- Vérification du contenu de la table EV_Table_Top_solde_dedup.

Select top(50) *
From EV_Table_Top_solde_dedup

-- On met à jour la table EV_matrice_variables_interne_@titre
-- à l'aide de la table EV_Table_Top_solde_dedup

update EV_matrice_variables_interne_@titre
set EV_matrice_variables_interne_@titre.T_trans_trim1 = EV_Table_Top_solde_dedup.T_trans_trim1,
	EV_matrice_variables_interne_@titre.T_trans_trim2 = EV_Table_Top_solde_dedup.T_trans_trim2,
	EV_matrice_variables_interne_@titre.T_trans_trim3 = EV_Table_Top_solde_dedup.T_trans_trim3,
	EV_matrice_variables_interne_@titre.T_trans_trim4 = EV_Table_Top_solde_dedup.T_trans_trim4,
	EV_matrice_variables_interne_@titre.T_top_soldes_ete = EV_Table_Top_solde_dedup.T_top_soldes_ete,
	EV_matrice_variables_interne_@titre.T_top_soldes_hiver = EV_Table_Top_solde_dedup.T_top_soldes_hiver,
	EV_matrice_variables_interne_@titre.T_top_soldes = EV_Table_Top_solde_dedup.T_top_soldes
From EV_matrice_variables_interne_@titre
	inner join EV_Table_Top_solde_dedup 
		on EV_matrice_variables_interne_@titre.householdid=EV_Table_Top_solde_dedup.householdid

-- Vérification de la MAJ de la table EV_matrice_variables_interne_@titre.
	
Select top(30) *
From EV_matrice_variables_interne_@titre
						
/*  On affiche les résultats obtenus des tris croisés VAE * [variable(s)]  */

/* T_top_soldes_ete */
Select T_top_soldes_ete, count(householdid) as T_top_soldes_ete__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_soldes_ete
Select T_top_soldes_ete, count(householdid) as T_top_soldes_ete__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_soldes_ete

	/* T_top_soldes_hiver */
Select T_top_soldes_hiver, count(householdid) as T_top_soldes_hiver__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_soldes_hiver
Select T_top_soldes_hiver, count(householdid) as T_top_soldes_hiver__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_soldes_hiver

	/* T_top_soldes */
Select T_top_soldes, count(householdid) as T_top_soldes__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_soldes
Select T_top_soldes, count(householdid) as T_top_soldes__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_soldes

	/* T_trans_trim1 */
Select T_trans_trim1, count(householdid) as T_trans_trim1__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_trans_trim1
Select T_trans_trim1, count(householdid) as T_trans_trim1__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_trans_trim1

	/* T_trans_trim2 */
Select T_trans_trim2, count(householdid) as T_trans_trim2__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_trans_trim2
Select T_trans_trim2, count(householdid) as T_trans_trim2__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_trans_trim2

	/* T_trans_trim3 */
Select T_trans_trim3, count(householdid) as T_trans_trim3__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_trans_trim3
Select T_trans_trim3, count(householdid) as T_trans_trim3__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_trans_trim3

	/* T_trans_trim4 */
Select T_trans_trim4, count(householdid) as T_trans_trim4__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_trans_trim4
Select T_trans_trim4, count(householdid) as T_trans_trim4__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_trans_trim4

--/***********************************************************/
--/***************** Variable: T_RF_dynamique ****************/
--/***********************************************************/
	
	/*!!!!!!!*/
	/* Cible */
	/*!!!!!!!*/

-- On affecte à la variable dern_ha_moins12 la date de dernier achat du fichier
-- client 356 jours auparavant.

Set @dern_ha_moins12 = (select dateadd(day,-365,max(transactiondate))
							from EV_transactions_@titre
							where transactiontype in (9,10,12))

-- Vérification du contenu de la variable dern_ha_moins12.

Select @dern_ha_moins12 as der_ha_cible_moins_1_an

-- On attribut à chaque foyer de la cible une valeur pour les variables
-- top_TBC, top_BC et top_Nouveaux en fonction de leur nombre d'achats
-- d'achats réalisé durant la dernière année entière.

Select householdid,
		count(TransactionDate) as nb_trx,
		case when count(TransactionDate) >= 3 then 1 Else 0 End as top_TBC,
		case when count(TransactionDate) = 2 then 1 Else 0 End as top_BC,
		case when count(TransactionDate) = 1 then 1 Else 0 End as top_Nouveaux
	into EV_Cible_T_RF_dynamique
From EV_transactions_@titre
Where householdid in (select householdid 
						from EV_matrice_variables_interne_@titre
						where vae=1)
	and transactiontype in (9,10,12)
	and transactiondate >= @dern_ha_moins12
Group by householdid

-- Vérification du contenu de la table Cible_T_RF_dynamique.

Select top (30) *
From EV_Cible_T_RF_dynamique

	/*!!!!!!!!!!!!!!!!!!!!!!!!*/
	/* Population à réactiver */
	/*!!!!!!!!!!!!!!!!!!!!!!!!*/

-- On détermine pour chaque foyer les bornes temporelle qui vont nous permettre
-- de définir notre semestre s1, s2, s3 et s4 pour chaque foyer.

Select householdid,
		dateadd(month,-6,max(transactiondate)) as date_6mois,
		dateadd(month,-12,max(transactiondate)) as date_12mois,
		dateadd(month,-18,max(transactiondate)) as date_18mois,
		dateadd(month,-24,max(transactiondate)) as date_24mois
	into EV_inactifs_last_ha
From EV_transactions_@titre
Where householdid in (Select householdid 
						from EV_matrice_variables_interne_@titre
						where vae=0)
	and transactiontype in (9,10,12)
Group By householdid

-- Vérification du contenu de la table EV_inactifs_last_ha.

Select top (30) *
From EV_inactifs_last_ha

-- Pour chaque transaction réalisée, on regarde si elle a été effectué dans l'un des 4 semestres,
-- on affecte les variables top_ha_perio1, top_ha_perio2, top_ha_perio3 et top_ha_perio4 en 
-- conséquence.

Select t1.Householdid,
		case when t1.transactiondate > t2.date_24mois and t1.transactiondate <= t2.date_18mois then 1 Else 0 End as top_ha_perio4,
		case when t1.transactiondate > t2.date_18mois and t1.transactiondate <= t2.date_12mois then 1 Else 0 End as top_ha_perio3,
		case when t1.transactiondate > t2.date_12mois and t1.transactiondate <= t2.date_6mois then 1 Else 0 End as top_ha_perio2,
		case when t1.transactiondate > t2.date_6mois then 1 Else 0 End as top_ha_perio1
	into EV_inactifs_transc_last_ha
From EV_transactions_@titre t1
	inner join EV_inactifs_last_ha t2 on t1.householdid=t2.householdid

-- Vérification du contenu de la table EV_inactifs_transc_last_ha.

Select top (30) *
From EV_inactifs_transc_last_ha

-- On affecte pour chaque foyer sa valeur top_TBC, top_BC et top_Nouveaux en fonction
-- de sa note RF.

Select Householdid,
		Case when max(top_ha_perio4) + max(top_ha_perio3) * 2 + max(top_ha_perio2) * 4 + max(top_ha_perio1)*8 in (11,13,14,15) then 1 Else 0 End as top_TBC,
		Case when max(top_ha_perio4) + max(top_ha_perio3) * 2 + max(top_ha_perio2) * 4 + max(top_ha_perio1)*8 in (7,9,10,12) then 1 Else 0 End as top_BC,
		Case when max(top_ha_perio4) + max(top_ha_perio3) * 2 + max(top_ha_perio2) * 4 + max(top_ha_perio1)*8 = 8 then 1 Else 0 End as top_Nouveaux
	into EV_inactifs_top_ha_period
From EV_inactifs_transc_last_ha
Group By Householdid

-- Vérification du contenu de la table EV_inactifs_top_ha_period.

Select top (30) *
From EV_inactifs_top_ha_period

-- On fusionne les deux tables de sorte à avoir la cible et la population à réactiver 
-- dans la même table.

Select t1.householdid,
		X.T_top_TBC,
		X.T_top_BC,
		X.T_top_Nouveaux
	into EV_Table_RF_Dynamique
From EV_matrice_variables_interne_@titre t1
	inner join
	(Select 
		case when t2.householdid is null then t3.householdid else t2.householdid End as householdid, --> à confirmer from JP
		case when t2.top_TBC is null then t3.top_TBC else t2.top_TBC End as T_top_TBC,
		case when t2.top_BC is null then t3.top_BC else t2.top_BC End as T_top_BC,
		case when t2.top_Nouveaux is null then t3.top_Nouveaux else t2.top_Nouveaux End as T_top_Nouveaux
	From EV_Cible_T_RF_dynamique t2 
		full join EV_inactifs_top_ha_period t3 on t2.householdid=t3.householdid
	) X on t1.householdid=X.householdid

-- Vérification du contenu de la table EV_inactifs_top_ha_period.

Select top (30) *
From EV_Table_RF_Dynamique

-- On met à jour la table EV_matrice_variables_interne_@titre
-- à l'aide de la table EV_Table_RF_Dynamique

update EV_matrice_variables_interne_@titre
set EV_matrice_variables_interne_@titre.T_top_TBC = EV_Table_RF_Dynamique.T_top_TBC,
	EV_matrice_variables_interne_@titre.T_top_BC = EV_Table_RF_Dynamique.T_top_BC,
	EV_matrice_variables_interne_@titre.T_top_Nouveaux = EV_Table_RF_Dynamique.T_top_Nouveaux
From EV_matrice_variables_interne_@titre
	inner join EV_Table_RF_Dynamique 
		on EV_matrice_variables_interne_@titre.householdid=EV_Table_RF_Dynamique.householdid

-- Vérification de la MAJ de la table EV_matrice_variables_interne_@titre.
	
Select top(30) *
From EV_matrice_variables_interne_@titre
						
-- On affiche les résultats obtenus des tris croisés VAE * [variable(s)] 

	/* T_top_TBC */
Select T_top_TBC, count(householdid) as T_top_TBC__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_TBC
Select T_top_TBC, count(householdid) as T_top_TBC__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_TBC	

	/* T_top_BC */
Select T_top_BC, count(householdid) as T_top_BC__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_BC
Select T_top_BC, count(householdid) as T_top_BC__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_BC	

	/* T_top_Nouveaux */
Select T_top_Nouveaux, count(householdid) as T_top_Nouveaux__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_Nouveaux
Select T_top_Nouveaux, count(householdid) as T_top_Nouveaux__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_Nouveaux	

--/**********************************************************/
--/***************** Variable: T_evol_nb_trx ****************/
--/**********************************************************/

-- On détermine les dates qui vont nous permettre de construire nos intervalles.

Select householdid,
		pre_trx,
		dateadd(month,12,pre_trx) as pre_trx_plus_12,
		dateadd(month,-12,der_trx) as der_trx_moins_12,
		der_trx
	Into EV_first_last_trx2
From EV_foyers_min_max_date

-- Vérification du contenu de la table EV_first_last_trx2.

Select top(30) *
From EV_first_last_trx2

-- On a notre intervalle de temps, maintenant on recherche les transactions qui
-- sont comprises entre ces intervalles.
	
Select t1.householdid,
		t1.transactiondate,
		t2.pre_trx,
		t2.pre_trx_plus_12,
		t2.der_trx_moins_12,
		t2.der_trx,
		case when t2.pre_trx<t1.transactiondate and t1.transactiondate<=t2.pre_trx_plus_12 then 1 else 0 end periode_first_0_12,
		case when t2.der_trx_moins_12<=t1.transactiondate and t1.transactiondate<t2.der_trx then 1 else 0 end periode_last_0_12
	into EV_evol_trx
From EV_transactions_@titre t1
		inner join EV_first_last_trx2 t2 on t1.householdid=t2.Householdid

-- Vérification du contenu de la table EV_evol_trx

Select top(30) *
From EV_evol_trx

-- On compte le nombre de transactions pour la période de début et pour la période de fin
-- On détermine en fonction de ces quantités les valeurs des variables :
-- T_evol_nb_trx_positif et T_evol_nb_trx_negatif
		
Select householdid,
		sum(periode_first_0_12) as Nb_cmd_prem_annee,
		sum(periode_last_0_12) as Nb_cmd_der_annee,
		case when sum(periode_last_0_12)-sum(periode_first_0_12) > 0 then 1 Else 0 End T_evol_nb_trx_positif,
		case when sum(periode_last_0_12)-sum(periode_first_0_12) < 0 then 1 Else 0 End T_evol_nb_trx_negatif
	Into EV_T_evol_nb_trx
From EV_evol_trx
Group By householdid

-- Vérification du contenu de la table EV_evol_nb_trx

Select top(30) *
From EV_T_evol_nb_trx

-- On met à jour la table EV_matrice_variables_interne_@titre
-- à l'aide de la table EV_Table_Top_solde_dedup

update EV_matrice_variables_interne_@titre
set EV_matrice_variables_interne_@titre.T_evol_nb_trx_positif = EV_T_evol_nb_trx.T_evol_nb_trx_positif,
	EV_matrice_variables_interne_@titre.T_evol_nb_trx_negatif = EV_T_evol_nb_trx.T_evol_nb_trx_negatif
From EV_matrice_variables_interne_@titre
	inner join EV_T_evol_nb_trx 
		on EV_matrice_variables_interne_@titre.householdid=EV_T_evol_nb_trx.householdid

-- Vérification de la MAJ de la table EV_matrice_variables_interne_@titre.
	
Select top(30) *
From EV_matrice_variables_interne_@titre
						
-- On affiche les résultats obtenus des tris croisés VAE * [variable(s)] 

/* T_evol_nb_trx_positif */
Select T_evol_nb_trx_positif, count(householdid) as T_evol_nb_trx_positif__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_evol_nb_trx_positif
Select T_evol_nb_trx_positif, count(householdid) as T_evol_nb_trx_positif__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_evol_nb_trx_positif

	/* T_evol_nb_trx_negatif */
Select T_evol_nb_trx_negatif, count(householdid) as T_evol_nb_trx_negatif__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_evol_nb_trx_negatif
Select T_evol_nb_trx_negatif, count(householdid) as T_evol_nb_trx_negatif__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_evol_nb_trx_negatif

--/*******************************************************************/
--/***************** Variable: T_Top_panier_moyen_sup ****************/
--/*******************************************************************/

-- Calcul du panier moyen au global (transaction de type achat (transactiontype in (9 10 12)) 

Select @panier_moyen = avg(transactionamount)
From EV_transactions_@titre
where transactiontype in (9,10,12)

-- On affiche la valeur du panier moyen au global

Select @panier_moyen as panier_moyen_global

-- On détermine pour chaque foyer si son panier moyen est supérieur au
-- panier moyen global, si c'est le cas on affecte à la variable 
-- T_top_panier_moyen_sup la valeur 1 sinon 0

Select householdid,
		avg(transactionamount) as panier_moyen_foyer,
		@panier_moyen as panier_moyen_global,
		case when avg(transactionamount) > @panier_moyen then 1 Else 0 End T_top_panier_moyen_sup
	into EV_Table_top_panier_moyen_sup
From EV_transactions_@titre
Where transactiontype in (9,10,12)
Group By householdid
Order By householdid

-- Vérification du contenu de la table EV_Table_top_panier_moyen_sup

Select top(30) *
From EV_Table_top_panier_moyen_sup

-- On met à jour la table EV_matrice_variables_interne_@titre
-- à l'aide de la table EV_Table_top_panier_moyen_sup

update EV_matrice_variables_interne_@titre
set EV_matrice_variables_interne_@titre.T_top_panier_moyen_sup = EV_Table_top_panier_moyen_sup.T_top_panier_moyen_sup
From EV_matrice_variables_interne_@titre
	inner join EV_Table_top_panier_moyen_sup 
		on EV_matrice_variables_interne_@titre.householdid=EV_Table_top_panier_moyen_sup.householdid

-- Vérification de la MAJ de la table EV_matrice_variables_interne_@titre.
	
Select top(30) *
From EV_matrice_variables_interne_@titre
						
-- On affiche les résultats obtenus des tris croisés VAE * [variable(s)] 

Select T_top_panier_moyen_sup, count(householdid) as T_top_panier_moyen_sup__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_panier_moyen_sup
Select T_top_panier_moyen_sup, count(householdid) as T_top_panier_moyen_sup__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_panier_moyen_sup	

--/***************************************************************/
--/***************** Variable: T_top_ha_[channel] ****************/
--/***************************************************************/

-- On calcule pour chaque foyer s'il a réalisé au moins un
-- achat sur l'un des canal suivant (courrier, tel ou web)

Select householdid,
		max(case when transactionchannel = 1 then 1 Else 0 End) as T_top_ha_courrier,
		max(case when transactionchannel = 2 then 1 Else 0 End) as T_top_ha_tel,	
		max(case when transactionchannel = 3 then 1 Else 0 End) as T_top_ha_web,
		case when
			max(case when transactionchannel = 1 then 1 Else 0 End)+
			max(case when transactionchannel = 2 then 1 Else 0 End)+
			max(case when transactionchannel = 3 then 1 Else 0 End) > 1 then 1 Else 0 End T_top_ha_multi_channel
	Into EV_Table_ha_channel
From EV_transactions_@titre
Where transactiontype in (9,10,12)
Group By Householdid;

-- Vérification du contenu de la table EV_T_top_ha

Select top(30) *
From EV_Table_ha_channel

-- On met à jour la table EV_matrice_variables_interne_@titre
-- à l'aide de la table EV_Table_ha_channel

update EV_matrice_variables_interne_@titre
set EV_matrice_variables_interne_@titre.T_top_ha_courrier = EV_Table_ha_channel.T_top_ha_courrier,
	EV_matrice_variables_interne_@titre.T_top_ha_tel = EV_Table_ha_channel.T_top_ha_tel,
	EV_matrice_variables_interne_@titre.T_top_ha_web = EV_Table_ha_channel.T_top_ha_web,
	EV_matrice_variables_interne_@titre.T_top_ha_multi_channel = EV_Table_ha_channel.T_top_ha_multi_channel
From EV_matrice_variables_interne_@titre
	inner join EV_Table_ha_channel 
		on EV_matrice_variables_interne_@titre.householdid=EV_Table_ha_channel.householdid

-- Vérification de la MAJ de la table EV_matrice_variables_interne_@titre.
	
Select top(30) *
From EV_matrice_variables_interne_@titre
						
-- On affiche les résultats obtenus des tris croisés VAE * [variable(s)] 

	/* T_top_ha_courrier */
Select T_top_ha_courrier, count(householdid) as T_top_ha_courrier__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_ha_courrier
Select T_top_ha_courrier, count(householdid) as T_top_ha_courrier__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_ha_courrier

	/* T_top_ha_tel */
Select T_top_ha_tel, count(householdid) as T_top_ha_tel__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_ha_tel
Select T_top_ha_tel, count(householdid) as T_top_ha_tel__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_ha_tel

	/* T_top_ha_web */
Select T_top_ha_web, count(householdid) as T_top_ha_web__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_ha_web
Select T_top_ha_web, count(householdid) as T_top_ha_web__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_ha_web

	/* T_top_ha_multi_channel */
Select T_top_ha_multi_channel, count(householdid) as T_top_ha_multi_channel__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_ha_multi_channel
Select T_top_ha_multi_channel, count(householdid) as T_top_ha_multi_channel__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_ha_multi_channel

--/***************************************************************/
--/************* Variable: T_top_ecart_HA_inf_moy ****************/
--/***************************************************************/

-- On identifie pour chaque foyers sa transaction correspondant à son premier achat
-- et sa transaction correspondant à son dernier achat
Select t1.householdid, 
		t1.transactiondate,
		t2.der_trx,
		t2.pre_trx,
		case when t1.transactiondate = t2.der_trx then 1 else 0 End Derniere_trx,
		case when t1.transactiondate = t2.pre_trx then 1 else 0 End Premiere_trx
	into EV_alim_pre_der_trx
From EV_transactions_@titre t1 inner join EV_foyers_min_max_date t2
	on t1.householdid=t2.householdid
Where t1.transactiontype in (9,10,12)
order by t1.householdid, t1.transactiondate

-- Vérification du contenu de la table EV_alim_pre_der_trx

Select top(200) *
From EV_alim_pre_der_trx
order by householdid, transactiondate

-- On créée une table dans laquelle on conserve tous les achats sauf le dernier
-- et cela pour chaque foyer

Select householdid,
		transactiondate as trx_n0
	into EV_ha_foyer_non_last
From EV_alim_pre_der_trx
Where Derniere_trx <> 1
order by householdid,transactiondate

-- Vérification du contenu de la table EV_ha_foyer_non_last

Select top(50) *
From EV_ha_foyer_non_last
order by householdid,trx_n0

-- On créée une table dans laquelle on conserve tous les achats sauf le premier
-- et cela pour chaque foyer

Select householdid,
		transactiondate as trx_n1
	into EV_ha_foyer_non_first
From EV_alim_pre_der_trx
Where Premiere_trx <> 1
order by householdid,transactiondate

-- Vérification du contenu de la table EV_ha_foyer_non_first

Select top(50) *
From EV_ha_foyer_non_first
order by householdid,trx_n1

-- On calcule pour chaque foyer le nombre de jours qui s'est ecoulé entre la transaction n0
-- et la transaction n1

Select t1.householdid, 
		avg(DATEDIFF(day, t2.trx_n0, t1.trx_n1)) as mean_intervalle_ha
	into EV_duree_inac_detail
From EV_ha_foyer_non_first t1 inner join 
	EV_ha_foyer_non_last t2 on t1.householdid = t2.householdid
Group By t1.Householdid

-- Vérification du contenu de la table EV_duree_inac_detail

Select top(50) *
From EV_duree_inac_detail

-- On affecte à la variable ha_inac_moy_global, le nombre de jours qui s'écoule
-- entre deux achats en moyenne sur tout le fichier client.

set @ha_inac_moy_global = (Select avg(mean_intervalle_ha)
							From EV_duree_inac_detail)

-- Vérification du contenu de la variable ha_inac_moy_global

Select @ha_inac_moy_global as intervalle_moy_inact_global
						
-- On calcule la moyenne d'inactivité (en nombre de jours) pour chaque foyer,
-- si cette moyenne est plus petite que la moyenne au global alors on affecte
-- à la variable T_top_ecart_HA_inf_moy la valeur 1 sinon 0
						
Select householdid, 
		avg(mean_intervalle_ha) as moy_foy,
		@ha_inac_moy_global as moy_globale,
		Case When avg(mean_intervalle_ha) < @ha_inac_moy_global then 1 else 0 End T_top_ecart_HA_inf_moy
	into EV_Table_top_inac_inf_moy
From EV_duree_inac_detail
Group By Householdid

-- Vérification du contenu de la table EV_Table_top_inac_inf_moy

Select top(30) *
From EV_Table_top_inac_inf_moy

-- On met à jour la table EV_matrice_variables_interne_@titre
-- à l'aide de la table EV_Table_top_inac_inf_moy

update EV_matrice_variables_interne_@titre
set EV_matrice_variables_interne_@titre.T_top_ecart_HA_inf_moy = EV_Table_top_inac_inf_moy.T_top_ecart_HA_inf_moy
From EV_matrice_variables_interne_@titre
	inner join EV_Table_top_inac_inf_moy 
		on EV_matrice_variables_interne_@titre.householdid=EV_Table_top_inac_inf_moy.householdid

-- Vérification de la MAJ de la table EV_matrice_variables_interne_@titre.
	
Select top(30) *
From EV_matrice_variables_interne_@titre
						
-- On affiche les résultats obtenus des tris croisés VAE * [variable(s)] 

Select T_top_ecart_HA_inf_moy, count(householdid) as T_top_ecart_HA_inf_moy__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_top_ecart_HA_inf_moy
Select T_top_ecart_HA_inf_moy, count(householdid) as T_top_ecart_HA_inf_moy__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_top_ecart_HA_inf_moy

--/************************************************************/
--/************** Variable: T_ecart_inac_inf_moy **************/
--/************************************************************/

	/*!!!!!!!*/
	/* Cible */
	/*!!!!!!!*/

Set @der_trx_cible = (Select max(transactiondate)
					From EV_transactions_@titre
					Where transactiontype in (9,10,12)
						and householdid in (Select householdid
											From EV_matrice_variables_interne_@titre
											Where vae = 1))

-- Vérification du contenu de la variable der_trx_cible

Select @der_trx_cible as date_der_ha_cible

Select householdid,
		@der_trx_cible as date_der_ha_cible,
		max(transactiondate) as date_der_ha_foy,
		DATEDIFF(day,max(transactiondate),@der_trx_cible) as duree_der_trx_cible
	Into EV_duree_der_trx_cible
From EV_transactions_@titre
Where transactiontype in (9,10,12)
	and householdid in (Select householdid
						From EV_matrice_variables_interne_@titre
						Where vae = 1)
Group By Householdid

-- Vérification du contenu de la table EV_duree_der_trx_cible

Select top(30) *
From EV_duree_der_trx_cible

Set @duree_moy_cible = (Select avg(duree_der_trx_cible)
						From EV_duree_der_trx_cible)

-- Vérification du contenu de la variable duree_moy_cible

Select @duree_moy_cible as duree_moy_inact_cible

Select householdid,
		duree_der_trx_cible as duree_foy_cible,
		@duree_moy_cible as duree_moy_cible,
		case when duree_der_trx_cible < @duree_moy_cible then 1 Else 0 End as T_ecart_inac_inf_moy
	into EV_duree_der_trx_cible2
From EV_duree_der_trx_cible

-- Vérification du contenu de la table EV_duree_der_trx_cible2

Select top(30) *
From EV_duree_der_trx_cible2

	/*!!!!!!!!!!!!!!!!!!!!!!!!*/
	/* Population à réactiver */
	/*!!!!!!!!!!!!!!!!!!!!!!!!*/

Set @der_trx_PAR = (Select max(transactiondate)
					From EV_transactions_@titre
					Where transactiontype <> 99
						and householdid in (Select householdid
											From EV_matrice_variables_interne_@titre
											Where vae = 0))

-- Vérification du contenu de la vairable @der_trx_PAR

Select @der_trx_PAR as date_der_trx_Pop_étude

Select householdid,
		@der_trx_PAR as date_der_trx_global,
		max(transactiondate) as date_der_trx_par,
		DATEDIFF(day,max(transactiondate),@der_trx_PAR) as duree_der_trx_PAR
	Into EV_duree_der_trx_par
From EV_transactions_@titre
Where transactiontype in (9,10,12)
	and householdid in (Select householdid
						From EV_matrice_variables_interne_@titre
						Where vae = 0)
Group By Householdid

-- Vérification du contenu de la table EV_duree_der_trx_par

Select top(30) *
From EV_duree_der_trx_par

Set @duree_moy_PAR = (Select avg(duree_der_trx_PAR)
						From EV_duree_der_trx_par)

-- Vérification du contenu de la vairable duree_moy_PAR

Select @duree_moy_PAR as duree_moy_inact_Pop_a_react

Select householdid,
		duree_der_trx_par as duree_moy_foy,
		@duree_moy_PAR as duree_moy_global,
		case when duree_der_trx_par < @duree_moy_PAR then 1 Else 0 End as T_ecart_inac_inf_moy
	into EV_duree_der_trx_PAR2
From EV_duree_der_trx_PAR

-- Vérification du contenu de la table EV_duree_der_trx_PAR2

Select top(30) *
From EV_duree_der_trx_PAR2

/* Fusion des deux tables */

Select t1.householdid,
		X.T_ecart_inac_inf_moy
	into EV_duree_moy_glob_@titre
From EV_matrice_variables_interne_@titre t1
	inner join
	(Select 
			case when t2.householdid is null then t3.householdid else t2.householdid End as householdid,
			case when t2.T_ecart_inac_inf_moy is null then t3.T_ecart_inac_inf_moy else t2.T_ecart_inac_inf_moy End as T_ecart_inac_inf_moy
	 From EV_duree_der_trx_cible2 t2 
		 full join EV_duree_der_trx_PAR2 t3 on t2.householdid=t3.householdid
	) X on t1.householdid=X.householdid

-- Vérification du contenu de la table duree_moy_glob_@titre

Select top (30) *
From EV_duree_moy_glob_@titre

-- On met à jour la table EV_matrice_variables_interne_@titre
-- à l'aide de la table EV_duree_moy_glob_@titre

update EV_matrice_variables_interne_@titre
set EV_matrice_variables_interne_@titre.T_ecart_inac_inf_moy = EV_duree_moy_glob_@titre.T_ecart_inac_inf_moy
From EV_matrice_variables_interne_@titre
	inner join EV_duree_moy_glob_@titre 
		on EV_matrice_variables_interne_@titre.householdid=EV_duree_moy_glob_@titre.householdid

-- Vérification de la MAJ de la table EV_matrice_variables_interne_@titre.
	
Select top(30) *
From EV_matrice_variables_interne_@titre
						
-- On affiche les résultats obtenus des tris croisés VAE * [variable(s)] 

Select T_ecart_inac_inf_moy, count(householdid) as T_ecart_inac_inf_moy__pop_a_reac
From EV_matrice_variables_interne_@titre
Where vae=0
Group By T_ecart_inac_inf_moy
Select T_ecart_inac_inf_moy, count(householdid) as T_ecart_inac_inf_moy__cible
From EV_matrice_variables_interne_@titre
Where vae=1
Group By T_ecart_inac_inf_moy
