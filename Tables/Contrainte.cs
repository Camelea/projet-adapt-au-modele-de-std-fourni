using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Tables
{
	class Contrainte
	{
		#region Attributs
		public List<ClePrimaire> ClesPrimaires;
		public List<CleEtrangere> Clesetrangeres;
		public List<ContrainteNonNulle> ContraintesNonNulles;
		public List<ContrainteDeVerification> Contraintesdeverification;
		public Sequence Sequence;
		public List<Index> Indexes;

		#endregion


		#region Constructeur 
		/// <summary>
		/// Constructeur pour la contrainte qui va contenir une sequence , une liste de : clées primaires , clés etrangeres , contraintes non nulles et d'indexes 
		/// </summary>
		/// <param name="sequence"></param>
		/// <param name="clesPrimaires"></param>
		/// <param name="contraintesNonNulles"></param>
		/// <param name="indexes"></param>
		public Contrainte(Sequence sequence, List<ClePrimaire> clesPrimaires, List<ContrainteNonNulle> contraintesNonNulles, List<Index> indexes, List<CleEtrangere> clesEtrangeres, List<ContrainteDeVerification> contraintesDeVerification)
		{
			this.ClesPrimaires = clesPrimaires;
			this.Sequence = sequence;
			this.ContraintesNonNulles = contraintesNonNulles;
			this.Indexes = indexes;
			this.Clesetrangeres = clesEtrangeres;
			this.Contraintesdeverification = contraintesDeVerification;
		}
		#endregion

		#region Méthodes
		/// <summary>
		/// Fonction qui permet de construire une contrainte
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static Contrainte Contraintes(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{

				
			Sequence sequences = Sequence.SequenceTables(doc, nsmgr,i);
				List<ClePrimaire> clesprimaires = ClePrimaire.ClesPrimairesTables(doc, nsmgr,i);
				List<ContrainteDeVerification> contraintesdeverification = ContrainteDeVerification.ContraintesDeVerificationTables(doc, nsmgr,i);
				List<ContrainteNonNulle> contraintesnonnulles = ContrainteNonNulle.ContraintesNonNullesTables(doc, nsmgr,i);
				List<CleEtrangere> clesetrangeres = CleEtrangere.ClesEtrangeresTables(doc, nsmgr, i);
				List < Index > indexes = Index.IndexTables(doc, nsmgr,i);

				

			
			return (new Contrainte(sequences, clesprimaires, contraintesnonnulles, indexes, clesetrangeres, contraintesdeverification));

		}
		#endregion
	}
}
