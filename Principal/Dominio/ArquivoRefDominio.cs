using System.IO;

namespace Rpg.Dominio
{
    public class ArquivoRefDominio : RpgDominioBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Atributo _attDirArquivo;
        private ArquivoDominio _objArquivo;

        public Atributo attDirArquivo
        {
            get
            {
                if (_attDirArquivo != null)
                {
                    return _attDirArquivo;
                }

                _attDirArquivo = this.getAttDirArquivo();

                return _attDirArquivo;
            }
        }

        public ArquivoDominio objArquivo
        {
            get
            {
                if (_objArquivo != null)
                {
                    return _objArquivo;
                }

                _objArquivo = this.getObjArquivo();

                return _objArquivo;
            }

            set
            {
                if (_objArquivo == value)
                {
                    return;
                }

                _objArquivo = value;

                this.setObjArquivo(_objArquivo);
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        internal void salvarArqRef()
        {
            if (this.objArquivo == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.attDirArquivo.strValor))
            {
                return;
            }

            File.WriteAllText(this.attDirArquivo.strValor, JsonRpg.i.toJson(this.objArquivo));
        }

        private Atributo getAttDirArquivo()
        {
            Atributo attResultado = this.getAtt("Diretório");

            if (!string.IsNullOrEmpty(attResultado.strValor))
            {
                return attResultado;
            }

            attResultado.strValor = this.getDirArquivo();

            return attResultado;
        }

        private string getDirArquivo()
        {
            string strResultado = (this.attStrNome.strValor + AppRpg.STR_EXTENSAO_MAPA);

            RpgDominioBase objDominioPai = this.objPai;

            while (objDominioPai != null && !(objDominioPai is JogoDominio))
            {
                //strResultado = string.Format("{0}/{1}", objDominioPai.attStrNome.strValor, strResultado);
                strResultado = Path.Combine(objDominioPai.attStrNome.strValor, strResultado);

                objDominioPai = objDominioPai.objPai;
            }

            return Path.Combine(Path.GetDirectoryName(AppRpg.i.objJogo.attDirCompleto.strValor), strResultado);
        }

        private ArquivoDominio getObjArquivo()
        {
            if (string.IsNullOrEmpty(this.attDirArquivo.strValor))
            {
                return null;
            }

            if (!File.Exists(this.attDirArquivo.strValor))
            {
                return null;
            }

            ArquivoDominio objArqResultado = JsonRpg.i.fromJson<ArquivoDominio>(File.ReadAllText(this.attDirArquivo.strValor));

            objArqResultado.objPai = this;

            return objArqResultado;
        }

        private void setObjArquivo(ArquivoDominio objArquivo)
        {
            if (objArquivo == null)
            {
                return;
            }

            this.attDirArquivo.strValor = objArquivo.attDirCompleto.strValor;
            this.attStrNome.strValor = objArquivo.attStrNome.strValor;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}