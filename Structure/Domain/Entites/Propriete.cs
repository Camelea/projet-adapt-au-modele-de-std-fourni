using ConsoleApp4.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Entites
{/// <summary>
 /// Classe qui permet de récupérer la liste des proprietes d'un objet donnée  
 /// </summary
	class Propriete
	{
		#region Attributs 

		public string Nom;
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 

		public Propriete(string nom, string type,string description)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;
		}

		#endregion

		#region Méthodes

		public override string  ToString()
		{
			this.Type.Replace("Enum", "");
			this.Type.Replace("«", "");
			this.Type.Replace("»", "");
			var propriete = " /// <summary>" + "\n" + " ///" + this.Description + "\n" + " /// </summary>" + "\n" + "[Key]" + "\n" + "[CustomToColumnName(\"" + this.Nom.ToUpper() + "\")]" + "\n" + "public virtual  " + this.Type.ToLower() + " " + this.Nom + " { get; set;}";

			if (this.Type.Contains("nullable"))
			{
				var type = this.Type;
				type = type.Replace("nullable","");
				type = type.Replace("Enum","");
				type = type.Replace("«","");
				type = type.Replace("»","");
				propriete = " /// <summary>" + "\n" + " ///" + this.Description + "\n" + " /// </summary>" + "\n" + "[Key]" + "\n" + "[CustomToColumnName(\"" + this.Nom.ToUpper() + "\")]" + "\n" + "public virtual " + type.Trim() +"?" + " " + this.Nom + " { get; set;}";
			}
			return propriete;


		}
		/// <summary>
		/// Renvoie la liste des informations des proprietes des entites  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Propriete> Proprietes(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeProprietes = new List<string>();
		
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4] / following-sibling::w:tbl/w:tr/w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][5] / preceding-sibling::w:tbl/w:tr/w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][5] / preceding-sibling::w:tbl/w:tr/w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{

					ListeProprietes.Add(isbn2.InnerText);

				}
			
			


			return ListeAProprietes(ListeProprietes);

		}



		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste dde proprietes  
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<Propriete> ListeAProprietes(List<string> liste)
		{
			List<Propriete> ListeProprietes = new List<Propriete>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeProprietes.Add(new Propriete(liste[i], liste[i + 1],liste[i+2]));
			}
			return ListeProprietes;
		}


		#endregion
	}
}
