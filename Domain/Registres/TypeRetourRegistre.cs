using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Registres
{
	class TypeRetourRegistre
	{
		#region Attributs
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 
		public TypeRetourRegistre(string type, string description)
		{
			this.Type = type;
			this.Description = description;

		}

		#endregion

		#region Méthodes

		public override string ToString()
		{
			return (Type + " " + Description);

		}

		/// <summary>
		/// Methode qui renvoie la liste des colonnes des types de retour des methodes des registres 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<TypeRetourRegistre>> TypeRetourMethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeTypeRetourRegistres = new List<List<string>>();
			List<List<TypeRetourRegistre>> TypeRetourInterfacesRegistres = new List<List<TypeRetourRegistre>>();

			for (int i = 1; i < Registre.NomsRegistres(doc, nsmgr).Count + 1; i++)
			{

				if (MethodeRegistre.NombreMethodesRegistres(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < MethodeRegistre.NombreMethodesRegistres(doc, nsmgr)[i - 1] + 1; cmp++)
					{
						if ((i < Registre.NomsRegistres(doc, nsmgr).Count + 1 && cmp < MethodeRegistre.NombreMethodesRegistres(doc, nsmgr)[i - 1]) || (i == Registre.NomsRegistres(doc, nsmgr).Count + 1 && cmp < MethodeRegistre.NombreMethodesRegistres(doc, nsmgr)[i - 1]))
						{
							ListeTypeRetourRegistres.Add(new List<string>());
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeTypeRetourRegistres[cmp].Add(isbn2.InnerText);

							}
							TypeRetourInterfacesRegistres.Add(ListeATypeRetourRegistre(ListeTypeRetourRegistres[cmp]));

						}
						if (i == Registre.NomsRegistres(doc, nsmgr).Count && cmp == MethodeRegistre.NombreMethodesRegistres(doc, nsmgr)[i - 1])
						{
							ListeTypeRetourRegistres.Add(new List<string>());
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /preceding-sibling:: w:tbl / w:tr /w:tc)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeTypeRetourRegistres[cmp].Add(isbn2.InnerText);

							}
							TypeRetourInterfacesRegistres.Add(ListeATypeRetourRegistre(ListeTypeRetourRegistres[cmp]));




						}
					}
				}
			}
			return TypeRetourInterfacesRegistres;

		}






		/// <summary>
		/// Renvoie la liste des types de retour des registres associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<TypeRetourRegistre> ListeATypeRetourRegistre(List<string> liste)
		{
			List<TypeRetourRegistre> ListeTypeRetourRegistre = new List<TypeRetourRegistre>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeTypeRetourRegistre.Add(new TypeRetourRegistre(liste[i], liste[i + 1]));
			}
			return ListeTypeRetourRegistre;
		}
		#endregion
	}
}
