using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Registres
{/// <summary>
 /// Classe qui permet de récupérer la liste des types de retour d'un registre 
 /// </summary>
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
			var doc = "";
			if (this.Type != "void")
			{
				doc = "/// <returns>" + this.Description + "." + "</returns>";
			}

			return doc;

		}

		/// <summary>
		/// Methode qui renvoie la liste des colonnes des types de retour des methodes des registres 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static TypeRetourRegistre TypeRetourMethodesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeTypeRetourRegistres = new List<string>();


			
				if (MethodeRegistre.NombreMethodesRegistres(doc, nsmgr,i - 1) != 0)
				{

							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/preceding-sibling:: w:tbl / w:tr /w:tc)]";
					

							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeTypeRetourRegistres.Add(isbn2.InnerText);

							}
							
					}
				
			
			return (new TypeRetourRegistre(ListeTypeRetourRegistres[2],ListeTypeRetourRegistres[3]));

		}



		#endregion
	}
}
