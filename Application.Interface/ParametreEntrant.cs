using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Application.Interface
{
	public class ParametreEntrant
	{

		#region Attributs
		public string Nom;
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 
		public ParametreEntrant(string nom, string type, string description)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;

		}

		#endregion

		#region Méthodes

		public override string ToString()
		{
			return (Nom + " " + Type + " " + Description);

		}

		#region ServicesExternes
		public static List<List<ParametreEntrant>> ParametresEntrantsMethodesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeMethodesClasses = new List<List<string>>();
			List<List<ParametreEntrant>> ParametresEntrantsMethodesClasses = new List<List<ParametreEntrant>>();

			for (int i = 1; i < InterfaceService.NomsInterfacesServices(doc, nsmgr).Count + 1; i++)
			{

				if (Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1]+1; cmp++)
					{

						ListeMethodesClasses.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
		
								ListeMethodesClasses[cmp].Add(isbn2.InnerText);
							
						}
						ParametresEntrantsMethodesClasses.Add(ListeAParametresEntrants(ListeMethodesClasses[cmp]));

					}

				}
			}
			return ParametresEntrantsMethodesClasses;

		}


		#endregion


		/// <summary>
		/// Renvoie la liste des proprietes associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreEntrant> ListeAParametresEntrants(List<string> liste)
		{
			List<ParametreEntrant> ListeParametresEntrantsClasses = new List<ParametreEntrant>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametresEntrantsClasses.Add(new ParametreEntrant(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametresEntrantsClasses;
		}
		#endregion

	}
}