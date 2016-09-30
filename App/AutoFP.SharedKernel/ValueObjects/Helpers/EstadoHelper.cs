using AutoFP.SharedKernel.ValueObjects.Enums;

namespace AutoFP.SharedKernel.ValueObjects.Helpers
{
    public static class EstadoHelper
    {
        public static string UfById(int? estadoId)
        {
            if (estadoId == null) return null;

            switch (estadoId)
            {
                case 1: return UnidadeFederativa.AC.ToString();
                case 2: return UnidadeFederativa.AL.ToString();
                case 3: return UnidadeFederativa.AP.ToString();
                case 4: return UnidadeFederativa.AM.ToString();
                case 5: return UnidadeFederativa.BA.ToString();
                case 6: return UnidadeFederativa.CE.ToString();
                case 7: return UnidadeFederativa.DF.ToString();
                case 8: return UnidadeFederativa.ES.ToString();
                case 9: return UnidadeFederativa.GO.ToString();
                case 10: return UnidadeFederativa.MA.ToString();
                case 11: return UnidadeFederativa.MT.ToString();
                case 12: return UnidadeFederativa.MS.ToString();
                case 13: return UnidadeFederativa.MG.ToString();
                case 14: return UnidadeFederativa.PA.ToString();
                case 15: return UnidadeFederativa.PB.ToString();
                case 16: return UnidadeFederativa.PR.ToString();
                case 17: return UnidadeFederativa.PE.ToString();
                case 18: return UnidadeFederativa.PI.ToString();
                case 19: return UnidadeFederativa.RJ.ToString();
                case 20: return UnidadeFederativa.RN.ToString();
                case 21: return UnidadeFederativa.RS.ToString();
                case 22: return UnidadeFederativa.RO.ToString();
                case 23: return UnidadeFederativa.RR.ToString();
                case 24: return UnidadeFederativa.SC.ToString();
                case 25: return UnidadeFederativa.SP.ToString();
                case 26: return UnidadeFederativa.SE.ToString();
                case 27: return UnidadeFederativa.TO.ToString();
            }
            return string.Empty;
        }
    }
}