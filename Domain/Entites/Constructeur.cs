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
		public static Constructeur Constructeurs(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			
			ConstructeurParDefaut constructeursParDefaut = ConstructeurParDefaut.ConstructeursParDefaut(doc, nsmgr,i);
			ConstructeurInstanciation constructeursInstanciation = ConstructeurInstanciation.ConstructeursInstanciation(doc, nsmgr,i);

	
			return new Constructeur(constructeursParDefaut, constructeursInstanciation);

		}



		#endregion
	}
}