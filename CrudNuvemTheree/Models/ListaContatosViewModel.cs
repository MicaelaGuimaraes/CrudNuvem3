using CrudNuvemTheree.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudNuvemTheree.Models
{
    public class ListaContatosViewModel
    {
        public ListaContatosViewModel()
        {

        }

        public ListaContatosViewModel(AgendaContatos itens)
        {
            Id = itens.Id;
            NomeContato = itens.NomeContato;
            EmailContato = itens.EmailContato;
            TelefoneContato = itens.TelefoneContato;
            Status = itens.Status;
        }

        public AgendaContatos ToDomain()
        {
            var Itens = new AgendaContatos();

            Itens.Id = Id;
            Itens.NomeContato = NomeContato;
            Itens.EmailContato = EmailContato;
            Itens.TelefoneContato = TelefoneContato;
            Itens.Status = Status;

            return Itens;
        }

        public int Id { get; set; }
        public string NomeContato { get; set; }
        public string EmailContato { get; set; }
        public string TelefoneContato { get; set; }
        public bool? Status { get; set; }
    }
}