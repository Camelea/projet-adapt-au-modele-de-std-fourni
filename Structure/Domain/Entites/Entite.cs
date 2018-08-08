using ConsoleApp4.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Entites

{/// <summary>
/// Classe qui permet de récupérer tous les entités du fichier 
/// </summary>
/// 
	class Entite
	{
		#region Attributs

		public string Nom;
		public string Description;
		public EntitePartiel EntitesPartiels;
		public ClasseParent ClassesParent;
		public List<Propriete> Proprietes;
		public List<ProprieteDynamique> ProprietesDynamiques;
		public Constructeur Constructeur;
		public List<Methode> Methodes;

		#endregion

		#region Constructeur 

		public Entite(string nom, string description, EntitePartiel entitesPartiels, ClasseParent classesParent, List<Propriete> proprietes, List<ProprieteDynamique> proprietesDynamiques, Constructeur constructeur, List<Methode> methodes)
		{
			this.Nom = nom;
			this.Description = description;
			this.EntitesPartiels = entitesPartiels;
			this.ClassesParent = classesParent;
			this.Proprietes = proprietes;
			this.ProprietesDynamiques = proprietesDynamiques;
			this.Constructeur = constructeur;
			this.Methodes = methodes;
		}

		public Entite(string nom, string description, EntitePartiel entitesPartiels, ClasseParent classesParent, List<Propriete> proprietes, List<ProprieteDynamique> proprietesDynamiques, Constructeur constructeur)
		{
			this.Nom = nom;
			this.Description = description;
			this.EntitesPartiels = entitesPartiels;
			this.ClassesParent = classesParent;
			this.Proprietes = proprietes;
			this.ProprietesDynamiques = proprietesDynamiques;
			this.Constructeur = constructeur;
		}

		#endregion


		#region Methodes

		public override string ToString()
		{
			var doc = "";
			var res = "";
			var constructeurDefaut = "protected" + this.Nom + "()" + "\r\n" + "{" + this.Constructeur.ConstructeurParDefautEntite.Algorithme + "\r\n " + "}" + "\r\n";
			if (this.EntitesPartiels.Nom != "NA" && this.ClassesParent.Nom != "NA")
			{

				doc = "/// <summary>" + "\r\n" + "///" + this.EntitesPartiels.Description + "\r\n" + "/// </summary>" + "\r\n"  + "public partial class " + this.EntitesPartiels.Nom + " : Entity " + "\r\n" + "{" + "\r\n" + "/// <summary>" + "\r\n" + "///" + this.Description + "\r\n" +   "private class" + this.Nom + " : " + this.ClassesParent.Nom ;

			}

			else
			{
				doc = "/// <summary>" + "\r\n" + "///" + this.Description + "\r\n" + "/// </summary>" + "\r\n" + "/// <remarks> " + "\r\n" + "/// </remarks>" + "\r\n" + "public class" + this.Nom + " : Entity";
				
			}
			var proprietes = "#region Propriétés" + "\r\n" + this.Proprietes.ToString() + "\r\n" + "#endregion" + "\r\n";
			var proprietesDynamiques = "#region Propriétés Dynamiques " + "\r\n" + this.ProprietesDynamiques.ToString() + "\r\n" + "#endregion" + "\r\n";
			var constructeurs = "#region Constructeurs " + this.Constructeur.ToStringSansConstructeurInstanciation(constructeurDefaut) + "\r\n" + "#endregion" + "\r\n";
			var methodes = "#region Méthodes " + this.Methodes.ToString() + "\r\n" + "#endregion" + "\r\n";

			if (this.Methodes.Count == 0)
			{
				methodes = "";
			}
			if (this.ProprietesDynamiques.Count == 0)
			{
				proprietesDynamiques = "";
			}
			if (this.Constructeur.ConstructeurInstanciationEntite != null)
			{
				var constructeurInstanciation = "public" + this.Nom + this.Constructeur.ConstructeurInstanciationEntite.ParametresToString() + "\r\n" + "{" + this.Constructeur.ConstructeurInstanciationEntite.Algorithme + "\r\n" + "}" + "\r\n";
				constructeurs = "#region Constructeurs " + this.Constructeur.ToString(constructeurDefaut,constructeurInstanciation) + "\r\n" + "#endregion" + "\r\n";

			}

			res = doc + proprietes + proprietesDynamiques + constructeurs + methodes +   "\r\n" + "{" + "\r\n" + "}";
			return res;
		}


		/// <summary>
		/// Retourne une liste de noms des entites présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsEntites(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][1]/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;
		}


		/// <summary>
		/// Fonction qui retourne la liste des descriptions des entites   
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionsEntites(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			

				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";
				var res = "";
				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + " " +(isbn2.InnerText);
				}

			
			return res;


		}


		/// <summary>
		/// Retourne la liste des entités du fichier  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Entite> Entites(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Entite> entites = new List<Entite>();
			List<string> noms = NomsEntites(doc, nsmgr);

			for (int i = 1; i < NomsEntites(doc, nsmgr).Count + 1; i++)
			{
				string descriptions = DescriptionsEntites(doc, nsmgr,i);
				ClasseParent classesParent = ClasseParent.ClassesParent(doc, nsmgr,i);
				EntitePartiel entitesPartiels = EntitePartiel.EntitesPartiels(doc, nsmgr,i);
				List<Propriete> proprietes = Propriete.Proprietes(doc, nsmgr,i);
				List<ProprieteDynamique> proprietesDynamiques = ProprieteDynamique.ProprietesDynamiques(doc, nsmgr,i);
				Constructeur constructeurs = Constructeur.Constructeurs(doc, nsmgr, i);
				List<Methode> methodes = Methode.Methodes(doc, nsmgr,i);

				if (Methode.NombreMethodesEntites(doc, nsmgr,i - 1) != 0)
				{

					entites.Add(new Entite(noms[i-1], descriptions, entitesPartiels, classesParent,proprietes,proprietesDynamiques, constructeurs,methodes));
				}

				if (Methode.NombreMethodesEntites(doc, nsmgr,i - 1) == 0)
				{

					entites.Add(new Entite(noms[i - 1], descriptions, entitesPartiels, classesParent, proprietes, proprietesDynamiques, constructeurs));
				}



			}
			return entites;

		}


		#endregion


	}
}
