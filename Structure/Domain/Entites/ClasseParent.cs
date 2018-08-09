using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{   /// <summary>
	/// Classe qui permet de recuperer la classe parent 
	/// </summary>
	public class ClasseParent
	{
		#region Attributs 

		public string Nom { get; private set; }
		public string Description { get; private set; }

		#endregion

		#region Constructeur 

		public ClasseParent(string nom, string description)
		{
			this.Nom = nom;
			this.Description = description;
		}

		#endregion

		#region Méthodes


		/// <summary>
		/// Renvoie la liste des informations des Classes parent des entites 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static ClasseParent ClassesParent(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeClasseParent = new List<string>();
			
				
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] / following-sibling::w:tbl/w:tr/w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4] / preceding-sibling::w:tbl/w:tr/w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4] / preceding-sibling::w:tbl/w:tr/w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{

					ListeClasseParent.Add(isbn2.InnerText);

				}
			if (ListeClasseParent.Count == 0)
			{
				return new ClasseParent("NA", "NA");
			}
		
			return new ClasseParent (ListeClasseParent[2],ListeClasseParent[3]);

		}



		#endregion
	}
}