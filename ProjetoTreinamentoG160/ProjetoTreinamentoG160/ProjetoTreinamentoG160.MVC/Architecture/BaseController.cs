using ProjetoTreinamentoG160.MVC.Architecture.Enuns;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTreinamentoG160.MVC.Architecture
{
    public abstract class BaseController : Controller
    {

        protected List<string> mensagens = new List<string>();
        public ReadOnlyCollection<string> Mensagens
        {
            get
            {
                return this.mensagens.AsReadOnly();
            }
        }

        protected void EmitirMensagem(string mensagem)
        {
            EmitirMensagem(mensagem, ETipoMensagem.Sucesso);
        }
        protected void EmitirMensagem(string mensagem, ETipoMensagem tipo)
        {
            if (tipo == ETipoMensagem.Sucesso)
            {
                List<string> msgs = TempData["success"] as List<string> ?? new List<string>();
                msgs.Add(mensagem);
                TempData["success"] = MontarMensagens(msgs);
            }
            else if (tipo == ETipoMensagem.Erro)
            {
                List<string> msgs = TempData["error"] as List<string> ?? new List<string>();
                msgs.Add(mensagem);
                TempData["error"] = MontarMensagens(msgs);
            }
            else if (tipo == ETipoMensagem.Aviso)
            {
                List<string> msgs = TempData["info"] as List<string> ?? new List<string>();
                msgs.Add(mensagem);
                TempData["info"] = MontarMensagens(msgs);
            }
        }

        protected void EmitirMensagem(List<string> mensagens, ETipoMensagem tipo)
        {
            if (tipo == ETipoMensagem.Sucesso)
            {
                List<string> msgs = TempData["success"] as List<string> ?? new List<string>();
                msgs.AddRange(mensagens);
                TempData["success"] = MontarMensagens(msgs);
            }
            else if (tipo == ETipoMensagem.Erro)
            {
                List<string> msgs = TempData["error"] as List<string> ?? new List<string>();
                msgs.AddRange(mensagens);
                TempData["error"] = MontarMensagens(msgs);
            }
            else if (tipo == ETipoMensagem.Aviso)
            {
                List<string> msgs = TempData["info"] as List<string> ?? new List<string>();
                msgs.AddRange(mensagens);
                TempData["info"] = MontarMensagens(msgs);
            }
        }

        public void EmitirMensagem(ReadOnlyCollection<string> mensagens)
        {
            EmitirMensagem(mensagens, ETipoMensagem.Sucesso);
        }
        public void EmitirMensagem(ReadOnlyCollection<string> mensagens, ETipoMensagem tipo)
        {
            mensagens.ToList().ForEach(li => EmitirMensagem(li, tipo));
        }

        public void EmitirMensagem(DbEntityValidationException excecao)
        {
            foreach (var eve in excecao.EntityValidationErrors)
            {
                string erro = string.Empty;
                erro = String.Format("Entidade \"{0}\" contém os seguintes erros: ",
                    eve.Entry.Entity.GetType().Name);
                foreach (var ve in eve.ValidationErrors)
                {
                    erro += String.Format("<br /> - Propriedade: \"{0}\", Erro: \"{1}\" ",
                        ve.PropertyName, ve.ErrorMessage);
                }

                this.EmitirMensagem(erro, ETipoMensagem.Erro);
            }
        }


        public string MontarMensagens(List<string> mensagens)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (var item in mensagens)
            {
                sb.Append("<li>");
                sb.Append("" + item + "");
                sb.Append("</li>");
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

    }
}