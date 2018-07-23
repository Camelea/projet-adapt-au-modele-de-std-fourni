using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class Constructeur
	{
		#region Attributs

		public ConstructeurParDefaut ConstructeurParDefautEntite;
		public ConstructeurInstanciation ConstructeurInstanciationEntite;

		#endregion

		#region Constructeur 

		public Constructeur(ConstructeurParDefaut constructeurParDefaut, ConstructeurInstanciation constructeurInstanciation)
		{
			this.ConstructeurParDefautEntite = constructeurParDefaut;
			this.ConstructeurInstanciationEntite = constructeurInstanciation;
		}

		#endregion

		#region Méthodes
		/// <summary>
		/// Renvoie la list des constructeurs des enites 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Constructeur> Constructeurs(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Constructeur> constructeurs = new List<Constructeur>();
			List<ConstructeurParDefaut> constructeursParDefaut = ConstructeurParDefaut.ConstructeursParDefaut(doc, nsmgr);
			List<ConstructeurInstanciation> constructeursInstanciation = ConstructeurInstanciation.ConstructeursInstanciation(doc, nsmgr);

			for (int i = 0; i < Entite.NomsEntites(doc, nsmgr).Count; i++)
			{
				constructeurs.Add(new Constructeur(constructeursParDefaut[i], constructeursInstanciation[i]));


			}
			return constructeurs;

		}



		#endregion
	}
}